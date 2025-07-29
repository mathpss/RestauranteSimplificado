using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Context;
using backend.Models;
using backend.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class PedidoRetiradaService : IPedidoRetiradaService
    {
        private readonly RestauranteContext _context;

        public PedidoRetiradaService(RestauranteContext context)
        {
            _context = context;
        }

        public async Task CriarPedidoRetirada(PedidoRetirada pedidoRetirada)
        {
            await _context.PedidoRetiradas.AddAsync(pedidoRetirada);
            await _context.SaveChangesAsync();
        }

        public async Task<PedidoRetirada> GetPedidoRetirada(int id)
        {
            return await _context.PedidoRetiradas.FindAsync(id) ?? throw new NullReferenceException();
        }

        public async Task<IEnumerable<PedidoRetirada>> ListaPedidoRetirada()
        {
            return await _context.PedidoRetiradas.Include(p => p.Pedidos).ToListAsync();
        }

        public async Task<IEnumerable<PedidoRetirada>> ListaPedidoRetiradaHoje()
        {
            return await _context.PedidoRetiradas.Where(x => x.Date.Date == DateTime.Today)
                            .Include(p => p.Pedidos)
                            .ToListAsync();
        }
    }
}