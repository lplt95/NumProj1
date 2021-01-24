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
using Windows.UI.Popups;
using Windows.System;
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
        private async void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())//metoda służąca do sprawdzenia, czy pola nie są puste
            {
                List<Monomial> coefs = new List<Monomial>();
                KeyValuePair<double, double> range;
                double correction;
                try
                {
                    coefs = ReadCoef(grade);//odczyt współczynników
                    range = ReadRange();//odczyt zakresu działań
                    correction = (double)cbCorrection.SelectedItem;//odczyt dokładności
                }
                catch (ArgumentNullException nullExc)//obsłużenie błędu z pustymi polami
                {
                    string error = "Wygląda na to, że wystąpił błąd:\n";
                    await new MessageDialog(error + nullExc.Message).ShowAsync();
                    return;
                }
                catch (FormatException formatExc)//obsłużenie błędu z niepoprawnymi danymi w polach
                {
                    string error = "Wygląda na to, że wystąpił błąd:\n";
                    await new MessageDialog(error + formatExc.Message).ShowAsync();
                    return;
                }
                Rownanie row = new Rownanie(grade, coefs);
                double solution = Double.NaN;
                int loopCount = 0;//ta zmienna posłuży do kontrolowania ilości przebiegów pętli
                switch ((string)cbType.SelectedItem)
                {
                    case "Metoda Bisekcji":
                        Bisekcja biMethod = new Bisekcja(grade, correction, range, row);
                        solution = biMethod.CalculateSolution(ref loopCount);
                        break;
                    case "Metoda Siecznych":
                        Sieczne sieczneMethod = new Sieczne(grade, correction, range, row);
                        solution = sieczneMethod.CalculateSolution(ref loopCount);
                        break;
                    case "Metoda Stycznych":
                        Styczne styczneMethod = new Styczne(grade, correction, range, row);
                        solution = styczneMethod.CalculateSolution(ref loopCount);
                        break;
                }
                if(solution == Double.MaxValue)
                {
                    string message = "Podany przedział nie zawiera miejsc zerowych";
                    await new MessageDialog(message).ShowAsync();
                    return;
                }
                tbItCount.Text = loopCount.ToString();
                tbSolution.Text = solution.ToString();
                SolutionGrid.Visibility = Visibility.Visible;
            }
            else
            {
                string message = "Wygląda na to, że niektóre pola są niewypełnione.\nPopraw dane i spróbuj jeszcze raz.";
                await new MessageDialog(message).ShowAsync();
            }
        }
        #region GridsPrivateMethods
        private void GridVisibility(int grade)//ta metoda służy do ustawienia widoczności pól pozwalających wprowadzać dane o współczynnikach
        {
            HideAllGrids();

            if (grade >= 1)
            {
                spx0.Visibility = Visibility.Visible;
                spx1.Visibility = Visibility.Visible;
            }
            if (grade >= 2)
                spx2.Visibility = Visibility.Visible;
            if (grade >= 3)
                spx3.Visibility = Visibility.Visible;
            if (grade >= 4)
                spx4.Visibility = Visibility.Visible;
            if (grade >= 5)
                spx5.Visibility = Visibility.Visible;
            if (grade >= 6)
                spx6.Visibility = Visibility.Visible;
            if (grade == 7)
                spx7.Visibility = Visibility.Visible;

        }
        private void HideAllGrids()//ta metoda resetuje widoczność wszystkich pól do współczynników
        {
            spx0.Visibility = Visibility.Collapsed;
            spx1.Visibility = Visibility.Collapsed;
            spx2.Visibility = Visibility.Collapsed;
            spx3.Visibility = Visibility.Collapsed;
            spx4.Visibility = Visibility.Collapsed;
            spx5.Visibility = Visibility.Collapsed;
            spx6.Visibility = Visibility.Collapsed;
            spx7.Visibility = Visibility.Collapsed;
            SolutionGrid.Visibility = Visibility.Collapsed;
        }
        private List<Monomial> ReadCoef(int grade)//ta metoda służy do bezpośredniego zczytywania współczynników, w zależności od stopnia równania
        {
            List<Monomial> coefList = new List<Monomial>();
            if (grade >= 1)
            {
                if (String.IsNullOrWhiteSpace(tbx1.Text)) throw new ArgumentNullException();
                else if (String.IsNullOrWhiteSpace(tbx0.Text)) throw new ArgumentNullException();
                else
                {
                    coefList.Add(new Monomial(0, Double.Parse(tbx0.Text)));
                    coefList.Add(new Monomial(1, Double.Parse(tbx1.Text)));
                }
            }
            if (grade >= 2)
            {
                if (String.IsNullOrWhiteSpace(tbx2.Text)) throw new ArgumentNullException();
                else coefList.Add(new Monomial(2, Double.Parse(tbx2.Text)));
            }
            if (grade >= 3)
            {
                if (String.IsNullOrWhiteSpace(tbx3.Text)) throw new ArgumentNullException();
                else coefList.Add(new Monomial(3, Double.Parse(tbx3.Text)));
            }
            if (grade >= 4)
            {
                if (String.IsNullOrWhiteSpace(tbx4.Text)) throw new ArgumentNullException();
                else coefList.Add(new Monomial(4, Double.Parse(tbx4.Text)));
            }
            if (grade >= 5)
            {
                if (String.IsNullOrWhiteSpace(tbx5.Text)) throw new ArgumentNullException();
                else coefList.Add(new Monomial(5, Double.Parse(tbx5.Text)));
            }
            if (grade >= 6)
            {
                if (String.IsNullOrWhiteSpace(tbx6.Text)) throw new ArgumentNullException();
                else coefList.Add(new Monomial(6, Double.Parse(tbx6.Text)));
            }
            if (grade == 7)
            {
                if (String.IsNullOrWhiteSpace(tbx7.Text)) throw new ArgumentNullException();
                else coefList.Add(new Monomial(7, Double.Parse(tbx7.Text)));
            }
            return coefList;
        }
        private KeyValuePair<double, double> ReadRange()//ta metoda służy do odczytania zakresu obliczeń
        {
            double range1 = Double.Parse(tbRange1.Text);
            double range2 = Double.Parse(tbRange2.Text);
            KeyValuePair<double, double> ranges;
            if (range1 < range2)
            {
                ranges = new KeyValuePair<double, double>(range1, range2);
            }
            else
            {
                ranges = new KeyValuePair<double, double>(range2, range1);
            }
            return ranges;
        }
        #endregion
        #region ValidationMethods
        private bool Validate()//metoda walidacyjna - sprawdza czy poszczególne pola mają wprowadzone wartości, warunek konieczny do rozpoczęcia dalszych działań
        {
            bool isValid = true;
            if (String.IsNullOrWhiteSpace(tbRange1.Text) || String.IsNullOrWhiteSpace(tbRange2.Text))
                isValid = false;
            if (cbCorrection.SelectedItem == null)
                isValid = false;
            if (cbGrade.SelectedItem == null || (int)cbGrade.SelectedItem == 0)
                isValid = false;
            return isValid;
        }
        private async void BeforeTextChanging(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = IsCancelled(args.NewText);//args.NewText.Any(c => !char.IsDigit(c));
            if(args.Cancel)
            {
                string error = "Musisz wprowadzić liczbę";
                await new MessageDialog(error).ShowAsync();
            }
        }
        private bool IsCancelled(string textToCheck)
        {
            bool isCancelled = false;
            if(textToCheck.Any(c => char.IsLetter(c)))
            {
                isCancelled = true;
                return isCancelled;
            }
            bool containsDot = textToCheck.Any(c => c == '.');
            bool containsMinus = textToCheck.Any(c => c == '-');
            if(containsDot)
            {
                bool oneDot = textToCheck.Count(c => c == '.') != 1 ? false : true;
                bool areDigits = textToCheck.Replace('.', '0').Any(c => char.IsDigit(c));
                if (!oneDot || !areDigits) isCancelled = true;
            }
            else if(containsMinus)
            {
                bool oneMinus = textToCheck.Count(c => c == '-') != 1 ? false : true;
                bool areDigits = textToCheck.Replace('-', '0').Any(c => char.IsDigit(c));
                if (!oneMinus || !areDigits) isCancelled = true;
            }
            else
            {
                bool containsDigits = textToCheck.Any(c => !char.IsDigit(c));
                if (containsDigits) isCancelled = true;
            }
            return isCancelled;
        }
        #endregion
    }
}
