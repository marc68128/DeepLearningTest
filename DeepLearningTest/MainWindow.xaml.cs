using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Accord.Math;
using Matrix = Accord.Math.Matrix;
using Vector = Accord.Math.Vector;

namespace DeepLearningTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Network n = new Network(new List<int> { 784, 30, 10 });
            var input = new List<double>();
            for (int i = 0; i < 784; i++)
                input.Add(RandomHelper.NextDouble());
            
            var res = n.Compute(input).ToList();

            double[] vector1 = { 1, 2, 3 };
            double[] vector2 = { 3, 4, 5 };
            var resu = vector1.Dot(vector2);
    
        }
    }
}
