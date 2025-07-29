using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;

namespace backend.Services.IServices
{
    public interface ICardapioService
    {
        public Task Update(Cardapio cardapio);
        public Task<Cardapio> Get();
    }
}