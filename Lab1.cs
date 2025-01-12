using System.Drawing;
using System;
using System.Diagnostics.CodeAnalysis;

// The solutions should be defined using methods and appropriately called in the main function.

// 1. Write a program to calculate the discriminant (delta) and roots of a quadratic equation.

class ExerciseOne()
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
    static double TryConvert(string var_name)
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

//  2.  Write a calculator program that computes:
//      Sum, Difference, Product, Quotient, Power, Square root, Trigonometric function values for a given angle

