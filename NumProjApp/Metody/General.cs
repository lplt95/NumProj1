using System;
using System.Collections.Generic;
using System.Text;

namespace NumProjApp.Metody
{
    public class General
    {
        protected double correction;
        protected int grade;
        protected KeyValuePair<double, double> range;
        protected Rownanie row;
        public General(int _grade, double _correction, KeyValuePair<double, double> _range, Rownanie _row)
        {
            correction = _correction;
            grade = _grade;
            row = _row;
            range = _range;
        }
        protected double CalcFunction(double x, Rownanie rowToCalc)
        {
            double res = 0;
            foreach (var mono in rowToCalc.monos)
            {
                int grade = mono.grade;
                double xsqrt = Math.Pow(x, grade);
                res += xsqrt * mono.coef;
            }
            return res;
        }
    }
}
