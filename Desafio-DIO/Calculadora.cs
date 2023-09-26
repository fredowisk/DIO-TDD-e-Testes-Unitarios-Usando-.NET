namespace Calculadora_DIO
{
    using System.Collections;

    public class Calculadora
    {
        private Queue<string> historico;

        public Calculadora()
        {
            historico = new List<string>();
        }

        private void atualizarHistorico(string mensagem)
        {
            if(historico.Count > 3) 
            {
                historico.Dequeue();
            }

            historico.Enqueue(mensagem);
        }

        public int somar(int num1, int num2)
        {
            int resultado = num1 + num2;

            atualizarHistorico($"Resultado: ${num1} + {num2} = {resultado}");
            return resultado;
        }

        public int subtrair(int num1, int num2)
        {
            int resultado = num1 - num2;

            atualizarHistorico($"Resultado: ${num1} - {num2} = {resultado}");
            return resultado;
        }

        public int multiplicar(int num1, int num2)
        {
            int resultado = num1 * num2;

            atualizarHistorico($"Resultado: ${num1} * {num2} = {resultado}");
            return resultado;
        }

        public float dividir(int num1, int num2)
        {
            if (num2 == 0)
            {
                throw new DivideByZeroException();
            }

            float resultado = (float)num1 / num2;

            atualizarHistorico($"Resultado: ${num1} / {num2} = {resultado}");

            return resultado;
        }

        public Queue<string> historico()
        {
            return Historico;
        }
    }
}
