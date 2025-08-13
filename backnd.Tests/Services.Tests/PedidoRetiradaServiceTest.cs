using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Context;
using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace backnd.Tests.Services.Tests
{
    public class PedidoRetiradaServiceTest
    {
        private readonly Pedido _pedido;
        private readonly PedidoRetirada _pedidoRetirada;

        public PedidoRetiradaServiceTest()
        {
            _pedido = new()
            {
                Id = 3,
                Tamanho = "g",
                Valor = 22M,
                PedidoEntregaId = null,
                PedidoRetiradaId = 6,
                Mistura = ["Teste Mistura 1", "Teste Mistura 55"],
                Guarnicao = ["Teste Guarnicao 36", "Teste Guarnicao 12"]
            };

            _pedidoRetirada = new()
            {
                Id = 6,
                Nome = "Artemis",
                Telefone = "19993934747",
                Pedidos = [_pedido],
                Date = DateTime.Today
            };
        }

        [Fact]
        public async Task CriarPedidoRetirada_DeveRetornarOk()
        {
            var options = new DbContextOptionsBuilder<RestauranteContext>()
                        .UseInMemoryDatabase(databaseName: "DbCriarPedidoRetirada")
                        .Options;

            using (var context = new RestauranteContext(options))
            {
                var service = new PedidoRetiradaService(context);

                await service.CriarPedidoRetirada(_pedidoRetirada);
            }

            using (var context = new RestauranteContext(options))
            {
                var result = context.PedidoRetiradas.FirstOrDefault(x => x.Id == 6);

                Assert.NotNull(result);
                Assert.Equal(6, result.Id);
                Assert.Equal("Artemis", result.Nome);
                Assert.Equal("19993934747", result.Telefone);
                Assert.Equal(DateTime.Today, result.Date);

                Assert.Null(result.Pedidos);
            }

        }

        [Fact]
        public async Task GetPedidoRetirada_QuandoEncontrarPedidoRetiradaDeveRetornarOk()
        {
            var options = new DbContextOptionsBuilder<RestauranteContext>()
                        .UseInMemoryDatabase(databaseName: "DbGetPedidoRetirada")
                        .Options;

            using (var context = new RestauranteContext(options))
            {
                context.PedidoRetiradas.Add(_pedidoRetirada);
                context.SaveChanges();
            }

            using (var context = new RestauranteContext(options))
            {
                var service = new PedidoRetiradaService(context);

                var result = await service.GetPedidoRetirada(6);

                Assert.NotNull(result);
                Assert.Equal(6, result.Id);
                Assert.Equal("Artemis", result.Nome);
                Assert.Equal("19993934747", result.Telefone);
                Assert.Equal(DateTime.Today, result.Date);

                Assert.Null(result.Pedidos);
            }
        }

        [Fact]
        public async Task GetPedidoRetirada_QuantoNaoEncontrarDeveRetornarExcecao()
        {
            var options = new DbContextOptionsBuilder<RestauranteContext>()
                        .UseInMemoryDatabase(databaseName: "DbGetPedidoRetirada_Excecao")
                        .Options;

            using (var context = new RestauranteContext(options))
            {
                var service = new PedidoRetiradaService(context);

                await Assert.ThrowsAsync<NullReferenceException>(() => service.GetPedidoRetirada(6));
            }

        }

        [Fact]
        public async Task ListaPedidoRetirada_QuandoEncontradoDeveRetornarOk()
        {
            var options = new DbContextOptionsBuilder<RestauranteContext>()
                        .UseInMemoryDatabase(databaseName: "DbListaPedidoRetirada")
                        .Options;

            using (var context = new RestauranteContext(options))
            {
                context.PedidoRetiradas.Add(_pedidoRetirada);
                context.SaveChanges();
            }

            using (var context = new RestauranteContext(options))
            {
                var service = new PedidoRetiradaService(context);

                var result = await service.ListaPedidoRetirada();

                Assert.NotNull(result);
                Assert.Single(result);

                var firstResult = result.First();

                Assert.Equal(6, firstResult.Id);
                Assert.Equal("Artemis", firstResult.Nome);
                Assert.Equal("19993934747", firstResult.Telefone);
                Assert.Equal(DateTime.Today, firstResult.Date);

                Assert.NotNull(firstResult.Pedidos);
                Assert.Equal(3, firstResult.Pedidos.First().Id);
                Assert.Equal("g", firstResult.Pedidos.First().Tamanho);
                Assert.Equal(22M, firstResult.Pedidos.First().Valor);
                Assert.Equal(6, firstResult.Pedidos.First().PedidoRetiradaId);
                Assert.Null(firstResult.Pedidos.First().PedidoEntregaId);
                Assert.Equal(["Teste Mistura 1", "Teste Mistura 55"], firstResult.Pedidos.First().Mistura);
                Assert.Equal(["Teste Guarnicao 36", "Teste Guarnicao 12"], firstResult.Pedidos.First().Guarnicao);
            }
        }

        [Fact]
        public async Task ListaPedidoRetiradaHoje_QuandoEncontradoPedidoRetiradaDeveRetornarOk()
        {
            var pedidoRetiradaOntem = new PedidoRetirada
            {
                Id = 30,
                Telefone = "11995956565",
                Nome = "Orfeu",
                Date = DateTime.Today.AddDays(-1),
                Pedidos = null

            };

            var options = new DbContextOptionsBuilder<RestauranteContext>()
                        .UseInMemoryDatabase(databaseName: "DbListaPedidoRetiradaHoje")
                        .Options;
            using (var context = new RestauranteContext(options))
            {
                context.PedidoRetiradas.AddRange(_pedidoRetirada, pedidoRetiradaOntem);
                context.SaveChanges();
            }

            using (var context = new RestauranteContext(options))
            {
                var service = new PedidoRetiradaService(context);

                var result = await service.ListaPedidoRetiradaHoje();

                Assert.NotNull(result);
                Assert.Single(result);

                var firstResult = result.First();
                Assert.Equal(6, firstResult.Id);
                Assert.Equal("Artemis", firstResult.Nome);
                Assert.Equal("19993934747", firstResult.Telefone);
                Assert.Equal(DateTime.Today, firstResult.Date);

                Assert.NotNull(firstResult.Pedidos);
                Assert.Equal(3, firstResult.Pedidos.First().Id);
                Assert.Equal("g", firstResult.Pedidos.First().Tamanho);
                Assert.Equal(22M, firstResult.Pedidos.First().Valor);
                Assert.Equal(6, firstResult.Pedidos.First().PedidoRetiradaId);
                Assert.Null(firstResult.Pedidos.First().PedidoEntregaId);
                Assert.Equal(["Teste Mistura 1", "Teste Mistura 55"], firstResult.Pedidos.First().Mistura);
                Assert.Equal(["Teste Guarnicao 36", "Teste Guarnicao 12"], firstResult.Pedidos.First().Guarnicao);


            }
        }

        [Fact]
        public async Task ListaPedidoRetiradaHoje_QuandoEstiverVaziaDeveRetornarListaVazia()
        {
            var options = new DbContextOptionsBuilder<RestauranteContext>()
                        .UseInMemoryDatabase(databaseName: "DbListaPedidoRetiradaHoje_Vazia")
                        .Options;
            using (var context = new RestauranteContext(options))
            {
                var service = new PedidoRetiradaService(context);

                var result = await service.ListaPedidoRetiradaHoje();

                Assert.Empty(result);
            }
        }
    }
}