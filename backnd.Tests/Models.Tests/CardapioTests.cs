using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using Xunit;

namespace backnd.Tests.Models.Tests
{
    public class CardapioTests
    {
        [Fact]
        public void TestGetSetPropriedades()
        {
            //Arrange
            var modelCardapioExpected = new Cardapio
            {
                //Act
                Id = 1,
                Guarnicao = "teste da guarnicao",
                Mistura = "teste da mistura"
            };

            //Assert

            Assert.Equal(1, modelCardapioExpected.Id);
            Assert.Equal("teste da guarnicao", modelCardapioExpected.Guarnicao);
            Assert.Equal("teste da mistura", modelCardapioExpected.Mistura);
        }

        [Theory]
        [InlineData("Primeiro teste")]
        [InlineData("Segundo Teste")]
        [InlineData("Terceiro Teste")]
        [InlineData("Quarto Teste")]
        public void TestGetSetPropriedadesTheory(string value)
        {
            var modelCardapioExpected = new Cardapio
            {
                Id = 1,
                Guarnicao = value,
                Mistura = value
            };

            Assert.Equal(1, modelCardapioExpected.Id);
            Assert.Equal(value, modelCardapioExpected.Guarnicao);
            Assert.Equal(value, modelCardapioExpected.Mistura);
        }
    }
}