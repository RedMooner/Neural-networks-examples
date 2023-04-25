using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class Program
    {
        public class Neuron
        {
            public double[] inputs;
            public double[] weights { get; private set; }

            public Neuron(double[] inputs, double[] weights)
            {
                this.inputs = inputs;
                this.weights = weights;
            }
            public double ProccessInputData()
            {
                double prediction = 0;
                for (int i = 0; i < inputs.Length; i++)
                    prediction += inputs[i] * weights[i];
                return prediction;
            }
            public void Train(double alpha, double readl_output)
            {
                for (int i = 0; i <= 3; i++)
                {
                    double prediction = ProccessInputData();
                    if (prediction > readl_output)
                        weights = weights.Select(x => (x - alpha)).ToArray();
                    else if (prediction < readl_output)
                        weights = weights.Select(x => (x + alpha)).ToArray();
                    Console.WriteLine("Weights: " + string.Join(",", weights) + "\t Prediction: " + prediction);
                }
            }
            static void Main(string[] args)
            {
                double[] inp = { 5 };
                double[] weights = { 1 };
                Neuron neuron = new Neuron(inp, weights);
                neuron.Train(0.1,4);
                Console.Read();
            }
        }
    }
}