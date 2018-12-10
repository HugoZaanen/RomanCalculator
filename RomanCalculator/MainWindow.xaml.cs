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
            int k = 5381;
            string str = "";
            List<int> lijst = new List<int>();

            if (k/1000 > 0)
            {
                lijst.Add((k/10000) * 1000);
                k = k % 1000;
            }

            if (k/100 > 0)
            {
                lijst.Add((k/100) * 100);
                k = k % 100;
            }

            if(k/10 > 0)
            {
                lijst.Add((k/10) * 10);
                k = k % 10;
            }

            if (k/1 > 0)
            {
                lijst.Add(k/1);
                k = k % 1;
            }

            foreach (int i in lijst)
            {
                int z = i;
                while (z > 0)
                {
                    if (i%1000 == 0)
                    {
                        str += "M";
                        z -= 1000;
                    }
                    else if (z%100 == 0)
                    {
                        if(z == 900)
                        {
                            str += "CM";
                            z -= 900;
                        }
                        else if (z >= 500 && z < 900)
                        {
                            str += "D";
                            z -= 500;
                        }
                        else if (z == 400)
                        {
                            str += "CD";
                            z -= 400;
                        }
                        else
                        {
                            str += "C";
                        }
                    }

                    else if(z%10 == 0)
                    {
                        if (z == 90)
                        {
                            str += "XC";
                            z -= 90;
                        }
                        else if (z >= 50 && z < 90)
                        {
                            str += "L";
                            z -= 50;
                        }
                        else
                        {
                            str += "X";
                            z -= 10; 
                        }
                    }

                    if ()
                    {

                    }
                }
            }
        }
    }
}
