using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSP_4
{
    public class SimpleEdgeDetectionFilter : ConvolutionFilterBase
    {
        public override string FilterName
        {
            get { return "EdgeDetectionFilter"; }
        }


        private double factor = 1.0;
        public override double Factor
        {
            get { return factor; }
        }


        private double bias = 0.0;
        public override double Bias
        {
            get { return bias; }
        }


        private double[,] filterMatrix =
            new double[,] { {0, -1, 0 },
                            {-1, 4, -1 },
                            {0, -1, 0 }};


        public override double[,] FilterMatrix
        {
            get { return filterMatrix; }
        }
    }
}
