using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepLearningTest
{
    public class Network
    {
        private List<List<Sigmoid>> _layers;
        public Network(List<int> sizes)
        {
            _layers = new List<List<Sigmoid>>();

            for (int i = 0; i < sizes.Count; i++)
            {
                var size = sizes[i];
                var layer = new List<Sigmoid>();
                for (int j = 0; j < size; j++)
                    layer.Add(new Sigmoid(i == 0 ? null : _layers[i - 1]));
                _layers.Add(layer);
            }
        }

        public IEnumerable<double> Compute(List<double> inputs)
        {
            for (int i = 0; i < _layers[0].Count; i++)
            {
                var sigmoid = _layers[0][i];
                sigmoid.Output = inputs[i];
            }

            return _layers.Last().Select(sigmoid => sigmoid.Output);
        }

        public void Train(List<Tuple<int, List<double>>> trainingData, int epochs, int miniBatchSize, double learningRate)
        {
            var trainingDataLength = trainingData.Count;
            for (int j = 0; j < epochs; j++)
            {
                var miniBatches = trainingData.Skip(RandomHelper.Next(0, trainingDataLength - miniBatchSize)).Take(miniBatchSize);
                foreach (var minibatch in miniBatches)
                {
                    UpdateMiniBatch(minibatch, learningRate);
                }
            }
        }

        private void UpdateMiniBatch(Tuple<int, List<double>> minibatch, double learningRate)
        {

        }

        private double[] Biases
        {
            get { return _layers.SelectMany(l => l).Select(s => s.Biases).ToArray(); }
        }
        private double[][] Weights
        {
            get { return _layers.SelectMany(l => l).Select(s => s.Weights).ToArray(); }
        }
    }
}
