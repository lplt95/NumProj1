using System;
using System.Collections.Generic;
using System.Text;

namespace NumProj1
{
    class Sieczne : General
    {
        public Sieczne(int _grade, double _correction, double [] _wsp) : base(_grade, _correction, _wsp)
        {

        }
        //example: x^3 + 2x^2 -3x + 4
        public double CalculateSolution()
        {
            double solution = Double.MinValue;
            bool correctionGained = false;
            while(!correctionGained)
            {
                double resA = CalcFunction(3);
            }
            return solution;
        }
        private double CalcFunction(double x)
        {
            double res = 0;
            return res;
        }
    }
}
