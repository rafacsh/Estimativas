using System;
using Estimativas.Models.Interfaces;

namespace Estimativas.Models
{
    public class Pert : IEstimativa
    {
        private double ValorOtimista { get; set; }
        private double ValorMaisProvavel { get; set; }
        private double ValorPessimista { get; set; }

        public Pert(double valorOtimista, double valorMaisProvavel, double valorPessimista)
        {
            this.ValorOtimista = valorOtimista;
            this.ValorMaisProvavel = valorMaisProvavel;
            this.ValorPessimista = valorPessimista;
        }

        public double Calcular()
            => Math.Round(((this.ValorOtimista + 4.0 * this.ValorMaisProvavel + this.ValorPessimista) / 6.0), 2);

        public void Validar()
        {
            if (this.ValorMaisProvavel == 0 || this.ValorOtimista == 0 || this.ValorPessimista == 0)
                throw new Exception("Valores não podem ser zerados!");

            if (this.ValorPessimista < this.ValorMaisProvavel || this.ValorPessimista < this.ValorOtimista)
                throw new Exception("Valor pessimista deve ser maior que os outros valores!");

            if (this.ValorOtimista > this.ValorMaisProvavel || this.ValorOtimista > this.ValorPessimista)
                throw new Exception("Valor otimista deve ser menor que os outros valores!");
        }
    }
}