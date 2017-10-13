using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepLearningTest
{
    public class Sigmoid
    {
        private List<Tuple<double, Sigmoid>> _entries;

        private double _biases;
        private double _output;


        public Sigmoid(List<Sigmoid> entries)
        {
            _entries = entries?.Select(sig => new Tuple<double, Sigmoid>(RandomHelper.NextDouble(), sig)).ToList();
            _biases = RandomHelper.NextDouble();
        }


        public double Output
        {
            get
            {
                if (_entries == null)
                    return _output;

                var sum = -(_entries.Sum(e => e.Item1 * e.Item2.Output) - _biases);

                //Debug.WriteLine(sum / _entries.Count);
                return SigmoidFunction(sum);

            }
            set
            {
                if (_entries != null)
                    throw new InvalidOperationException();
                _output = value;
            }
        }

        public double Biases
        {
            get { return _biases; }
            set { _biases = value; }
        }

        public double[] Weights
        {
            get { return _entries.Select(e => e.Item1).ToArray(); }
        }


        private double SigmoidFunction(double z)
        {
            return 1.0 / (1.0 + Math.Exp(-z));
        }


    }
}
