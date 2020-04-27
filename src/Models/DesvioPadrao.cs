using System;
using Estimativas.Models.Interfaces;

namespace Estimativas.Models
{
    public class DesvioPadrao : IEstimativa
    {
        private double ValorOtimista { get; set; }
        private double ValorPessimista { get; set; }

        public DesvioPadrao(double valorOtimista, double valorPessimista)
        {
            this.ValorOtimista = valorOtimista;
            this.ValorPessimista = valorPessimista;
        }

        public double Calcular()
            => Math.Round(((this.ValorPessimista - this.ValorOtimista) / 6.0), 2);

        public void Validar()
        {
            if (this.ValorOtimista > this.ValorPessimista)
                throw new Exception("Valor otimista deve ser menor que o valor pessimista!");
        }
    }
}