using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;

namespace backend.Services.IServices
{
    public interface IPedidoService
    {
        Task PedidoPost(Pedido pedido);
        Task<Pedido> GetPedido(int id);
    }
}