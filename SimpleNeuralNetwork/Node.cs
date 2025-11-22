using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNeuralNetwork
{
    public class Node
    {
        public Dictionary<Node, double> InputNodes { get; set; } = new Dictionary<Node, double>();
        public double Result { get; set; } 

        public Func<double,double> Sigmoid { get; set; }

        public Node(Func<double,double> sigmoid, double result = 0)
        {
            this.Sigmoid = sigmoid;
            this.Result = result;
        }

        public void AddInputNode(Node node)
        {
            InputNodes.Add(node, 0.00001);
        }

        public void CalcNode()
        {
            foreach(var valuePair in InputNodes)
            {
                var node = valuePair.Key;
                var weight = valuePair.Value;
                this.Result += node.Sigmoid(weight * node.Result);
                if(double.IsNaN(this.Result) || double.IsInfinity(this.Result) || double.IsNegativeInfinity(this.Result))
                {
                    throw new Exception("Bad result!"); 
                }
            }
            Result = Result/Math.Max(1,InputNodes.Count);
        }
    }
}
