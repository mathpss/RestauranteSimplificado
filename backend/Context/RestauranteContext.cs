using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using Microsoft.EntityFrameworkCore;


namespace backend.Context
{
    public class RestauranteContext(DbContextOptions<RestauranteContext> options) : DbContext(options)
    {
        public DbSet<Cardapio> Cardapios { get; set; }

        public DbSet<PedidoRetirada> PedidoRetiradas { get; set; }
        
        public DbSet<PedidoEntrega> PedidoEntregas { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Cardapio>().HasData(

                new Cardapio
                {
                    Id = 1,
                    Guarnicao = "Legumes Refogado, Abóbora Cabutia, Repolho Refogado, Salada de Ovo c/ Maionese, Batata Palha, Macarrão Alho e Óleo, Farofa do Cheff",
                    Mistura = "Isca de Carne, Calabresa Acebolada, Linguiça Tosacana Frita, Parmegiana de Frango, Filé de Frango Empanado, Ovo Frito"
                }

            );

            modelBuilder.Entity<Pedido>()
                .Property(m => m.Mistura)
                .HasColumnType("text[]");

            modelBuilder.Entity<Pedido>()
                .Property(g => g.Guarnicao)
                .HasColumnType("text[]");
                
        }
    }
}