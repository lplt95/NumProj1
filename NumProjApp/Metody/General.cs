using System;
using System.Collections.Generic;
using System.Text;

namespace NumProjApp.Metody
{
    public class General
    {
        protected double correction;
        protected int grade;
        protected Dictionary<int, double> wsp;
        protected KeyValuePair<double, double> range;
        public General(int _grade, double _correction, Dictionary<int, double> _wsp, KeyValuePair<double, double> _range)
        {
            correction = _correction;
            grade = _grade;
            wsp = _wsp;
            range = _range;
        }
    }
}
