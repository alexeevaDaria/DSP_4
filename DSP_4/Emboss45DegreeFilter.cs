﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSP_4
{
    public class Emboss45DegreeFilter : ConvolutionFilterBase
    {
        public override string FilterName
        {
            get { return "Emboss45DegreeFilter"; }
        }


        private double factor = 1.0;
        public override double Factor
        {
            get { return factor; }
        }


        private double bias = 128.0;
        public override double Bias
        {
            get { return bias; }
        }


        private double[,] filterMatrix =
            new double[,] { { -1, -1,  0, },
                        { -1,  0,  1, },
                        {  0,  1,  1, }, };


        public override double[,] FilterMatrix
        {
            get { return filterMatrix; }
        }
    }
}
