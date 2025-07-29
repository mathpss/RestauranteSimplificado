using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class PedidoEntrega
    {
        public int Id { get; set; }
        [StringLength(70)]
        public required string Nome { get; set; }
        [StringLength(70)]
        public required string Telefone { get; set; }
        
        public List<Pedido>? Pedidos { get; set; }

        [StringLength(70)]
        public required string NomeRua { get; set; }
        [StringLength(10)]
        public required string NumeroRua { get; set; }
        [StringLength(70)]
        public required string Bairro { get; set; }
        [StringLength(70)]
        public required string Cidade { get; set; }
        public DateTimeOffset Date { get; set; } = TimeZoneInfo.ConvertTime
                    (DateTimeOffset.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
    }
}