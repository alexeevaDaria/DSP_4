﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSP_4
{
    public class SharpenFilter : ConvolutionFilterBase
    {
        public override string FilterName
        {
            get { return "SharpenFilter"; }
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
            new double[,] { { -1, -1, -1, },
                        { -1,  9, -1, },
                        { -1, -1, -1, }, };


        public override double[,] FilterMatrix
        {
            get { return filterMatrix; }
        }
    }
}
