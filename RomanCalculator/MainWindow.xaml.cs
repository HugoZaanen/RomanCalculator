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

namespace RomanCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<char, int> dict = new Dictionary<char, int>();

        public MainWindow()
        {
            InitializeComponent();

            dict.Add('I',1);
            dict.Add('V',5);
            dict.Add('X',10);
            dict.Add('L',50);
            dict.Add('C', 100);
            dict.Add('D',500);
            dict.Add('M',1000);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button butt = sender as Button;
            bool isOk = true;
            string str = "";

            if ((string)butt.Content != "OK" && isOk)
            {
                str = (string)butt.Content;

                Txtbx1.Text += (string)butt.Content;
            }
            else
            {
                Txtbx2.Text += (string)butt.Content;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string test = "LXXX";
            int i = 0;

            char[] chars = test.ToCharArray();

            for (int j = chars.Length; j >= 0;j--)
            {
                if (j == chars.Length)
                {
                    i += dict[chars[j - 1]];
                    j--;
                }
                else if ((dict[chars[j]] == 1 || dict[chars[j]] == 10 || dict[chars[j]] == 100) && dict[chars[j]] < dict[chars[j + 1]])
                {
                    i -= dict[chars[j]];
                }
                else
                {
                    i += dict[chars[j]];
                }               
            }

            MessageBox.Show(i.ToString());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            int k = 100;

            while (k > 0)
            {
                if ()
                {

                }
            }
        }
    }
}
