﻿using System;
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
        List<string> numeralFormats = new List<string>();
        string check = "";
        string numCheck = "";
        bool isOk = true;

        public MainWindow()
        {
            InitializeComponent();

            dict.Add('I',1);
            dict.Add('V',5);
            dict.Add('X',10);
            dict.Add('L',50);
            dict.Add('C',100);
            dict.Add('D',500);
            dict.Add('M',1000);

            numeralFormats.Add("IV");
            numeralFormats.Add("IX");
            numeralFormats.Add("XL");
            numeralFormats.Add("XC");
            numeralFormats.Add("CD");
            numeralFormats.Add("CM");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button butt = sender as Button;
            string input = (string)butt.Content;
            string str = "";

            if (input != "OK" && isOk)
            {
                str = (string)butt.Content;              
                Txtbx1.Text += (string)butt.Content;                
            }
            else
            {
                isOk = false;
                if (input != "OK")
                {
                    Txtbx2.Text += input;
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string test = "MMCCXXII";
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

        #region Integers to numerals 
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            int k = 2222;
            string str = "";
            List<int> lijst = new List<int>();

            if (k/1000 > 0)
            {
                lijst.Add((k/1000) * 1000);
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
                    if (z % 1000 == 0)
                    {
                        str += "M";
                        z -= 1000;
                    }
                    else if (z % 100 == 0)
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
                            z -= 100;
                        }
                    }
                    else if(z % 10 == 0)
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
                        else if(z == 40)
                        {
                            str += "XL";
                            z -= 10; 
                        }
                        else
                        {
                            str += "X";
                            z -= 10;
                        }
                    }
                    else if (z % 1 == 0)
                    { 
                        if (z == 9)
                        {
                            str += "IX";
                            z -= 9;
                        }
                        else if(z >= 5 && z < 9)
                        {
                            str += "V";
                            z -= 5;
                        } 
                        else if(z == 4)
                        {
                            str += "IV";
                            z -= 4;
                        }
                        else
                        {
                            str += "I";
                            z -= 1;
                        }
                    }
                }
            }
        }
#endregion

        private bool CheckFormat(string str)
        {
            check = str;

            if (numeralFormats.Contains(check) && !(Txtbx1.Text == ""))
            {
                return false;
            }
            else if (numCheck != "" && NumerToInt(check) <= NumerToInt(numCheck))
            {
                return false;
            }

            numCheck = str;
            return true;
        }

        private int NumerToInt(string str)
        {
            int i = 0;
            char[] chars = str.ToCharArray();

            for (int j = chars.Length; j >= 0; j--)
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
            return i;
        }
    }
}