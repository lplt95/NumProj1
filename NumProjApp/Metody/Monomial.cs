using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumProjApp.Metody
{
    public class Monomial
    {
        public int grade { get; set; }
        public double coef { get; set; }
        public Monomial() { }
        public Monomial(int _grade, double _coef)
        {
            grade = _grade;
            coef = _coef;
        }
    }
}
