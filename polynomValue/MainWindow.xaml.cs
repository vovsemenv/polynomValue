using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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

        

        public void polyByX(object sender, RoutedEventArgs e)
        {
            var str = px.Text;
            var s = ParseModule.parseAll(str);
            var res = ComputingModule.calculatePolynom(s, int.Parse(x.Text));
                        
            Thread t = new Thread(() => MessageBox.Show(res.ToString(), "My App"));
            t.Start();

            this.res = res; 
        }
        private void polyByY(object sender, RoutedEventArgs e)
        {
            var str = qy.Text;
            var s = ParseModule.parseAll(str);

            var res = ComputingModule.calculatePolynom(s, int.Parse(y.Text));
            Thread t = new Thread(() => MessageBox.Show(res.ToString(), "My App"));

            t.Start();
            this.res = res;
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
            
            Thread t = new Thread(() => MessageBox.Show(sum.ToString(), "My App"));
            t.Start();
            this.res = sum;
            
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



        public string getPx()// get polynom equation for px
        {
            return this.px.Text;
        }
        public void setPx(string px)// set polynom equation for px
        {
            this.px.Text = px;
        }
        public string getQy() {// get polynom equation for qy
            return this.qy.Text;
        }
        public void setQy(string qy)
        {
            this.qy.Text = qy;
        }
        public int getX()// get value of x
        {
            return int.Parse(this.x.Text);
        }
        public void setX(int x)// set value of x
        {
            this.x.Text = x.ToString();
        }
        public int getY()// get value of y
        {
            return int.Parse(this.y.Text);
        }
        public void setY(int y)// get value of y
        {
            this.y.Text = y.ToString();
        }
        public double res { get; set; }// Хранит значение любых вычислений вызваных конпкой


        public void clickPx()// Вычиляет значение полинома Px 
        {
            polyByX(new object(), new RoutedEventArgs());

        }
        public void clickQy()// Вычиляет значение полинома Qy
        {
            polyByY(new object(), new RoutedEventArgs());
        }
        public void clickPolySumByXY()// Вычиляет значение сложного полинома
        {
            polySumByXY(new object(), new RoutedEventArgs());
        }
        

    }
}
