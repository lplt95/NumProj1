using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumProjApp.Metody
{
    public class Rownanie
    {
        public int grade { get; set; }
        public double coef { get; set; }
        public Rownanie(){}
        public Rownanie(int _grade, double _coef)
        {
            grade = _grade;
            coef = _coef;
        }

        public Rownanie DifferentByX()
        {
            //pochodna z Ax^B = A*Bx^B-1
            int newGrade = grade - 1;
            double newCoef = coef * grade;
            return new Rownanie(newGrade, newCoef);
        }
    }
}
