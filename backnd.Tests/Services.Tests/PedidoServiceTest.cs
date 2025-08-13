using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Context;
using backend.Models;
using backend.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace backnd.Tests.Services.Tests
{
    public class PedidoServiceTest
    {
        private readonly Pedido _pedido;

        public PedidoServiceTest()
        {
            _pedido = new()
            {
                Id = 15,
                PedidoEntregaId = null,
                Tamanho = "p",
                Valor = 17M,
                PedidoRetiradaId = 5,
                Mistura = ["Mistura teste", "Mistura teste 2"],
                Guarnicao = ["Guarnicao teste", "Guarnicao teste 2"]
            };
        }

        [Fact]
        public async Task GetPedido_QuandoEncontrado_DeveRetornarOk()
        {
            var options = new DbContextOptionsBuilder<RestauranteContext>()
                        .UseInMemoryDatabase(databaseName: "DbGetPedido")
                        .Options;
            using (var context = new RestauranteContext(options))
            {
                context.Pedidos.Add(_pedido);
                context.SaveChanges();
            }

            using (var context = new RestauranteContext(options))
            {
                var service = new PedidoService(context);

                var result = await service.GetPedido(15);

                Assert.NotNull(result);
                Assert.Equal(15, result.Id);
                Assert.Equal(5, result.PedidoRetiradaId);
                Assert.Null(result.PedidoEntregaId);
                Assert.Equal(17, result.Valor);
                Assert.Equal("p", result.Tamanho);
                Assert.Equal(["Guarnicao teste", "Guarnicao teste 2"], result.Guarnicao);
                Assert.Equal(["Mistura teste", "Mistura teste 2"], result.Mistura);
            }
        }

        [Fact]
        public async Task GetPedido_QuandoNaoEncontrado_DeveRetornarExcecao()
        {
            var options = new DbContextOptionsBuilder<RestauranteContext>()
                        .UseInMemoryDatabase(databaseName: "DbGetPedido_Excecao")
                        .Options;
            using (var context = new RestauranteContext(options))
            {
                var service = new PedidoService(context);

                await Assert.ThrowsAsync<NullReferenceException>(() => service.GetPedido(5));

            }
        }

        [Fact]
        public async Task PedidoPost_QuandoCriado_DeveRetornarOk()
        {
            var options = new DbContextOptionsBuilder<RestauranteContext>()
                        .UseInMemoryDatabase(databaseName: "DbPedidoPost")
                        .Options;
            using (var context = new RestauranteContext(options))
            {
                var service = new PedidoService(context);
                await service.PedidoPost(_pedido);

                var result = context.Pedidos.FirstOrDefault(x => x.Id == 15);

                Assert.NotNull(result);
                Assert.Equal(15, result.Id);
                Assert.Equal(5, result.PedidoRetiradaId);
                Assert.Null(result.PedidoEntregaId);
                Assert.Equal(17, result.Valor);
                Assert.Equal("p", result.Tamanho);
                Assert.Equal(["Guarnicao teste", "Guarnicao teste 2"], result.Guarnicao);
                Assert.Equal(["Mistura teste", "Mistura teste 2"], result.Mistura);
                 
            }
        }
    }
}