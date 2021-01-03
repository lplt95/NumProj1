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
        public General(int _grade, double _correction, Dictionary<int, double> _wsp)
        {
            correction = _correction;
            grade = _grade;
            wsp = _wsp;
        }
    }
}
