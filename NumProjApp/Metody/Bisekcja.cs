using System;
using System.Collections.Generic;
using System.Text;

namespace NumProjApp.Metody
{
    class Bisekcja : General
    {
        public Bisekcja(int _grade, double _correction, KeyValuePair<double, double> _range, Rownanie _row) : base(_grade, _correction, _range, _row)
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
            double rangeA = range.Key;
            double rangeB = range.Value;
            while (!correctionGained)//pętla wykonujaca obliczenia
            {
                loopCount++;//zwiększenie wartości zmiennej kontrolującej kolejne iteracje pętli
                double rangeC = (rangeA + rangeB) / 2;//średnia arytmetyczna z końców przedziału, punkt C
                double rangeCalcC = CalcFunction(rangeC, row);//wyliczenie wartości funkcji w punkcie C
                if (Math.Abs(rangeCalcC) < correction)
                {
                    solution = Math.Round(rangeC, 3);
                    correctionGained = true;//sprawdzenie czy osiągnięto zadaną dokładność
                }
                if (rangeCalcA * rangeCalcC < 0)//sprawdzenie czy wartości funkcji mają przeciwne znaki
                {
                    rangeCalcB = rangeCalcC;//jeśli tak, przypisz wartość C do B
                    rangeB = rangeC;
                }
                else
                {
                    rangeCalcA = rangeCalcC;//jeśli nie, przypisz wartość C do A
                    rangeA = rangeC;
                }
            }
            return solution;
        }
    }
}
