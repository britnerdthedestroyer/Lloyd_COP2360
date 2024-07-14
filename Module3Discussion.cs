/*I made this based on an assignment I did in Java a month and a half ago
forgive me if some concepts I used weren't talked about yet
I'm mostly trying to get used to the differences in syntax
and I'm trying not to type in the wrong language*/
using System;

public class Module3Discussion
{
    public static void Main(string[] args)
    {
        try
        {
            // Create two Rectangle objects by prompting user for dimensions
            Rectangle rect1 = CreateRectangle("first");
            Rectangle rect2 = CreateRectangle("second");

            // Display dimensions and area of the first rectangle
            Console.WriteLine("The dimensions of the first rectangle are");
            rect1.ShowData();
            Console.Write("The area of the first rectangle is ");
            ShowArea(rect1);

            // Display dimensions and area of the second rectangle
            Console.WriteLine("The dimensions of the second rectangle are");
            rect2.ShowData();
            Console.Write("The area of the second rectangle is ");
            ShowArea(rect2);

            // Comparing the two rectangles
            CompareRectangles(rect1, rect2);

            // Deconstruction examples
            (float x, float y) = rect1;
            Console.WriteLine($"Deconstructed dimensions of first rectangle: {x} x {y}");

            (float x2, float y2) = rect2;
            Console.WriteLine($"Deconstructed dimensions of second rectangle: {x2} x {y2}");
        }
        catch (Exception ex)
        {
            // Handle any exceptions that I may have forgotten
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    // Method to create a Rectangle object based on user input
    public static Rectangle CreateRectangle(string order)
    {
        while (true)
        {
            try
            {
                // Prompt user for width (with exception handling)
                Console.Write($"Enter width of the {order} rectangle >> ");
                float width = float.Parse(Console.ReadLine());
                if (width <= 0) throw new ArgumentOutOfRangeException("Width must be positive.");

                // Prompt user for height (with exception handling)
                Console.Write($"Enter height of the {order} rectangle >> ");
                float height = float.Parse(Console.ReadLine());
                if (height <= 0) throw new ArgumentOutOfRangeException("Height must be positive.");

                // Return new Rectangle object with provided dimensions
                return new Rectangle(width, height);
            }
            catch (FormatException)
            {
                // Handle invalid numerical input
                Console.WriteLine("Please enter valid numerical values.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                // Handle out-of-range values
                Console.WriteLine(ex.Message);
            }
        }
    }

    // Method to display the area of a given rectangle
    public static void ShowArea(Rectangle rect)
    {
        float area = rect.GetArea();
        Console.WriteLine(area);
    }

    // Method to compare the areas of two rectangles
    public static void CompareRectangles(Rectangle rect1, Rectangle rect2)
    {
        float area1 = rect1.GetArea();
        float area2 = rect2.GetArea();

        if (area1 > area2)
        {
            Console.WriteLine("The first rectangle is bigger.");
        }
        else if (area2 > area1)
        {
            Console.WriteLine("The second rectangle is bigger.");
        }
        else
        {
            Console.WriteLine("Both rectangles are the same size.");
        }
    }
}

// Rectangle class definition
public class Rectangle
{
    // Width and Height properties
    public readonly float Width, Height;

    // Constructor to initialize width and height
    public Rectangle(float width, float height)
    {
        Width = width;
        Height = height;
    }

    // Method to display the dimensions of the rectangle
    public void ShowData()
    {
        Console.WriteLine($"Width: {Width}  Height: {Height}");
    }

    // Method to calculate the area of the rectangle
    public float GetArea()
    {
        return Width * Height;
    }

    // Method to deconstruct the rectangle into width and height
    public void Deconstruct(out float width, out float height)
    {
        width = Width;
        height = Height;
    }
}
