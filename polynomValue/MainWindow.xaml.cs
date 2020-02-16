using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            var pByQtop = ComputingModule.calculatePolynom(s, qByXPlusY);

            var sum = px * yx - pByQtop ;

            MessageBox.Show(sum.ToString(), "form");
            


        }
    }
}
