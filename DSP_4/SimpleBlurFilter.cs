using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSP_4
{
    public class SimpleBlurFilter : ConvolutionFilterBase
    {
        public override string FilterName
        {
            get { return "Gaussian3x3BlurFilter"; }
        }


        private double factor = 1.0 / 15.0;
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
            new double[,]{ { 1, 2, 1},
                           { 2, 3, 2 },
                           { 1, 2, 1 }};


        public override double[,] FilterMatrix
        {
            get { return filterMatrix; }
        }
    }
}
