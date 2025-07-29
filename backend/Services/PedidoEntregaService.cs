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
    public class PedidoEntregaService : IPedidoEntregaService
    {
        private readonly RestauranteContext _context;

        public PedidoEntregaService(RestauranteContext context)
        {
            _context = context;
        }

        public async Task CriarPedidoEntraga(PedidoEntrega pedidoEntrega)
        {
            await _context.PedidoEntregas.AddAsync(pedidoEntrega);
            await _context.SaveChangesAsync();
        }

        public async Task<PedidoEntrega> GetPedidoEntrega(int id)
        {
            return  await _context.PedidoEntregas.FindAsync(id) ?? throw new NullReferenceException();
             
        }

        public async Task<IEnumerable<PedidoEntrega>> ListaPedidoEntrega()
        {
            return await _context.PedidoEntregas.Include(p => p.Pedidos).ToListAsync();
        }

        public async Task<IEnumerable<PedidoEntrega>> ListaPedidoEntregaHoje()
        {
            return await _context.PedidoEntregas.Where(x => x.Date.Date == DateTime.Today)
                    .Include(p => p.Pedidos).ToListAsync();
        }
    }
}