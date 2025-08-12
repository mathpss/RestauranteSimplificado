using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using Xunit;

namespace backnd.Tests.Models.Tests
{
    public class PedidoEntregaTest
    {
        private readonly Pedido _pedidoExpected;
        public PedidoEntregaTest()
        {
            _pedidoExpected = new()
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
        public void TestSetGetProperties()
        {
            var modelPedidoEntregaExpected = new PedidoEntrega
            {
                Id = 2,
                Bairro = "Jd das Flores",
                Cidade = "Cidade Jardim",
                Nome = "João",
                NomeRua = "Ipê",
                NumeroRua = "19",
                Telefone = "19995958585",
                Date = DateTime.Today,
                Pedidos = [_pedidoExpected]

            };

            Assert.Equal(2, modelPedidoEntregaExpected.Id);
            Assert.Equal("Jd das Flores", modelPedidoEntregaExpected.Bairro);
            Assert.Equal("Cidade Jardim", modelPedidoEntregaExpected.Cidade);
            Assert.Equal("João", modelPedidoEntregaExpected.Nome);
            Assert.Equal("Ipê", modelPedidoEntregaExpected.NomeRua);
            Assert.Equal("19995958585", modelPedidoEntregaExpected.Telefone);
            Assert.Equal(DateTime.Today, modelPedidoEntregaExpected.Date);
            Assert.Equal([_pedidoExpected], modelPedidoEntregaExpected.Pedidos);

        }
    }
}