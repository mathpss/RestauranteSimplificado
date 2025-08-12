using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using Xunit;

namespace backnd.Tests.Models.Tests
{
    public class PedidoRetiradaTest
    {
        private readonly Pedido _pedidoExpected;

        public PedidoRetiradaTest()
        {
            _pedidoExpected = new()
            {
                Id = 3,
                Tamanho = "g",
                Valor = 22M,
                PedidoEntregaId = null,
                PedidoRetiradaId = 12,
                Mistura = ["Teste Mistura 1", "Teste Mistura 55"],
                Guarnicao = ["Teste Guarnicao 36", "Teste Guarnicao 12"]
            };
        }

        [Fact]
        public void TestSetGetProperties()
        {
            var modelPedidoRetiradaExpected = new PedidoRetirada
            {
                Id = 6,
                Nome = "Artemis",
                Telefone = "19993934747",
                Pedidos = [_pedidoExpected]
            };

            Assert.Equal(6, modelPedidoRetiradaExpected.Id);
            Assert.Equal("Artemis", modelPedidoRetiradaExpected.Nome);
            Assert.Equal("19993934747", modelPedidoRetiradaExpected.Telefone);
            Assert.Equal([_pedidoExpected], modelPedidoRetiradaExpected.Pedidos);

        }
    }
}