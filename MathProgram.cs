/*If you can figure out why vscode keeps confusing this for Java after the first runthrough I'm all ears.
* I'm at my wit's end with vscode, it works everywhere else and it works every time I start the compiler*/
using System;

class Math
{
    static void Main(string[] args)
    {
        // Lambda expression for performing arithmetic operations and handling exceptions
        Func<string, decimal, decimal, string> performOperation = (operation, num1, num2) =>
        {
            try
            {
                return operation switch
                {
                    "+" => $"Result: {num1 + num2}",
                    "-" => $"Result: {num1 - num2}",
                    "*" => $"Result: {num1 * num2}",
                    "/" => num2 != 0 ? $"Result: {num1 / num2}" : "Error: Division by zero is not allowed.",
                    _ => "Error: Invalid operation. Please use +, -, *, or /."
                };
            }
            catch (FormatException)
            {
                return "Error: Invalid format. Please enter valid numbers.";
            }
            catch (OverflowException)
            {
                return "Error: Number is too large.";
            }
        };

        // Function to read and parse user input safely
        decimal ReadDecimalInput(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (decimal.TryParse(input, out decimal number))
                {
                    return number;
                }
                else
                {
                    Console.WriteLine("Error: Invalid format. Please enter a valid number.");
                }
            }
        }

        // Function to read a valid operation input
        string ReadOperationInput()
        {
            while (true)
            {
                Console.Write("Enter the operation (+, -, *, /): ");
                string operation = Console.ReadLine();
                if (operation == "+" || operation == "-" || operation == "*" || operation == "/")
                {
                    return operation;
                }
                else
                {
                    Console.WriteLine("Error: Invalid operation. Please use +, -, *, or /.");
                }
            }
        }

        // Function to check if the user wants to perform another calculation
        bool ContinueCalculation()
        {
            while (true)
            {
                Console.Write("Do you want to perform another calculation? (yes/no or y/n): ");
                string continueInput = Console.ReadLine().ToLower();
                if (continueInput == "yes" || continueInput == "y")
                {
                    return true;
                }
                else if (continueInput == "no" || continueInput == "n")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Error: Invalid input. Please enter yes/no or y/n.");
                }
            }
        }

        while (true)
        {
            // Read user input for operation
            string operation = ReadOperationInput();

            // Read user input for numbers
            decimal num1 = ReadDecimalInput("Enter the first number: ");
            decimal num2 = ReadDecimalInput("Enter the second number: ");

            // Perform the operation and display the result
            string result = performOperation(operation, num1, num2);
            Console.WriteLine($"Operation: {operation}, Num1: {num1}, Num2: {num2} - Result: {result}");

            if (operation == "/" && num2 == 0)
            {
                Console.WriteLine("Error: Division by zero is not allowed. Please try again.");
                continue;
            }

            // Ask if the user wants to perform another calculation
            if (!ContinueCalculation())
            {
                break;
            }
        }
    }
}
