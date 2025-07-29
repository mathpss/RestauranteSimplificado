using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public required string Tamanho { get; set; }
        public required List<string> Guarnicao { get; set; }
        public required List<string> Mistura { get; set; }
        public int? PedidoEntregaId { get; set; }
        public int? PedidoRetiradaId { get; set; }

    }

}