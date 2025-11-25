using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Ink;

namespace calculata
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool znack = false;
        public bool zpt = false;
        List<double> chisla = new List<double>();
        List<string> oper = new List<string>();
        public double znachenie = 0;
        public string chislo = "";
        public int znacknumber = 0;
        public MainWindow()
        {
            InitializeComponent();
        }
        public bool isElementHere(string s, char element)
        {
            for(int i = 0; i < s.Length; i++)
            {
                if (s[i] == element)
                {
                    return true;
                }
            }
            return false;
        }
        public bool isLastDrob(string s)
        {
            for (int i = s.Length - 1; i >=0 ; i--)
            {
                if (s[i] == ',')
                {
                    return true;
                }
            }
            return false;
        }
        public string RAVNO(string s)
        {
            chisla.Clear();
            oper.Clear();
            znachenie = 0;
            chislo = "";
            znacknumber = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ')
                {
                    chisla.Add(Convert.ToDouble(chislo));
                    chislo = "";
                    oper.Add(Convert.ToString(s[i+ 1]));
                    znacknumber++;
                    i += 2;
                }
                else chislo += s[i];
                if (i == s.Length - 1)
                {
                    chisla.Add(Convert.ToDouble(chislo));
                    chislo = "";
                }
            }
            if (isElementHere(s, '*') || isElementHere(s, '/'))
            {
                for (int i = 0; i < znacknumber; i++)
                {
                    if (oper[i] == "*")
                    {
                        chisla[i] = chisla[i] * chisla[i + 1];
                        chisla[i + 1] = chisla[i];
                    }
                    if (oper[i] == "/")
                    {
                        chisla[i] = chisla[i] / chisla[i + 1];
                        chisla[i + 1] = chisla[i];
                    }
                }
            }
            znachenie = chisla[0];
            for (int i = 0; i < znacknumber; i++)
            {
                if (oper[i] == "+")
                {
                    znachenie += chisla[i + 1];
                }
                if (oper[i] == "-")
                {
                    znachenie -= chisla[i + 1];
                }
            }
            chislo = Convert.ToString(znachenie);
            return chislo;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            stroka.Text += 1.ToString();
            znack = false;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            stroka.Text += 2.ToString();
            znack = false;
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            stroka.Text += 3.ToString();
            znack = false;
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            stroka.Text += 4.ToString();
            znack = false;
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            stroka.Text += 5.ToString(); 
            znack = false;
        }
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            stroka.Text += 6.ToString();
            znack = false;
        }
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            stroka.Text += 7.ToString();
            znack = false;
        }
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            stroka.Text += 8.ToString();
            znack = false;
        }
        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            stroka.Text += 9.ToString();
            znack = false;
        }
        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            stroka.Text += 0.ToString();
            znack = false;
        }
        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            if (stroka.Text != "")
            { 
                stroka.Text = "";
                znack = false;
                zpt = false;
            }
        }
        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            if (stroka.Text != "" && stroka.Text != "-")
            {
                if (znack && stroka.Text.Length > 3)
                {
                    stroka.Text = stroka.Text.Substring(0, stroka.Text.Length - 3);
                    znack = false;
                }
                if (stroka.Text[stroka.Text.Length - 1] == ',')
                {
                    stroka.Text = stroka.Text.Substring(0, stroka.Text.Length - 1);
                }
                stroka.Text = RAVNO(stroka.Text);
                if (isElementHere(stroka.Text, ','))
                {
                    zpt = true;
                }
                else zpt = false;
            }
        }
        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            if (stroka.Text != "" && stroka.Text != "-")
            {
                if (znack && stroka.Text.Length > 3)
                {
                    stroka.Text = stroka.Text.Substring(0, stroka.Text.Length - 3);
                }
                if (stroka.Text[stroka.Text.Length - 1] == ',')
                {
                    stroka.Text = stroka.Text.Substring(0, stroka.Text.Length - 1);
                }
                stroka.Text += " + ";
                znack = true;
                zpt = false;
            }
        }
        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            if (stroka.Text != "" && stroka.Text != "-")
            {
                if (znack && stroka.Text.Length > 3)
                {
                    stroka.Text = stroka.Text.Substring(0, stroka.Text.Length - 3);
                }
                if (stroka.Text[stroka.Text.Length - 1] == ',')
                {
                    stroka.Text = stroka.Text.Substring(0, stroka.Text.Length - 1);
                }
                stroka.Text += " - ";
                znack = true;
                zpt = false;
            }
            else if (stroka.Text == "")
            {
                stroka.Text += "-";
                znack = true;
            }
        }
        private void Button_Click_14(object sender, RoutedEventArgs e)
        {
            if (stroka.Text != "" && stroka.Text != "-")
            {
                if (znack)
                {
                    stroka.Text = stroka.Text.Substring(0, stroka.Text.Length - 3);
                }
                if (stroka.Text[stroka.Text.Length - 1] == ',')
                {
                    stroka.Text = stroka.Text.Substring(0, stroka.Text.Length - 1);
                }
                stroka.Text += " * ";
                znack = true;
                zpt = false;
            }
        }
        private void Button_Click_15(object sender, RoutedEventArgs e)
        {
            if (stroka.Text != "" && stroka.Text != "-")
            {
                if (znack)
                {
                    stroka.Text = stroka.Text.Substring(0, stroka.Text.Length - 3);
                }
                if (stroka.Text[stroka.Text.Length - 1] == ',')
                {
                    stroka.Text = stroka.Text.Substring(0, stroka.Text.Length - 1);
                }
                stroka.Text += " / ";
                znack = true;
                zpt = false;
            }
        }
        private void Button_Click_16(object sender, RoutedEventArgs e)
        {
            if (!zpt)
            {
                if (stroka.Text == "" || znack)
                {
                    stroka.Text += "0,";
                    zpt = true;
                    znack = false;
                }
                else
                {
                    stroka.Text += ",";
                    zpt = true;
                }
            }
            
        }
        private void Button_Click_17(object sender, RoutedEventArgs e)
        {
            if (stroka.Text != "")
            {
                if (stroka.Text[stroka.Text.Length - 1] == ' ')
                {
                    if (stroka.Text.Length >= 3)
                    {
                        stroka.Text = stroka.Text.Substring(0, stroka.Text.Length - 3);
                        znack = false;
                    }
                }
                else
                {
                    stroka.Text = stroka.Text.Substring(0, stroka.Text.Length - 1);
                    znack = false;
                    if ((stroka.Text.Length > 3 && stroka.Text[stroka.Text.Length - 1] == ' ') || stroka.Text == "-") znack = true;
                }
                zpt = isLastDrob(stroka.Text);
            }
        }
    }
}