using System;
using System.Collections.Generic;
using System.Text;

namespace NumProjApp.Metody
{
    class Bisekcja : General
    {
        public Bisekcja(int _grade, double _correction, Dictionary<int, double> _wsp, KeyValuePair<double, double> _range) : base(_grade, _correction, _wsp, _range)
        {

        }
        public double CalculateSolution(ref int loopCount)
        {
            double solution = Double.MinValue;//inicjacja zmiennej przechowującej ostateczne rozwiązanie
            bool correctionGained = false;//zmienna kontrolująca czy osiągnięto zadaną dokładność
            double rangeCalcA = CalcFunction(range.Key);//wstępna kalkulacja wartości funkcji dla początku zakresu
            double rangeCalcB = CalcFunction(range.Value);//wstępna kalkulacja wartości funkcji dla końca zakresu
            if (rangeCalcA * rangeCalcB > 0) return Double.MaxValue;
            double rangeA = range.Key;
            double rangeB = range.Value;
            while (!correctionGained)//pętla wykonujaca obliczenia
            {
                loopCount++;//zwiększenie wartości zmiennej kontrolującej kolejne iteracje pętli
                double rangeC = (rangeA + rangeB) / 2;//średnia arytmetyczna z końców przedziału, punkt C
                double rangeCalcC = CalcFunction(rangeC);//wyliczenie wartości funkcji w punkcie C
                if (Math.Abs(rangeCalcC) < correction) correctionGained = true;//sprawdzenie czy osiągnięto zadaną dokładność
                if (rangeCalcA * rangeCalcC < 0)
                {
                    rangeCalcB = rangeCalcC;
                    rangeB = rangeC;
                }
                else
                {
                    rangeCalcA = rangeCalcC;
                    rangeA = rangeC;
                }
            }
            return solution;
        }
        private double CalcFunction(double x)
        {
            double res = 0;
            foreach(var key in wsp)
            {
                int grade = key.Key;
                double xsqrt = Math.Pow(x, grade);
                res += xsqrt * key.Value;
            }
            return res;
        }
    }
}
