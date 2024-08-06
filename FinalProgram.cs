using System;
// Enumeration representing the two options for shift
public enum Shift
{
    Day = 1,
    Night = 2
}

// Base class representing a Contractor
public class Contractor
{
    private string contractorName; // Name of the contractor
    private int contractorNumber; // Unique number for the contractor
    private DateTime contractorStartDate; // Start date of the contractor

    // Constructor to initialize the contractor
    public Contractor(string name, int number, DateTime startDate)
    {
        ContractorName = name;
        ContractorNumber = number;
        ContractorStartDate = startDate;
    }

    // Property for contractorName with input validation
    public string ContractorName
    {
        get { return contractorName; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Contractor name cannot be empty.");
            contractorName = value;
        }
    }

    // Property for contractorNumber with input validation
    public int ContractorNumber
    {
        get { return contractorNumber; }
        set
        {
            if (value <= 0)
                throw new ArgumentException("Contractor number must be positive.");
            contractorNumber = value;
        }
    }

    // Property for contractorStartDate with input validation
    public DateTime ContractorStartDate
    {
        get { return contractorStartDate; }
        set
        {
            if (value > DateTime.Now)
                throw new ArgumentException("Start date cannot be in the future.");
            contractorStartDate = value;
        }
    }
}

// Derived class representing a Subcontractor
public class Subcontractor : Contractor
{
    private Shift shift; // Shift type (Day/Night)
    private double hourlyPayRate; // Hourly pay rate

    // Constructor to initialize the subcontractor
    public Subcontractor(string name, int number, DateTime startDate, Shift shift, double hourlyPayRate)
        : base(name, number, startDate)
    {
        Shift = shift;
        HourlyPayRate = hourlyPayRate;
    }

    // Property for shift with input validation
    public Shift Shift
    {
        get { return shift; }
        set
        {
            if (!Enum.IsDefined(typeof(Shift), value))
                throw new ArgumentException("Invalid shift value.");
            shift = value;
        }
    }

    // Property for hourlyPayRate with input validation
    public double HourlyPayRate
    {
        get { return hourlyPayRate; }
        set
        {
            if (value <= 0)
                throw new ArgumentException("Hourly pay rate must be positive.");
            hourlyPayRate = value;
        }
    }

    // Method to compute pay based on hours worked and shift type
    public float ComputePay(float hoursWorked)
    {
        float pay = (float)(hoursWorked * hourlyPayRate);
        if (shift == Shift.Night)
        {
            pay *= 1.03f; // 3% differential for night shift
        }
        return pay;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Prompt for subcontractor details
        string name = PromptForString("Enter contractor name: ");
        int number = PromptForInt("Enter contractor number: ", minValue: 1);
        DateTime startDate = PromptForDateTime("Enter contractor start date (mm-dd-yyyy): ");
        Shift shift = PromptForShift("Enter shift (1 for Day, 2 for Night): ");
        double hourlyPayRate = PromptForDouble("Enter hourly pay rate: ", minValue: 0.01);

        //Creates a subcontractor object
        Subcontractor subcontractor = new Subcontractor(name, number, startDate, shift, hourlyPayRate);

        // Prompt for hours worked
        float hoursWorked = PromptForFloat("Enter hours worked: ", minValue: 0);

        // Prompt for compute pay
        float pay = subcontractor.ComputePay(hoursWorked);
        Console.WriteLine($"Total pay for the subcontractor is: ${pay:F2}");
    }

    // Method to prompt for a non-empty string
    static string PromptForString(string message)
    {
        while (true)
        {
            Console.Write(message);
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
                return input;
            Console.WriteLine("Input cannot be empty. Please try again.");
        }
    }

    // Method to prompt for an integer with a minimum value
    static int PromptForInt(string message, int minValue = int.MinValue)
    {
        while (true)
        {
            Console.Write(message);
            if (int.TryParse(Console.ReadLine(), out int value) && value >= minValue)
                return value;
            Console.WriteLine($"Input must be an integer greater than or equal to {minValue}. Please try again.");
        }
    }

    // Method to prompt for a valid date in the specified format
    static DateTime PromptForDateTime(string message)
    {
        while (true)
        {
            Console.Write(message);
            if (DateTime.TryParseExact(Console.ReadLine(), "mm-dd-yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime value) && value <= DateTime.Now)
                return value;
            Console.WriteLine("Invalid date. Please enter a valid date in the format mm-dd-yyyy that is not in the future.");
        }
    }

    // Method to prompt for a valid shift enum value
    static Shift PromptForShift(string message)
    {
        while (true)
        {
            Console.Write(message);
            if (int.TryParse(Console.ReadLine(), out int value) && Enum.IsDefined(typeof(Shift), value))
                return (Shift)value;
            Console.WriteLine("Invalid shift value. Enter 1 for Day or 2 for Night.");
        }
    }

    // Method to prompt for a double with a minimum value
    static double PromptForDouble(string message, double minValue = double.MinValue)
    {
        while (true)
        {
            Console.Write(message);
            if (double.TryParse(Console.ReadLine(), out double value) && value >= minValue)
                return value;
            Console.WriteLine($"Input must be a number greater than or equal to {minValue}. Please try again.");
        }
    }

    // Method to prompt for a float with a minimum value
    static float PromptForFloat(string message, float minValue = float.MinValue)
    {
        while (true)
        {
            Console.Write(message);
            if (float.TryParse(Console.ReadLine(), out float value) && value >= minValue)
                return value;
            Console.WriteLine($"Input must be a number greater than or equal to {minValue}. Please try again.");
        }
    }
}
