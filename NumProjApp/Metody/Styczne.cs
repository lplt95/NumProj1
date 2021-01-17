using System;
using System.Collections.Generic;
using System.Text;

namespace NumProjApp.Metody
{
    class Styczne : General
    {
        public Styczne(int _grade, double _correction, KeyValuePair<double, double> _range, Rownanie _row) : base(_grade, _correction, _range, _row)
        {

        }
        public double CalculateSolution(ref int loopCount)
        {
            double solution = Double.MinValue;//inicjacja zmiennej przechowującej ostateczne rozwiązanie
            loopCount = 0;//wyzerowanie zmiennej liczącej obroty pętli
            bool correctionGained = false;//zmienna kontrolująca czy osiągnięto zadaną dokładność
            double rangeCalcA = CalcFunction(range.Key, row);//wstępna kalkulacja wartości funkcji dla początku zakresu
            double rangeCalcB = CalcFunction(range.Value, row);//wstępna kalkulacja wartości funkcji dla końca zakresu
            if (rangeCalcA * rangeCalcB > 0) return Double.MaxValue;
            bool negative = CalcStartPoint();
            double rangeA = negative ? range.Key : range.Value;
            while (!correctionGained)//pętla wykonujaca obliczenia
            {
                var FirstDiff = row.DifferentByX();
                double calcFirstDiff = CalcFunction(rangeA, FirstDiff);
                double calcRow = CalcFunction(rangeA, row);
                double rangeC = rangeA - (calcRow / calcFirstDiff);
                double rangeCalcC = CalcFunction(rangeC, row);
                if (Math.Abs(rangeCalcC) < correction)
                {
                    correctionGained = true;//sprawdzenie czy osiągnięto zadaną dokładność
                }
                else
                {
                    rangeA = rangeC;
                }
                loopCount++;//zwiększenie wartości zmiennej kontrolującej kolejne iteracje pętli 
                //double zPoint = 
            }
            return solution;
        }
        private bool CalcStartPoint()
        {
            double z = (range.Key + range.Value) / 2;
            var FirstDiff = row.DifferentByX();
            double calcFirstDiff = CalcFunction(z, FirstDiff);
            var SecondDiff = FirstDiff.DifferentByX();
            double calcSecDiff = CalcFunction(z, SecondDiff);
            bool negative = (calcFirstDiff * calcSecDiff) < 0 ? true : false;
            return negative;
        }
    }
}
