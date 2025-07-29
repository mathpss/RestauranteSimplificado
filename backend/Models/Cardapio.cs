using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Cardapio
    {
        public int Id { get; set; }
        public required string Mistura { get; set; }
        public required string Guarnicao { get; set; }
    }
}