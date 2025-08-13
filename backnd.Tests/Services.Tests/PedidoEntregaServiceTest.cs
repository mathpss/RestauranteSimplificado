using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Context;
using backend.Models;
using backend.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace backnd.Tests.Services.Tests
{
    public class PedidoEntregaServiceTest
    {
        private readonly Pedido _pedido;

        public PedidoEntregaServiceTest()
        {
            _pedido = new()
            {
                Id = 5,
                Tamanho = "m",
                Valor = 20M,
                PedidoEntregaId = 15,
                PedidoRetiradaId = null,
                Mistura = ["Teste Mistura 3", "Teste Mistura 4"],
                Guarnicao = ["Teste Guarnicao 3", "Teste Guarnicao 4"]
            };
        }

        [Fact]
        public async Task CriarPedidoEntrega_DeveRetornarOk()
        {
            var pedidoEntrega = new PedidoEntrega
            {
                Id = 2,
                Bairro = "Jd das Flores",
                Cidade = "Cidade Jardim",
                Nome = "João",
                NomeRua = "Ipê",
                NumeroRua = "19",
                Telefone = "19995958585",
                Date = DateTime.Today,
                Pedidos = null

            };

            var options = new DbContextOptionsBuilder<RestauranteContext>()
                        .UseInMemoryDatabase(databaseName: "DbCriarPedidoEntrega")
                        .Options;

            using (var context = new RestauranteContext(options))
            {
                var service = new PedidoEntregaService(context);

                await service.CriarPedidoEntraga(pedidoEntrega);

            }

            using (var context = new RestauranteContext(options))
            {
                var result = context.PedidoEntregas.FirstOrDefault(x => x.Id == 2);


                Assert.NotNull(result);
                Assert.Equal(2, result.Id);
                Assert.Equal("Jd das Flores", result.Bairro);
                Assert.Equal("Cidade Jardim", result.Cidade);
                Assert.Equal("João", result.Nome);
                Assert.Equal("Ipê", result.NomeRua);
                Assert.Equal("19995958585", result.Telefone);
                Assert.Equal(DateTime.Today, result.Date);
                Assert.Null(result.Pedidos);
            }


        }

        [Fact]
        public async Task GetPedidoEntrega_DeveRetornarOk()
        {
            var pedidoEntrega = new PedidoEntrega
            {
                Id = 2,
                Bairro = "Jd das Flores",
                Cidade = "Cidade Jardim",
                Nome = "João",
                NomeRua = "Ipê",
                NumeroRua = "19",
                Telefone = "19995958585",
                Date = DateTime.Today,
                Pedidos = null

            };

            var options = new DbContextOptionsBuilder<RestauranteContext>()
                        .UseInMemoryDatabase(databaseName: "DbGetPedidoEntrega")
                        .Options;

            using (var context = new RestauranteContext(options))
            {
                context.PedidoEntregas.Add(pedidoEntrega);
                context.SaveChanges();
            }

            using (var context = new RestauranteContext(options))
            {
                var service = new PedidoEntregaService(context);

                var result = await service.GetPedidoEntrega(2);

                Assert.NotNull(result);
                Assert.Equal(2, result.Id);
                Assert.Equal("Jd das Flores", result.Bairro);
                Assert.Equal("Cidade Jardim", result.Cidade);
                Assert.Equal("João", result.Nome);
                Assert.Equal("Ipê", result.NomeRua);
                Assert.Equal("19995958585", result.Telefone);
                Assert.Equal(DateTime.Today, result.Date);
                Assert.Null(result.Pedidos);
            }

        }

        [Fact]
        public async Task GetPedidoEntrega_DeveLancarExcecaoQuandoNaoEncontrar()
        {
            var options = new DbContextOptionsBuilder<RestauranteContext>()
                        .UseInMemoryDatabase(databaseName: "DbGetpedidoEntregaException")
                        .Options;

            using (var context = new RestauranteContext(options))
            {
                var service = new PedidoEntregaService(context);

                await Assert.ThrowsAsync<NullReferenceException>(() => service.GetPedidoEntrega(5));
            }
        }

        [Fact]
        public async Task ListaPedidoEntrega_DeveRetornarOk()
        {
            var pedidoEntrega = new PedidoEntrega
            {
                Id = 15,
                Bairro = "Jd das Flores",
                Cidade = "Cidade Jardim",
                Nome = "João",
                NomeRua = "Ipê",
                NumeroRua = "19",
                Telefone = "19995958585",
                Date = DateTime.Today,
                Pedidos = [_pedido]

            };

            var options = new DbContextOptionsBuilder<RestauranteContext>()
                        .UseInMemoryDatabase(databaseName: "DbListaPedidoEntrega")
                        .Options;

            using (var context = new RestauranteContext(options))
            {
                context.PedidoEntregas.Add(pedidoEntrega);
                context.Pedidos.Add(_pedido);
                context.SaveChanges();
            }

            using (var context = new RestauranteContext(options))
            {
                var service = new PedidoEntregaService(context);

                var result = await service.ListaPedidoEntrega();

                Assert.NotNull(result);
                Assert.Single(result);

                var firstResult = result.First();

                Assert.NotNull(firstResult.Pedidos);
                Assert.Equal(15, firstResult.Id);
                Assert.Equal("Jd das Flores", firstResult.Bairro);
                Assert.Equal("Cidade Jardim", firstResult.Cidade);
                Assert.Equal("João", firstResult.Nome);
                Assert.Equal("Ipê", firstResult.NomeRua);
                Assert.Equal("19995958585", firstResult.Telefone);
                Assert.Equal(DateTime.Today, firstResult.Date);

                Assert.Equal(5, firstResult.Pedidos.First().Id);
                Assert.Equal(15, firstResult.Pedidos.First().PedidoEntregaId);
                Assert.Null(firstResult.Pedidos.First().PedidoRetiradaId);
                Assert.Equal(["Teste Guarnicao 3", "Teste Guarnicao 4"], firstResult.Pedidos.First().Guarnicao);
                Assert.Equal(["Teste Mistura 3", "Teste Mistura 4"], firstResult.Pedidos.First().Mistura);
                Assert.Equal("m", firstResult.Pedidos.First().Tamanho);
                Assert.Equal(20M, firstResult.Pedidos.First().Valor);

            }
        }

        [Fact]
        public async Task ListaPedidoEntregaHoje_DeveRetornarOk()
        {
            var pedidoEntrega = new PedidoEntrega
            {
                Id = 15,
                Bairro = "Jd das Flores",
                Cidade = "Cidade Jardim",
                Nome = "João",
                NomeRua = "Ipê",
                NumeroRua = "19",
                Telefone = "19995958585",
                Date = DateTime.Today,
                Pedidos = [_pedido]

            };

            var pedidoEntregaOntem = new PedidoEntrega
            {
                Id = 20,
                Bairro = "Jd Primavera",
                Cidade = "Cidade das Estações",
                Date = DateTime.Today.AddDays(-1),
                Nome = "Carlinhos",
                NomeRua = "Solstício",
                NumeroRua = "356",
                Telefone = "19945452525",
                Pedidos = new List<Pedido>
                {
                    new() {
                        Id = 30,
                        Guarnicao = ["Guarnicao Teste"],
                        Mistura = ["Mistura Teste"],
                        Tamanho = "g",
                        PedidoEntregaId = 20,
                        PedidoRetiradaId = null,
                        Valor = 22
                    }
                }
            };

            var options = new DbContextOptionsBuilder<RestauranteContext>()
                        .UseInMemoryDatabase(databaseName: "DbListaPedidoEntregaHoje")
                        .Options;

            using (var context = new RestauranteContext(options))
            {
                context.PedidoEntregas.AddRange(pedidoEntrega, pedidoEntregaOntem);
                //context.Pedidos.Add(_pedido);
                context.SaveChanges();
            }

            using (var context = new RestauranteContext(options))
            {
                var service = new PedidoEntregaService(context);

                var result = await service.ListaPedidoEntregaHoje();

                Assert.NotNull(result);
                Assert.Single(result);

                var firstResult = result.First();
                Assert.Equal(15, firstResult.Id);
                Assert.Equal("Jd das Flores", firstResult.Bairro);
                Assert.Equal("Cidade Jardim", firstResult.Cidade);
                Assert.Equal("João", firstResult.Nome);
                Assert.Equal("Ipê", firstResult.NomeRua);
                Assert.Equal("19995958585", firstResult.Telefone);
                Assert.Equal(DateTime.Today, firstResult.Date);

                Assert.NotNull(firstResult.Pedidos);
                Assert.Equal(5, firstResult.Pedidos.First().Id);
                Assert.Equal(15, firstResult.Pedidos.First().PedidoEntregaId);
                Assert.Null(firstResult.Pedidos.First().PedidoRetiradaId);
                Assert.Equal(["Teste Guarnicao 3", "Teste Guarnicao 4"], firstResult.Pedidos.First().Guarnicao);
                Assert.Equal(["Teste Mistura 3", "Teste Mistura 4"], firstResult.Pedidos.First().Mistura);
                Assert.Equal("m", firstResult.Pedidos.First().Tamanho);
                Assert.Equal(20M, firstResult.Pedidos.First().Valor);

            }
        }

        [Fact]
        public async Task ListaPedidoEntregaHoje_QuandoVazia_DeveRretornarListaVazia()
        {
            var options = new DbContextOptionsBuilder<RestauranteContext>()
                        .UseInMemoryDatabase(databaseName: "DbListaPedidoEntregaHoje_Vazia")
                        .Options;

            using (var context = new RestauranteContext(options))
            {
                var service = new PedidoEntregaService(context);
                var result = await service.ListaPedidoEntregaHoje();

                Assert.Empty(result);
            }
        }
    }
}