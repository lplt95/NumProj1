using System;
using System.Collections.Generic;
using System.Text;

namespace NumProj1
{
    public class General
    {
        protected double correction;
        protected int grade;
        protected double[] wsp;
        public General(int _grade, double _correction, double [] _wsp)
        {
            correction = _correction;
            grade = _grade;
            wsp = _wsp;
        }
    }
}
