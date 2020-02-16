using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace polynomValue
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        

        private void polyByX(object sender, RoutedEventArgs e)
        {
            var str = px.Text;
            var s = ParseModule.parseAll(str);
            var res = ComputingModule.calculatePolynom(s, int.Parse(x.Text));
            MessageBox.Show(res.ToString(), "My App");
        }
        private void polyByY(object sender, RoutedEventArgs e)
        {
            var str = qy.Text;
            var s = ParseModule.parseAll(str);
            var res = ComputingModule.calculatePolynom(s, int.Parse(y.Text));
            MessageBox.Show(res.ToString(), "My App");


        }
        private void polySumByXY(object sender, RoutedEventArgs e)
        {

            var str = this.px.Text;
            var s = ParseModule.parseAll(str);
            var px = ComputingModule.calculatePolynom(s, 2);
            
            var str1 = this.qy.Text;
            var s1 = ParseModule.parseAll(str1);
            var yx = ComputingModule.calculatePolynom(s1, int.Parse(y.Text));

            var qByXPlusY  = ComputingModule.calculatePolynom(s1, int.Parse(y.Text)+int.Parse(x.Text));

            var pByQtop = ComputingModule.calculatePolynom(s, int.Parse(qByXPlusY.ToString()));

            var sum = px * yx - pByQtop ;

            MessageBox.Show(sum.ToString(), "form");
            


        }
       
        private void px_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (pxButton != null)
            {
                if (string.IsNullOrEmpty(px.Text))
                {
                    pxButton.IsEnabled = false;
                    complexbutton.IsEnabled = false;
                }
                else
                {
                    pxButton.IsEnabled = true;
                    complexbutton.IsEnabled = true;
                }
            }
            

        }
        private void qy_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (qyButton != null)
            {
                if (string.IsNullOrEmpty(qy.Text))
                {
                    qyButton.IsEnabled = false;
                    complexbutton.IsEnabled = false;
                }
                else
                {
                    qyButton.IsEnabled = true;
                    complexbutton.IsEnabled = true;
                }
            }


        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9-+]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void NumberanXValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9x+-]+");
            e.Handled = regex.IsMatch(e.Text);
        }


        private void x_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (pxButton != null)
            {
                if (string.IsNullOrEmpty(x.Text))
                {
                    pxButton.IsEnabled = false;
                    complexbutton.IsEnabled = false;
                }
                else
                {
                    pxButton.IsEnabled = true;
                    complexbutton.IsEnabled = true;
                }
                
            }
        }

        private void y_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (pxButton != null&&qyButton!=null)
            {
                if (string.IsNullOrEmpty(y.Text))
                {
                    qyButton.IsEnabled = false;
                    complexbutton.IsEnabled = false;
                }
                else
                {
                    qyButton.IsEnabled = true;
                    complexbutton.IsEnabled = true;
                }
            }
        }
    }
}
