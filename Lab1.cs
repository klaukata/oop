using System.Drawing;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;
using System.ComponentModel;

// The solutions should be defined using methods and appropriately called in the main function.


// 1. Write a program to calculate the discriminant (delta) and roots of a quadratic equation.

class ExerciseOne
{
    static void MainOne() // there can be only one Main method in a single .cs file. Remove "One" from this method name for it to work
    {
        double a = TryConvert("a");
        if (a == 0)
        {
            Console.WriteLine("Coefficient 'a' cannot be zero in a quadratic equation.");
            return;
        }
        double b = TryConvert("b");
        double c = TryConvert("c");
        Console.WriteLine($"Calculating {b}^2 - 4*{a}*{c}");
        CalculateDeltaAndRoots(a, b, c);
    }
    public static double TryConvert(string var_name)
    {
        while (true)
        {
            Console.Write($"Input a value of {var_name}: ");
            try
            {
                double converted_var = Convert.ToDouble(Console.ReadLine());
                return converted_var;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Couldn't convert a given input to a double data type because of an error: {e}. Try again.");
            }
        }
    }

    static void CalculateDeltaAndRoots(double a, double b, double c)
    {
        double delta = Math.Pow(b, 2) - 4 * a * c;
        Console.WriteLine($"Delta = {delta}");

        double x1, x2, x0;
        if (delta > 0)
        {
            x1 = (-b - Math.Sqrt(delta)) / (2 * a);
            x2 = (-b + Math.Sqrt(delta)) / (2 * a);
            Console.WriteLine($"x1 = {x1} and x2 = {x2}");
        }
        else if (delta == 0)
        {
            x0 = -b / (2 * a);
            Console.WriteLine($"x0 = {x0}");
        }
        else
        {
            Console.WriteLine("Delta is smaller than zero. This quadratic equasion has no solution.");
        }
    }
}

/* 2.  Write a calculator that computes: sum, difference, product, quotient, power, root, 
 * and values of trigonometric functions for a given angle. Use the Math library, e.g., Math.Sin(2.5). 
 * Please remember that the angle values passed to the functions are measured in radians. 
 * Display the results of the algorithms in the console. Use a switch-case construct 
 * and a while loop to handle the menu. */


class ExerciseTwo
{
    static void MainTwo() // there can be only one Main method in a single .cs file. Remove "One" from this method name for it to work
    {
        bool is_running = true;
        while (is_running)
        {
            Console.WriteLine("============CALCULATOR============");
            Console.WriteLine("Enter the number symbolising the operation you want to perform.");
            Console.WriteLine("1. Sum");
            Console.WriteLine("2. Difference");
            Console.WriteLine("3. Product");
            Console.WriteLine("4. Quotient");
            Console.WriteLine("5. Power");
            Console.WriteLine("6. Root");
            Console.WriteLine("7. Trigonometry");
            Console.WriteLine("8. End the program");

            int choice = (int)ExerciseOne.TryConvert("choice");
            switch (choice) {
                case 1:
                    Add();
                    break;
                case 2:
                    Diff();
                    break;
                case 3:
                    Product();
                    break;
                case 4:
                    Quotient();
                    break;
                case 5:
                    Power();
                    break;
                case 6:
                    Root();
                    break;
                case 7:
                    Trigonometry();
                    break;
                case 8:
                    Console.WriteLine("Ending the program. Goodbye!");
                    is_running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }
        }
    }

    static void Add()
    {
        double a = ExerciseOne.TryConvert("a");
        double b = ExerciseOne.TryConvert("b");
        Console.WriteLine($"{a} + {b} = {a + b}");
    }

    static void Diff()
    {
        double a = ExerciseOne.TryConvert("a");
        double b = ExerciseOne.TryConvert("b");
        Console.WriteLine($"{a} - {b} = {a - b}");
    }

    static void Product()
    {
        double a = ExerciseOne.TryConvert("a");
        double b = ExerciseOne.TryConvert("b");
        Console.WriteLine($"{a} * {b} = {a * b}");
    }

    static void Quotient()
    {
        double a = ExerciseOne.TryConvert("a");
        double b = ExerciseOne.TryConvert("b");
        if ( b == 0 )
        {
            Console.WriteLine("You can't devide by zero.");
            return;
        }
        Console.WriteLine($"{a} / {b} = {a / b}");
    }

    static void Power()
    {
        double a = ExerciseOne.TryConvert("a");
        double b = ExerciseOne.TryConvert("b");
        Console.WriteLine($"{a} ^ {b} = {Math.Pow(a, b)}");
    }

    static void Root()
    {
        double a = ExerciseOne.TryConvert("a");
        double b = ExerciseOne.TryConvert("b");
        if (b == 0)
        {
            Console.WriteLine("The 0th root of any number is undefined.");
            return;
        }
        Console.WriteLine($"{b}-th root of {a} = {Math.Pow(a, 1.0 / b)}");
    }

    static void Trigonometry()
    {
        double angle_degree = ExerciseOne.TryConvert("angle_degree");
        double angle_rad = angle_degree * Math.PI / 180;
        double sin, cos, tg, cot;
        sin = Math.Round(Math.Sin(angle_rad), 2);
        cos = Math.Round(Math.Cos(angle_rad), 2);
        tg = Math.Round(Math.Tan(angle_rad), 2);
        cot = Math.Abs(tg) < 1e-10 ? double.PositiveInfinity : Math.Round(1 / tg, 2);
        Console.WriteLine($"Entered angle in radians = {angle_rad}\n sin = {sin}\n cos = {cos}\n tg = {tg}\n cot = {cot}");
    }
}
