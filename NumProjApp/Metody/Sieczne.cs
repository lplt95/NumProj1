using System;
using System.Collections.Generic;
using System.Text;

namespace NumProjApp.Metody
{
    class Sieczne : General
    {
        public Sieczne(int _grade, double _correction, Dictionary<int, double> _wsp, KeyValuePair<double, double> _range) : base(_grade, _correction, _wsp, _range)
        {

        }
        //example: x^3 + 2x^2 -3x + 4
        public double CalculateSolution(ref int loopCount)
        {
            double solution = Double.MinValue;//inicjacja zmiennej przechowującej ostateczne rozwiązanie
            bool correctionGained = false;//zmienna kontrolująca czy osiągnięto zadaną dokładność
            double rangeA = CalcFunction(range.Key);//wstępna kalkulacja wartości funkcji dla początku zakresu
            double rangeB = CalcFunction(range.Value);//wstępna kalkulacja wartości funkcji dla końca zakresu
            while(!correctionGained)//pętla wykonujaca obliczenia
            {
                double resA = CalcFunction(3);//wywołanie obliczenia wartości funkcji dla danego x
                //TODO: reszta obliczeń
                loopCount++;//zwiększenie wartości zmiennej kontrolującej kolejne iteracje pętli 
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
