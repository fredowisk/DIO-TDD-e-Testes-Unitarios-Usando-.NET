using System;
using Xunit;
using Calculadora_DIO;

namespace CalculadoraTest
{
    public class CalculadoraTests
    {
         private readonly Calculadora _calculadora;
        public CalculadoraTests()
        {
            _calculadora = new Calculadora();
        }

        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(2, 2, 4)]
        [InlineData(-1, 1, 0)]
        [InlineData(1, 3, 4)]
        [InlineData(-10, -1, -11)]
        [InlineData(0, 0, 0)]
        public void SomaOsNumerosERetornaOResultado(int num1, int num2, int expected)
        {
            int result = _calculadora.somar(num1, num2);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1, 1, 0)]
        [InlineData(2, 2, 0)]
        [InlineData(-1, 1, -2)]
        [InlineData(1, 3, -2)]
        [InlineData(-10, -1, -9)]
        [InlineData(0, 0, 0)]
        public void SubtraiOsNumerosERetornaOResultado(int num1, int num2, int expected)
        {
            int result = _calculadora.subtrair(num1, num2);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(2, 2, 4)]
        [InlineData(-1, 1, -1)]
        [InlineData(1, 3, 3)]
        [InlineData(-10, -1, 10)]
        [InlineData(0, 0, 0)]
        public void MultiplicaOsNumerosERetornaOResultado(int num1, int num2, int expected)
        {
            int result = _calculadora.multiplicar(num1, num2);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(2, 2, 1)]
        [InlineData(-1, 1, -1)]
        [InlineData(1, 3, 0)]
        [InlineData(-10, -1, 10)]
        [InlineData(0, 10, 0)]
        public void DivideOsNumerosERetornaOResultadoParaUmInteiro(int num1, int num2, int expected)
        {
            int result = (int)_calculadora.dividir(num1, num2);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1, 0)]
        [InlineData(0, 0)]
        public void DividePor0(int num1, int num2)
        {
            Assert.Throws<DivideByZeroException>(() => _calculadora.dividir(num1, num2));
        }

        [Fact]
        public void Historico_apos5Operacoes_Retorna3resultados()
        {
            _calculadora.somar(1, 1); // Será apagado do histórico
            _calculadora.somar(2, 1); // Será apagado do histórico
            _calculadora.somar(3, 1); // Deverá ser o primeiro da fila
            _calculadora.somar(4, 1);
            _calculadora.somar(5, 1);

            Queue<string> result = _calculadora.historico();

            Assert.NotEmpty(result);
            Assert.Equal(3, result.Count);
            Assert.Equal("3 + 1 = 4", result.Dequeue());
            Assert.Equal("4 + 1 = 5", result.Dequeue());
            Assert.Equal("5 + 1 = 6", result.Dequeue());
            Assert.Empty(result);
        }

        [Fact]
        public void Historico_SemOperacoes_RetornaVazio()
        {
            Calculadora novaCalculadora = new Calculadora();

            Queue<string> result = novaCalculadora.historico();

            Assert.Empty(result);
        }
    }
}