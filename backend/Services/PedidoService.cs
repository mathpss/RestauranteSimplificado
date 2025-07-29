using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Context;
using backend.Models;
using backend.Services.IServices;

namespace backend.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly RestauranteContext _context;

        public PedidoService(RestauranteContext context)
        {
            _context = context;
        }

        public async Task<Pedido> GetPedido(int id)
        {
            return await _context.Pedidos.FindAsync(id) ??  throw new NullReferenceException("Pedido não encontrado");
        }

        public async Task PedidoPost(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();
        }
    }
}