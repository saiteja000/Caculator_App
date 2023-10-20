

namespace Calculator;

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();
        OnClear(this, null);

    }

    string currentEntry = "";
    int currentState = 1;
    string mathOperator;
    double firstNumber, secondNumber;
    string decimalFormat = "N0";



    void OnSelectNumber(object sender, EventArgs e)
    {
        if (sender is Button clearButton)
        {
            // Change the button color to yellow when clicked
            clearButton.BackgroundColor = Color.FromHex("#FFFF00"); // Yellow
            clearButton.TextColor = Color.FromHex("#000000"); // Black

            // Your clear logic here

            // Restore the button color after a delay (e.g., 500 milliseconds)
            Device.StartTimer(TimeSpan.FromMilliseconds(500), () =>
            {
                clearButton.BackgroundColor = Color.FromHex("#D3D3D3"); // LightGray
                clearButton.TextColor = Color.FromHex("#000000"); // Black
                return false; // Stop the timer
            });

        }


        Button button = (Button)sender;
        string pressed = button.Text;

        currentEntry += pressed;

        if ((this.resultText.Text == "0" && pressed == "0")
            || (currentEntry.Length <= 1 && pressed != "0")
            || currentState < 0)
        {
            this.resultText.Text = "";
            if (currentState < 0)
                currentState *= -1;
        }

        if (pressed == "." && decimalFormat != "N2")
        {
            decimalFormat = "N2";
        }

        this.resultText.Text += pressed;
    }

    void OnSelectOperator(object sender, EventArgs e)
    {
        if (sender is Button clearButton)
        {
            // Change the button color to yellow when clicked
            clearButton.BackgroundColor = Color.FromHex("#FFFF00"); // Yellow
            clearButton.TextColor = Color.FromHex("#000000"); // Black

            // Your clear logic here

            // Restore the button color after a delay (e.g., 500 milliseconds)
            Device.StartTimer(TimeSpan.FromMilliseconds(500), () =>
            {
                clearButton.BackgroundColor = Color.FromHex("#D3D3D3"); // LightGray
                clearButton.TextColor = Color.FromHex("#000000"); // Black
                return false; // Stop the timer
            });
        }

        LockNumberValue(resultText.Text);

        currentState = -2;
        Button button = (Button)sender;
        string pressed = button.Text;
        mathOperator = pressed;
    }

    private void LockNumberValue(string text)
    {
        double number;
        if (double.TryParse(text, out number))
        {
            if (currentState == 1)
            {
                firstNumber = number;
            }
            else
            {
                secondNumber = number;
            }

            currentEntry = string.Empty;
        }
    }

    void OnClear(object sender, EventArgs e)
    {
        if (sender is Button clearButton)
        {
            // Change the button color to yellow when clicked
            clearButton.BackgroundColor = Color.FromHex("#FFFF00"); // Yellow
            clearButton.TextColor = Color.FromHex("#000000"); // Black

            // Your clear logic here

            // Restore the button color after a delay (e.g., 500 milliseconds)
            Device.StartTimer(TimeSpan.FromMilliseconds(500), () =>
            {
                clearButton.BackgroundColor = Color.FromHex("#D3D3D3"); // LightGray
                clearButton.TextColor = Color.FromHex("#000000"); // Black
                return false; // Stop the timer
            });
        }

        firstNumber = 0;
        secondNumber = 0;
        currentState = 1;
        decimalFormat = "N0";
        this.resultText.Text = "0";
        currentEntry = string.Empty;
    }

    void OnCalculate(object sender, EventArgs e)
    {
        if (sender is Button clearButton)
        {
            // Change the button color to yellow when clicked
            clearButton.BackgroundColor = Color.FromHex("#FFFF00"); // Yellow
            clearButton.TextColor = Color.FromHex("#000000"); // Black

            // Your clear logic here

            // Restore the button color after a delay (e.g., 500 milliseconds)
            Device.StartTimer(TimeSpan.FromMilliseconds(500), () =>
            {
                clearButton.BackgroundColor = Color.FromHex("#D3D3D3"); // LightGray
                clearButton.TextColor = Color.FromHex("#000000"); // Black
                return false; // Stop the timer
            });
        }


        if (currentState == 2)
        {
            if (secondNumber == 0)
            {
                LockNumberValue(resultText.Text);
                if (mathOperator == "%")
                {
                    // Calculate modulus (percentage)
                    firstNumber = firstNumber / 100;
                    this.CurrentCalculation.Text = $"{firstNumber} %";
                    this.resultText.Text = firstNumber.ToTrimmedString(decimalFormat);
                    currentState = -1;
                }
                else
                {
                    // Handle division by zero or other errors
                    // You can display an error message to the user.
                }
            }
            if (mathOperator == "^")
            {
                // Calculate exponentiation
                firstNumber = Math.Pow(firstNumber, secondNumber);
                this.CurrentCalculation.Text = $"{firstNumber} ^ {secondNumber}";
                this.resultText.Text = firstNumber.ToTrimmedString(decimalFormat);
                currentState = -1;
            }

            if (mathOperator == "√") // Check if the operator is square root
            {
                if (firstNumber >= 0)
                {
                    double sqrtResult = Math.Sqrt(firstNumber);
                    this.CurrentCalculation.Text = $"√{firstNumber}";
                    this.resultText.Text = sqrtResult.ToTrimmedString(decimalFormat);
                }
                else
                {
                    // Handle the case of invalid input (e.g., negative number)
                    // You can display an error message to the user.
                }
                currentState = -1;
            }

            else
            {
                if (currentState == 2)
                {
                    if (secondNumber == 0)
                        LockNumberValue(resultText.Text);

                    double result = Calculator.Calculate(firstNumber, secondNumber, mathOperator);

                    this.CurrentCalculation.Text = $"{firstNumber} {mathOperator} {secondNumber}";

                    this.resultText.Text = result.ToTrimmedString(decimalFormat);
                    firstNumber = result;
                    secondNumber = 0;
                    currentState = -1;
                    currentEntry = string.Empty;
                }

            }
        }



    }

    void OnNegative(object sender, EventArgs e)
    {
        if (sender is Button clearButton)
        {
            // Change the button color to yellow when clicked
            clearButton.BackgroundColor = Color.FromHex("#FFFF00"); // Yellow
            clearButton.TextColor = Color.FromHex("#000000"); // Black

            // Your clear logic here

            // Restore the button color after a delay (e.g., 500 milliseconds)
            Device.StartTimer(TimeSpan.FromMilliseconds(500), () =>
            {
                clearButton.BackgroundColor = Color.FromHex("#D3D3D3"); // LightGray
                clearButton.TextColor = Color.FromHex("#000000"); // Black
                return false; // Stop the timer
            });
        }

        if (currentState == 1)
        {
            secondNumber = -1;
            mathOperator = "×";
            currentState = 2;
            OnCalculate(this, null);
        }
    }

    void OnPercentage(object sender, EventArgs e)
    {
        if (sender is Button clearButton)
        {
            // Change the button color to yellow when clicked
            clearButton.BackgroundColor = Color.FromHex("#FFFF00"); // Yellow
            clearButton.TextColor = Color.FromHex("#000000"); // Black

            // Your clear logic here

            // Restore the button color after a delay (e.g., 500 milliseconds)
            Device.StartTimer(TimeSpan.FromMilliseconds(500), () =>
            {
                clearButton.BackgroundColor = Color.FromHex("#D3D3D3"); // LightGray
                clearButton.TextColor = Color.FromHex("#000000"); // Black
                return false; // Stop the timer
            });
        }

        if (currentState == 1)
        {
            LockNumberValue(resultText.Text);
            decimalFormat = "N2";
            secondNumber = 0.01;
            mathOperator = "×";
            currentState = 2;
            OnCalculate(this, null);
        }
    }


    //new code

   


    private void OnLeftParenthesis(object sender, EventArgs e)
    {
        // Check if the calculator is ready to accept a new number (currentState is 1).
        if (currentState == 1)
        {
            // Add a left parenthesis to the current entry.
            currentEntry += "(";

            // Update the UI to display the updated entry.
            this.resultText.Text = currentEntry;
        }
    }

    private void OnRightParenthesis(object sender, EventArgs e)
    {
        // Check if the calculator is ready to accept a new number (currentState is 1).
        // Also, ensure there's an unclosed left parenthesis in the current entry.
        if (currentState == 1 && currentEntry.Contains("(") && !currentEntry.Contains(")"))
        {
            // Add a right parenthesis to the current entry.
            currentEntry += ")";

            // Update the UI to display the updated entry.
            this.resultText.Text = currentEntry;
        }
    }

}