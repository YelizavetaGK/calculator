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

namespace Calculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string operation;
        double numberBefore;
        bool sign = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Digit(object sender, RoutedEventArgs e)
        {
            string number = (string)((Button)e.OriginalSource).Content;
            TextField.Text += number;

        }

        private void Button_Operation(object sender, RoutedEventArgs e)
        {
            Error_Insert_Value();
            string n = TextField.Text;
            double number1 = Convert.ToDouble(n);
            numberBefore = number1;
            operation = (string)((Button)e.OriginalSource).Content;
            TextField.Text = "";
        }

        private void Button_Float(object sender, RoutedEventArgs e)
        {
            string text = TextField.Text;
            if (text.Contains(",")) return;
            if (text == "") text = text + "0,";
            else text = text + ",";
            TextField.Text = text;
        }

        private void Button_Sign(object sender, RoutedEventArgs e)
        {
            if (sign == true)
            {
                TextField.Text = "-" + TextField.Text;
                sign = false;
            }
            else
            {
                TextField.Text = TextField.Text.Replace("-", "");
                sign = true;
            }
        }

        private void Button_AC(object sender, RoutedEventArgs e)
        {
            TextField.Text = "";
        }

        private void Button_Percent(object sender, RoutedEventArgs e)
        {
            Error_Insert_Value();
            string n = TextField.Text;
            double number1 = Convert.ToDouble(n);
            numberBefore = number1;
            double result = numberBefore / 100.0;
            TextField.Text = result.ToString();
        }

        private void Button_Result(object sender, RoutedEventArgs e)
        {
            Error_Insert_Value();
            string text = TextField.Text;
            double number2 = Convert.ToDouble(text);
            double result = 0;

            switch (operation)
            {
                case "+":
                    result = numberBefore + number2;
                    break;
                case "-":
                    result = numberBefore - number2;
                    break;
                case "*":
                    result = numberBefore * number2;
                    break;
                case "/":
                    if (number2 == 0)
                        MessageBox.Show("Error: Division by Zero!");
                    result = numberBefore / number2;
                    break;
            }
            TextField.Text = result.ToString();
        }
        private void Error_Insert_Value()
        {
            if (TextField.Text == "")
            {
                MessageBox.Show("Enter value!");
                return;
            }
        }
    }
}
