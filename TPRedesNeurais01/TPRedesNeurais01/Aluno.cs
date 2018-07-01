using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPRedesNeurais01
{
    public class Aluno
    {
        public double idade;
        public double tempoEstudo;
        public double faltas;
        public double prova1;
        public double prova2;
        public double prova3;
        public bool aprovado;

        public Aluno(double idade, double tempoEstudo, double faltas, double prova1, double prova2, double prova3)
        {
            this.idade = idade;
            this.tempoEstudo = tempoEstudo;
            this.faltas = faltas;
            this.prova1 = prova1;
            this.prova2 = prova2;
            this.prova3 = prova3;

            this.aprovado = false;
        }

    }
}
