using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Encog.Neural;
using Encog.Neural.Networks;
using Encog.Neural.Networks.Training;
using Encog.Neural.Networks.Layers;
using Encog.Neural.Networks.Training.Propagation;
using Encog.Neural.Networks.Training.Propagation.Back;
using Encog.ML.Data.Basic;
using Encog.ML.Data;
//using Encog.ML.Data;

namespace TPRedesNeurais01
{
    public  class Program
    {
        public static void Main(string[] args)
        {
            List<Aluno> Alunos = new List<Aluno>();
            Alunos = Util.InitilizeAlunos();

            double[] TempoEstudo = new double[650];
            double[] Idade = new double[650];
            double[] Faltas = new double[650];

            for(int i=0; i < 650; i++)
            {
                Alunos.ToArray();
                Aluno a = Alunos[i];

                Idade[i] = a.idade;
                TempoEstudo[i] = a.tempoEstudo;
                Faltas[i] = a.faltas;
            }

            //for (int i = 0; i < 650; i++)
            //{
            //    Console.WriteLine("Idade: " + Idade[i] +
            //                      " TempoEstudo: " + TempoEstudo[i] +
            //                      " Faltas: " + Faltas[i]
            //                      + "   " + i

            //                     );
            //}
            //Console.ReadKey();

            double[][] x =      //Entrada
            {
                //new double []{0.0, 0.0},
                //new double []{0.5, 0.5},
                //new double []{0.3}
                Idade,
                TempoEstudo,
                Faltas
            };

            double[][] y =      //Ideals
            {
                new double []{16},      //Anos
                new double []{4},       //TempoEstudo
                new double []{0}       //Faltas
            };

            BasicNetwork network = new BasicNetwork();      //Instancia da rede neural
            network.AddLayer(new BasicLayer(3));            //Camada inicial que recebe as 3 entradas: Idade, tempo de estudo e falta
            network.AddLayer(new BasicLayer(2));
            network.AddLayer(new BasicLayer(1));

            network.Structure.FinalizeStructure();  //Finaliza a rede neural
            network.Reset();                        //Deixa random o peso da rede neural

            BasicMLDataSet dataset = new BasicMLDataSet(x, y);      //Conjunto de dados pra usar na rede neural


            //Classe que faz o treinamento da rede
            Backpropagation propagation = new Backpropagation(network, dataset, 0.4, 0.12);     //Taxa de aprendizado é o 0.4

            int epoch = 0;

            while (true)
            {
                propagation.Iteration();
                Console.WriteLine("Época: {0} -> Erro: {1}", epoch, propagation.Error);
                epoch++;

                if (epoch > 1000 || propagation.Error < 0.00001) break;     //Qntd maxima de epocas: 1000 
            }


            foreach(IMLDataPair d in dataset)
            {
                IMLData o = network.Compute(d.Input);

                Console.WriteLine("Saida: {0} -> Ideal: {1}", o.ToString(), d.Input[0]);
            }

            Console.ReadKey();

        }

    }
}
