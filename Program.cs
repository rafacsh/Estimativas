using System;
using Estimativas.Models;

namespace estimativas
{
    class Program
    {

        public static double LerValorDoubleInput()
        {
            double valorInput;

            if (!double.TryParse(Console.ReadLine(), out valorInput))
                throw new Exception("Valor digitado inválido!");

            return valorInput;
        }

        static void Main(string[] args)
        {
            Console.Title = "...::Estimativas::...";

            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Estimativas PERT + Desvio Padrão");
            Console.WriteLine("-----------------------------------------\n\n");

            Console.WriteLine("Informe o valor otimista:");

            double valorOtimista = LerValorDoubleInput();

            Console.WriteLine("Informe o valor mais provável:");
            double valorProvavel = LerValorDoubleInput();

            Console.WriteLine("Informe o valor pessimista:");
            double valorPessimista = LerValorDoubleInput();

            var pert = new Pert(valorOtimista, valorProvavel, valorPessimista);
            var desvioPadrao = new DesvioPadrao(valorOtimista, valorPessimista);

            pert.Validar();
            desvioPadrao.Validar();

            var valorPERT = pert.Calcular();
            var valorDV = desvioPadrao.Calcular();

            var resultadoTotal = valorPERT + valorDV;

            Console.WriteLine("\n----------------------------------------------------------------------------------");
            Console.WriteLine("PERT            = (O + 4 x MP + P) / 6   : " + valorPERT);
            Console.WriteLine("Desvio Padrão   = (P-O)/6)               : " + valorDV);
            Console.WriteLine("Resultado Total = (PERT + Desvio Padrão) : " + resultadoTotal);
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine("Desenvolvido por Rafael Catani Santa Helena");
            Console.WriteLine("----------------------------------------------------------------------------------\n");

            Console.ReadLine();
        }
    }
}
