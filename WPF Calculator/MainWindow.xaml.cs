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

namespace WPF_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double firstNum = 0.0;
        string operation = ""; 
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click0(object sender, RoutedEventArgs e)
        {
            if (textbox.Text == "0" && textbox.Text != null) textbox.Text = "0";
            else textbox.Text += 0; 
        }

        private void Button_ClickDecimal(object sender, RoutedEventArgs e)
        {
            if (textbox.Text.Contains(".")) Console.WriteLine("Cannot have multiple decimals. ");
            else textbox.Text += "."; 
        }

        private void Button_ClickEquals(object sender, RoutedEventArgs e)
        {
            double secondNum = 0.0;
            double result = 0.0;

            secondNum = Convert.ToDouble(textbox.Text);
            prevNum.Text += secondNum;

            if (operation == "+")
            {
                result = firstNum + secondNum;
                textbox.Text = Convert.ToString(result);
                firstNum = result;
            }
            else if (operation == "-")
            {
                result = firstNum - secondNum;
                textbox.Text = Convert.ToString(result);
                firstNum = result;
            }
            else if (operation == "x")
            {
                result = firstNum * secondNum;
                textbox.Text = Convert.ToString(result);
                firstNum = result;
            }
            else if (operation == "/")
            {
                if (secondNum == 0) Console.WriteLine("Cannot Divide By Zero");
                else
                {
                    result = firstNum / secondNum;
                    textbox.Text = Convert.ToString(result);
                    firstNum = result;
                }
            }

        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            if (textbox.Text == "0" && textbox.Text != null) textbox.Text = "1";
            else textbox.Text += 1;
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            if (textbox.Text == "0" && textbox.Text != null) textbox.Text = "2";
            else textbox.Text += 2;
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            if (textbox.Text == "0" && textbox.Text != null) textbox.Text = "3";
            else textbox.Text += 3;
        }

        private void Button_ClickPlus(object sender, RoutedEventArgs e)
        {
            firstNum = Convert.ToDouble(textbox.Text);
            prevNum.Text += firstNum + " + ";
            operation = "+"; 
        }

        private void Button_Click4(object sender, RoutedEventArgs e)
        {
            if (textbox.Text == "0" && textbox.Text != null) textbox.Text = "4";
            else textbox.Text += 4;
        }

        private void Button_Click5(object sender, RoutedEventArgs e)
        {
            if (textbox.Text == "0" && textbox.Text != null) textbox.Text = "5";
            else textbox.Text += 5;
        }

        private void Button_Click6(object sender, RoutedEventArgs e)
        {
            if (textbox.Text == "0" && textbox.Text != null) textbox.Text = "6";
            else textbox.Text += 6;
        }

        private void Button_ClickMinus(object sender, RoutedEventArgs e)
        {
            firstNum = Convert.ToDouble(textbox.Text);
            prevNum.Text += firstNum + " - ";
            operation = "-";
        }

        private void Button_Click7(object sender, RoutedEventArgs e)
        {
            if (textbox.Text == "0" && textbox.Text != null) textbox.Text = "7";
            else textbox.Text += 7;
        }

        private void Button_Click8(object sender, RoutedEventArgs e)
        {
            if (textbox.Text == "0" && textbox.Text != null) textbox.Text = "8";
            else textbox.Text += 8;
        }

        private void Button_Click9(object sender, RoutedEventArgs e)
        {
            if (textbox.Text == "0" && textbox.Text != null) textbox.Text = "9";
            else textbox.Text += 9;
        }

        private void Button_ClickMult(object sender, RoutedEventArgs e)
        {
            firstNum = Convert.ToDouble(textbox.Text);
            prevNum.Text += firstNum + " x ";
            operation = "x";
        }

        private void Button_ClickSquare(object sender, RoutedEventArgs e)
        {
            firstNum = Convert.ToDouble(textbox.Text);
            prevNum.Text += "squ(" + firstNum + ")";
            textbox.Text = "" + firstNum * firstNum; 
        }

        private void Button_ClickCE(object sender, RoutedEventArgs e)
        {
            textbox.Text = "0"; 
        }

        private void Button_ClickC(object sender, RoutedEventArgs e)
        {
            textbox.Text = "0";
            prevNum.Text = ""; 
        }

        private void Button_ClickDivide(object sender, RoutedEventArgs e)
        {
            firstNum = Convert.ToDouble(textbox.Text);
            prevNum.Text += firstNum + " / ";
            operation = "/";
        }

        private void Button_ClickSignSwitch(object sender, RoutedEventArgs e)
        {
            double signSwitch = 0.0;
            signSwitch = Convert.ToDouble(textbox.Text);
            signSwitch *= -1;
            textbox.Text = Convert.ToString(signSwitch); 
        }
    }
}
