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
    public class CardapioService : ICardapioService
    {
        private readonly RestauranteContext _context;

        public CardapioService(RestauranteContext context)
        {
            _context = context;
        }

        public async Task<Cardapio> Get()
        {
            return await _context.Cardapios.FirstOrDefaultAsync(x => x.Id == 1) ?? throw new NullReferenceException(); 
        }

        public async Task Update(Cardapio cardapio)
        {
            _context.Cardapios.Update(cardapio);
            await _context.SaveChangesAsync();
        }
    }
}