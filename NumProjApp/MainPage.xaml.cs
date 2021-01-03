using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using NumProjApp.Metody;

//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x415

namespace NumProjApp
{
    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        int grade = 0;
        public MainPage()
        {
            this.InitializeComponent();
            
            for(int x = 0; x<8; x++)
            {
                cbGrade.Items.Add(x);
            }
            //cbCorrection.Items.Add(null);
            cbCorrection.Items.Add(0.1);
            cbCorrection.Items.Add(0.01);
            cbCorrection.Items.Add(0.001);
            cbCorrection.Items.Add(0.0001);
            cbType.Items.Add("");
            cbType.Items.Add("Metoda Bisekcji");
            cbType.Items.Add("Metoda Siecznych");
            cbType.Items.Add("Metoda Stycznych");
            cbGrade.SelectedIndex = 0;
            cbCorrection.SelectedIndex = 0;
            HideAllGrids();
        }

        private void cbGrade_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            grade = (int)cbGrade.SelectedItem;
            GridVisibility(grade);
        }
        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            var coefs = ReadCoef(grade);
            double solution = Double.NaN;
            int loopCount = 0;
            switch((string)cbType.SelectedItem)
            {
                case "Metoda Bisekcji":
                    Bisekcja biMethod = new Bisekcja(grade, 0, coefs);
                    //TODO: calc on bisekcja
                    break;
                case "Metoda Siecznych":
                    Sieczne sieczneMethod = new Sieczne(grade, 0, coefs);
                    solution = sieczneMethod.CalculateSolution(ref loopCount);
                    break;
                case "Metoda Stycznych":
                    //TODO: whole class and logic
                    break;
            }

        }
        #region GridsPrivateMethods
        private void GridVisibility(int grade)
        {
            HideAllGrids();
            if (grade >= 1)
                GridA.Visibility = Visibility.Visible;
            if (grade >= 2)
                GridB.Visibility = Visibility.Visible;
            if (grade >= 3)
                GridC.Visibility = Visibility.Visible;
            if (grade >= 4)
                GridD.Visibility = Visibility.Visible;
            if (grade >= 5)
                GridE.Visibility = Visibility.Visible;
            if (grade >= 6)
                GridF.Visibility = Visibility.Visible;
            if (grade == 7)
                GridG.Visibility = Visibility.Visible;

        }
        private void HideAllGrids()
        {
            GridA.Visibility = Visibility.Collapsed;
            GridB.Visibility = Visibility.Collapsed;
            GridC.Visibility = Visibility.Collapsed;
            GridD.Visibility = Visibility.Collapsed;
            GridE.Visibility = Visibility.Collapsed;
            GridF.Visibility = Visibility.Collapsed;
            GridG.Visibility = Visibility.Collapsed;
        }
        private Dictionary<int, double> ReadCoef(int grade)
        {
            Dictionary<int, double> coefKeys = new Dictionary<int, double>();
            if (grade >= 1)
                coefKeys.Add(1, Double.Parse(tbcoef1.Text));
            if (grade >= 2)
                coefKeys.Add(2, Double.Parse(tbcoef2.Text));
            if (grade >= 3)
                coefKeys.Add(3, Double.Parse(tbcoef3.Text));
            if (grade >= 4)
                coefKeys.Add(4, Double.Parse(tbcoef4.Text));
            if (grade >= 5)
                coefKeys.Add(5, Double.Parse(tbcoef5.Text));
            if (grade >= 6)
                coefKeys.Add(6, Double.Parse(tbcoef6.Text));
            if (grade == 7)
                coefKeys.Add(7, Double.Parse(tbcoef7.Text));
            return coefKeys;
        }
        #endregion
    }
}
