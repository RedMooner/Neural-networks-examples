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
            public void Train(double readl_output,double alpha)
            {
                for (int i = 0; i <= 20; i++)
                {
                    double prediction = ProccessInputData();
                    double error = Math.Pow((prediction - readl_output), 2);
                    double direction_and_amount = (prediction - readl_output) * inputs[0];
                    weights = weights.Select(x => x - direction_and_amount * alpha).ToArray();
                    Console.WriteLine("Error:" + error + "\tWeights: " + string.Join(",", weights) + "\t Prediction: " + prediction);
                }
            }
            static void Main(string[] args)
            {
                double[] inp = { 5 };
                double[] weights = { 1 };
                Neuron neuron = new Neuron(inp, weights);
                neuron.Train(4.0,0.01);
                Console.Read();
            }
        }
    }
}
