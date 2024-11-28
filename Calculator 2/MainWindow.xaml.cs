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

namespace Calculator_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            checkOperator = false;
        }

        public string oper;
        public string lastNumber;
        public bool checkOperator;

        //Обработка цифр
        private void NumberButton(object sender, RoutedEventArgs e)
        {
            if (checkOperator == true)
            {
                checkOperator = false;
                TextBox.Text = "0";
            }
            Button button = (Button)sender;
            if (TextBox.Text == "0")
                TextBox.Text = (string)button.Content;
            else
                TextBox.Text += (string)button.Content;
        }

        //Обработка операторов
        private void Operator(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            oper = (string)button.Content;
            lastNumber = TextBox.Text;
            checkOperator = true;
        }

        //Выполнение операций
        private void Result(object sender, RoutedEventArgs e)
        {
            double numberOne, numberTwo, result;
            result = 0;
            numberOne = Convert.ToDouble(lastNumber);
            numberTwo = Convert.ToDouble(TextBox.Text);
            if (oper == "+")
            {
                result = numberOne + numberTwo;
            }
            if (oper == "-")
            {
                result = numberOne - numberTwo;
            }
            if (oper == "×")
            {
                result = numberOne * numberTwo;
            }
            if (oper == "÷")
            {
                result = numberOne / numberTwo;
            }
            oper = "=";
            checkOperator = true;
            TextBox.Text = Convert.ToString(result);
        }

        //Корень
        private void Root(object sender, RoutedEventArgs e)
        {
            double number, result;
            number = Convert.ToDouble(TextBox.Text);
            result = Math.Sqrt(number);
            TextBox.Text = result.ToString();
        }

        //Возведение во вторую степень
        private void Degree(object sender, RoutedEventArgs e)
        {
            double number, result;
            number = Convert.ToDouble(TextBox.Text);
            result = Math.Pow(number, 2);
            TextBox.Text = result.ToString();
        }

        //Изменяет знак на противоположный
        private void ReversNumber(object sender, RoutedEventArgs e)
        {
            double number, result;
            number = Convert.ToDouble(TextBox.Text);
            result = -number;
            TextBox.Text = result.ToString();
        }

        //Запятая
        private void FractionalNumber(object sender, RoutedEventArgs e)
        {
            if(!TextBox.Text.Contains(","))
                TextBox.Text += ",";
        }

        //Стирает значения в TextBox
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            TextBox.Text = "0";
        }

        //Запрещает ввод в TextBox с клавиатуры
        private void textBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 || e.Key == Key.Back || e.Key == Key.Delete)
            {
                e.Handled = true;
            }
        }

    }
}
