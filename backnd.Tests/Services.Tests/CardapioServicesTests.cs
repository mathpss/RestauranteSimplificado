using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Context;
using backend.Models;
using backend.Services;
using backend.Services.IServices;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace backnd.Tests.Services.Tests
{
    public class CardapioServicesTests
    {
        [Fact]
        public async Task Get_ResultadoDeveraSerOkAsync()
        {
            var cardapioExpected = new Cardapio
            {
                Id = 1,
                Guarnicao = "teste da guarnicao",
                Mistura = "teste da mistura"
            };

            var options = new DbContextOptionsBuilder<RestauranteContext>()
                        .UseInMemoryDatabase(databaseName: "DbTeste")
                        .Options;

            using (var context = new RestauranteContext(options))
            {
                context.Cardapios.Add(cardapioExpected);
                context.SaveChanges();
            }

            using (var context = new RestauranteContext(options))
            {
                var service = new CardapioService(context);

                var result = await service.Get();

                Assert.NotNull(result);
                Assert.Equal(1, cardapioExpected.Id);
                Assert.Equal("teste da guarnicao", cardapioExpected.Guarnicao);
                Assert.Equal("teste da mistura", cardapioExpected.Mistura);
            }




        }

        [Fact]
        public async Task Get_DeveLancarExcecaoQuandoNaoExist()
        {
            var options = new DbContextOptionsBuilder<RestauranteContext>()
                            .UseInMemoryDatabase(databaseName: "DbTesteException")
                            .Options;

            using (var context = new RestauranteContext(options))
            {
                var service = new CardapioService(context);

                await Assert.ThrowsAsync<NullReferenceException>(() => service.Get());
            }
        }

        [Fact]
        public async Task Update_DeveAtualizarCardapioNoBanco()
        {

            var cardapioAntigo = new Cardapio
            {
                Id = 1,
                Guarnicao = "guarnicao antiga",
                Mistura = "mistura antiga"
            };

            var cardapioAtualizado = new Cardapio
            {
                Id = 1,
                Guarnicao = "guarnicao atualizado",
                Mistura = "mistura atualizado"
            };

            var options = new DbContextOptionsBuilder<RestauranteContext>()
                            .UseInMemoryDatabase(databaseName: "DbTesteUpdate")
                            .Options;

            using (var context = new RestauranteContext(options))
            {
                context.Cardapios.Add(cardapioAntigo);
                context.SaveChanges();
            }

            using (var context = new RestauranteContext(options))
            {
                var service = new CardapioService(context);

                await service.Update(cardapioAtualizado);
            }

            using (var context = new RestauranteContext(options))
            {
                var cardapio = context.Cardapios.FirstOrDefault(x => x.Id == 1);

                Assert.NotNull(cardapio);
                Assert.Equal(1, cardapio.Id);
                Assert.Equal("guarnicao atualizado", cardapio.Guarnicao);
                Assert.Equal("mistura atualizado", cardapio.Mistura);
            }
        }
    }
}