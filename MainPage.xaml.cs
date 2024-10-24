using System;

namespace CalculatorApp
{
    public partial class MainPage : ContentPage
    {
        double currentNumber = 0;
        double previousNumber = 0;
        string currentOperator;
        bool isOperatorClicked = false;

        public MainPage()
        {
            InitializeComponent();
        }

    
        void Number_Clicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            string pressed = button.Text;

            if (ResultLabel.Text == "0" || isOperatorClicked)
            {
                ResultLabel.Text = pressed;
                isOperatorClicked = false;
            }
            else
            {
                ResultLabel.Text += pressed;
            }

            currentNumber = double.Parse(ResultLabel.Text);
        }

        
        void Operator_Clicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            currentOperator = button.Text;

           
            ResultLabel.Text += " " + currentOperator + " ";

            previousNumber = currentNumber;
            isOperatorClicked = true;
        }

       
        void Equals_Clicked(object sender, EventArgs e)
        {
            double result = 0;

            switch (currentOperator)
            {
                case "+":
                    result = previousNumber + currentNumber;
                    break;
                case "−":
                    result = previousNumber - currentNumber;
                    break;
                case "×":
                    result = previousNumber * currentNumber;
                    break;
                case "÷":
                    if (currentNumber != 0)
                        result = previousNumber / currentNumber;
                    break;
            }

            ResultLabel.Text = result.ToString();
            currentNumber = result;
        }


        void Clear_Clicked(object sender, EventArgs e)
        {
            currentNumber = 0;
            previousNumber = 0;
            ResultLabel.Text = "0";
        }

       
        void Decimal_Clicked(object sender, EventArgs e)
        {
            if (!ResultLabel.Text.Contains("."))
            {
                ResultLabel.Text += ".";
            }
        }

       
        void PosNeg_Clicked(object sender, EventArgs e)
        {
            currentNumber = double.Parse(ResultLabel.Text);
            currentNumber = -currentNumber;
            ResultLabel.Text = currentNumber.ToString();
        }

        void Percent_Clicked(object sender, EventArgs e)
        {
            currentNumber = double.Parse(ResultLabel.Text);
            currentNumber = currentNumber / 100;
            ResultLabel.Text = currentNumber.ToString();
        }
    }
}
