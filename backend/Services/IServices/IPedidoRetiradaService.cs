using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;

namespace backend.Services.IServices
{
    public interface IPedidoRetiradaService
    {
        Task CriarPedidoRetirada(PedidoRetirada pedidoRetirada);
        Task<PedidoRetirada> GetPedidoRetirada(int id);
        Task<IEnumerable<PedidoRetirada>> ListaPedidoRetirada();
        Task<IEnumerable<PedidoRetirada>> ListaPedidoRetiradaHoje();
    }
}