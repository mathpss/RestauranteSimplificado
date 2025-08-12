using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using Xunit;

namespace backnd.Tests.Models.Tests
{
    public class PedidoTest
    {
        [Fact]
        public void TestSetGetProperties_Entrega()
        {
            var modelPedidoExpected = new Pedido
            {
                Id = 1,
                Tamanho = "p",
                Valor = 17M,
                PedidoEntregaId = 11,
                PedidoRetiradaId = null,
                Mistura = ["Teste Mistura 1", "Teste Mistura 2"],
                Guarnicao = ["Teste Guarnicao 1", "Teste Guarnicao 2"]
            };

            Assert.Equal(1, modelPedidoExpected.Id);
            Assert.Equal("p", modelPedidoExpected.Tamanho);
            Assert.Equal(17M, modelPedidoExpected.Valor);
            Assert.Equal(11, modelPedidoExpected.PedidoEntregaId);
            Assert.Null(modelPedidoExpected.PedidoRetiradaId);
            Assert.Equal(["Teste Mistura 1", "Teste Mistura 2"], modelPedidoExpected.Mistura);
            Assert.Equal(["Teste Guarnicao 1", "Teste Guarnicao 2"], modelPedidoExpected.Guarnicao);


        }

        [Fact]
        public void TestSetGetProperties_Retirada()
        {
            var modelPedidoExpected = new Pedido
            {
                Id = 5,
                Tamanho = "m",
                Valor = 20M,
                PedidoEntregaId = null,
                PedidoRetiradaId = 15,
                Mistura = ["Teste Mistura 3", "Teste Mistura 4"],
                Guarnicao = ["Teste Guarnicao 3", "Teste Guarnicao 4"]
            };

            Assert.Equal(5, modelPedidoExpected.Id);
            Assert.Equal("m", modelPedidoExpected.Tamanho);
            Assert.Equal(20M, modelPedidoExpected.Valor);
            Assert.Equal(15, modelPedidoExpected.PedidoRetiradaId);
            Assert.Null(modelPedidoExpected.PedidoEntregaId);
            Assert.Equal(["Teste Mistura 3", "Teste Mistura 4"], modelPedidoExpected.Mistura);
            Assert.Equal(["Teste Guarnicao 3", "Teste Guarnicao 4"], modelPedidoExpected.Guarnicao);

        }
    }
}