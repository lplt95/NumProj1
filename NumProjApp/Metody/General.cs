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
        protected List<Rownanie> coefsList;
        public General(int _grade, double _correction, KeyValuePair<double, double> _range, List<Rownanie> _coefsList)
        {
            correction = _correction;
            grade = _grade;
            coefsList = _coefsList;
            range = _range;
        }
        protected double CalcFunction(double x)
        {
            double res = 0;
            /*foreach (var key in wsp)
            {
                int grade = key.grade;
                double xsqrt = Math.Pow(x, grade);
                res += xsqrt * key.coef;
            }*/
            return res;
        }
    }
}
