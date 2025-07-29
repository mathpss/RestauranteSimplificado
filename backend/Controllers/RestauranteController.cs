using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using backend.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RestauranteController : ControllerBase
    {
        private const string Key = "Cardapio-Cache";
        private readonly ICardapioService _cardapioService;
        private readonly IPedidoEntregaService _pedidoEntregaService;
        private readonly IPedidoRetiradaService _pedidoRetiradaService;
        private readonly IPedidoService _pedidoService;
        private readonly IMemoryCache _memoryCache;

        public RestauranteController(IPedidoEntregaService pedidoEntregaService, IPedidoRetiradaService pedidoRetiradaService, ICardapioService cardapioService, IPedidoService pedidoService, IMemoryCache memoryCache)
        {
            _pedidoEntregaService = pedidoEntregaService;
            _pedidoRetiradaService = pedidoRetiradaService;
            _cardapioService = cardapioService;
            _pedidoService = pedidoService;
            _memoryCache = memoryCache;
        }

        #region Cardapio

        [HttpGet("Cardapio")]
        [Tags("Cardapio")]
        public async Task<IActionResult> GetCardapio()
        {
            var cardapio = await _cardapioService.Get();
            if (cardapio == null) return NotFound("Cárdapio Vazio");

            if (_memoryCache.TryGetValue(Key, out Cardapio cardapioCache))
            {
                return Ok(cardapioCache);
            }

            var memoryCacheEntryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(180),
                SlidingExpiration = TimeSpan.FromMinutes(30)
            };

            _memoryCache.Set(Key, cardapio, memoryCacheEntryOptions);

            return Ok(cardapio);
        }

        [HttpPut("Cardapio")]
        [Tags("Cardapio")]
        public async Task<IActionResult> Update(Cardapio cardapio)
        {
            var cardapioDB = await _cardapioService.Get();
            if (cardapioDB == null) return NotFound("Cárdapio Vazio");

            cardapioDB.Mistura = cardapio.Mistura;
            cardapioDB.Guarnicao = cardapio.Guarnicao;

            await _cardapioService.Update(cardapioDB);

            var memoryCacheEntryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(180),
                SlidingExpiration = TimeSpan.FromMinutes(30)
            };

            _memoryCache.Set(Key, cardapioDB, memoryCacheEntryOptions);

            return NoContent();
        }

        #endregion

        #region PedidoEntrega

        [HttpGet("Entrega/Hoje")]
        [Tags("PedidoEntrega")]
        public async Task<IActionResult> ListaEntregaHoje()
        {
            var entregaHoje = await _pedidoEntregaService.ListaPedidoEntregaHoje();
            if (entregaHoje == null) NotFound("Sem pedido de Entrega hoje.");

            return Ok(entregaHoje);
        }

        [HttpGet("Entrega/Relatorio")]
        [Tags("PedidoEntrega")]
        public async Task<IActionResult> EntregaRelatorio()
        {
            var entregaRelatorio = await _pedidoEntregaService.ListaPedidoEntrega();
            if (entregaRelatorio == null) NotFound("Sem pedidos de entrega");

            return Ok(entregaRelatorio);
        }

        [HttpGet("Entrega/{id:int}")]
        [Tags("PedidoEntrega")]
        public async Task<IActionResult> GetEntrega(int id)
        {
            var entrega = await _pedidoEntregaService.GetPedidoEntrega(id);
            if (entrega == null) NotFound("Entrega não encontrada");

            return Ok(entrega);
        }

        [HttpPost("Entrega")]
        [Tags("PedidoEntrega")]
        public async Task<IActionResult> PostEntrega(PedidoEntrega pedidoEntrega)
        {
            await _pedidoEntregaService.CriarPedidoEntraga(pedidoEntrega);

            return CreatedAtAction(nameof(GetEntrega), new { id = pedidoEntrega.Id }, pedidoEntrega);
        }

        #endregion

        #region RetiradaEntrega

        [HttpGet("Retirada/Hoje")]
        [Tags("PedidoRetirada")]
        public async Task<IActionResult> RetiradaHoje()
        {
            var retiradaHoje = await _pedidoRetiradaService.ListaPedidoRetiradaHoje();
            if (retiradaHoje == null) NotFound("Sem pedidos de retiradas hoje");

            return Ok(retiradaHoje);
        }

        [HttpGet("Retirada/Relatorio")]
        [Tags("PedidoRetirada")]
        public async Task<IActionResult> RetiradaRelatorio()
        {
            var retiradaRelatorio = await _pedidoRetiradaService.ListaPedidoRetirada();
            if (retiradaRelatorio == null) NotFound("Sem pedidos de retiradas");

            return Ok(retiradaRelatorio);
        }

        [HttpGet("Retirada/{id:int}")]
        [Tags("PedidoRetirada")]
        public async Task<IActionResult> GetRetirada(int id)
        {
            var retirada = await _pedidoRetiradaService.GetPedidoRetirada(id);
            if (retirada == null) NotFound("Sem pedidos de retirada");

            return Ok(retirada);
        }

        [HttpPost("Retirada")]
        [Tags("PedidoRetirada")]
        public async Task<IActionResult> PostRetirada(PedidoRetirada pedidoRetirada)
        {
            await _pedidoRetiradaService.CriarPedidoRetirada(pedidoRetirada);

            return CreatedAtAction(nameof(GetRetirada), new { id = pedidoRetirada.Id }, pedidoRetirada);
        }

        #endregion

        #region Pedidos

        [HttpPost("pedido")]
        [Tags("Pedidos")]
        public async Task<IActionResult> PedidoPost(Pedido pedido)
        {
            await _pedidoService.PedidoPost(pedido);

            return CreatedAtAction(nameof(GetPedido), new { id = pedido.Id }, pedido);
        }

        [HttpGet("pedido/{id:int}")]
        [Tags("Pedidos")]
        public async Task<IActionResult> GetPedido(int id)
        {
            var pedidoDb = await _pedidoService.GetPedido(id);
            if (pedidoDb == null) NotFound("Não foi encontrado o pedido");

            return Ok(pedidoDb);
        }
        #endregion
    }
}