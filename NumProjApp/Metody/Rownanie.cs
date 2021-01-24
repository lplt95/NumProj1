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
        public List<Monomial> monos { get; set; }
        public Rownanie(int _grade, List<Monomial> _monos)
        {
            grade = _grade;
            monos = _monos;
        }
        public Rownanie DifferentByX()
        {
            //pochodna z Ax^B = A*Bx^B-1
            List<Monomial> newMonos = new List<Monomial>();
            foreach(var mono in monos)
            {
                if(mono.grade == 0)
                {}
                else
                {
                    int newGrade = mono.grade - 1;
                    if (newGrade == 0)
                    {
                        newMonos.Add(new Monomial(0, mono.coef));
                    }
                    else
                    {
                        double newCoef = mono.coef * mono.grade;
                        newMonos.Add(new Monomial(newGrade, newCoef));
                    }
                }
            }
            return new Rownanie(grade - 1, newMonos);
        }
    }
}
