using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace DSP_4
{
    public abstract class ConvolutionFilterBase
    {
        public abstract string FilterName
        {
            get;
        }


        public abstract double Factor
        {
            get;
        }
        //In some instances when the sum total of matrix values do not equate to 1 
        //    a filter might implement a Factor value other than the default of 1. 
        //    Additionally some filters may also require a Bias value to be added 
        //    the final result value when calculating the matrix.

        public abstract double Bias
        {
            get;
        }


        public abstract double[,] FilterMatrix
        {
            get;
        }

 
    }
}
