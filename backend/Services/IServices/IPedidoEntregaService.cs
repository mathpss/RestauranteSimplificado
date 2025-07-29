using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;

namespace backend.Services.IServices
{
    public interface IPedidoEntregaService
    {
        Task CriarPedidoEntraga(PedidoEntrega pedidoEntrega);
        Task<PedidoEntrega> GetPedidoEntrega(int id);

        Task<IEnumerable<PedidoEntrega>> ListaPedidoEntregaHoje();
        Task<IEnumerable<PedidoEntrega>> ListaPedidoEntrega();
    }
}