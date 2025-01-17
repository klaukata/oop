using System.Drawing;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;
using System.ComponentModel;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography;
using System.Xml.Linq;
using System.Diagnostics;


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
    static void MainTwo() // there can be only one Main method in a single .cs file. Remove "Two" from this method name for it to work
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
            switch (choice)
            {
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
        if (b == 0)
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


/*  3. Write a program that allows input of 10 real numbers into an array. Then, implement the following functionalities using a for loop:
*    -  Display the array from the first to the last index.
*    -  Display the array from the last to the first index.
*    -  Display elements with odd indexes.
*    -  Display elements with even indexes.
*    Display the results of the algorithms in the console. Create a menu to select the above functionalities. Use an extended else-if construct and a do-while loop to manage the menu.  */

class ExerciseThree
{
    static void MainThree() // there can be only one Main method in a single .cs file. Remove "Three" from this method name for it to work
    {
        double[] tbl = FillArray();

        bool is_running = true;
        do
        {
            Console.WriteLine("============MENU============");
            Console.WriteLine("1. Display the array from the first to the last index");
            Console.WriteLine("2. Display the array from the last to the first index");
            Console.WriteLine("3. Display elements with odd indexes");
            Console.WriteLine("4. Display elements with even indexes");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option (1-5): ");

            string selected_option = Console.ReadLine();

            if (selected_option == "1")
            {
                for (int i = 0; i < tbl.Length; i++)
                {
                    Console.Write($"{tbl[i]} ");
                }
            }
            else if (selected_option == "2")
            {
                for (int i = tbl.Length - 1; i >= 0; i--)
                {
                    Console.Write($"{tbl[i]} ");
                }
            }
            else if (selected_option == "3")
            {
                for (int i = 1; i < tbl.Length; i = i + 2)
                {
                    Console.Write($"{tbl[i]} ");
                }
            }
            else if (selected_option == "4")
            {
                for (int i = 0; i < tbl.Length; i = i + 2)
                {
                    Console.Write($"{tbl[i]} ");
                }
            }
            else if (selected_option == "5")
            {
                Console.WriteLine("Bye!");
                is_running = false;
            }
            else
            {
                Console.WriteLine("Invalid option. Please choose a valid number (1-5).");
            }
            Console.WriteLine();

        }
        while (is_running);
    }

    public static double[] FillArray()
    {
        double[] tbl = new double[10];
        Console.WriteLine($"Time to fill an array!");
        for (int i = 0; i < tbl.Length; i++)
        {
            Console.Write($"Enter number {i + 1}: ");

            while (!double.TryParse(Console.ReadLine(), out tbl[i]))
            {
                Console.WriteLine("A string provided cannot be converted to a double. Try again.");
                Console.Write($"Enter number {i + 1}: ");
            }
        }
        return tbl;

    }
}


/*  4. Write a program that allows input of 10 numbers. For the entered numbers, perform the following algorithms:
*   - Calculate the sum of the array elements.
*   - Calculate the product of the array elements.
*   - Determine the average value.
*   - Determine the minimum value.
*   - Determine the maximum value.
*   Display the results of the algorithms on the console.   */

class ExerciseFour
{
    static void MainFour()  // there can be only one Main method in a single .cs file. Remove "Four" from this method name for it to work
    {
        double[] tbl = ExerciseThree.FillArray();
        double sum = tbl[0], product = tbl[0];
        double min = tbl[0], max = tbl[0];
        for (int i = 1; i < tbl.Length; i++)
        {
            double val = tbl[i];
            sum += val;
            product *= val;
            if (val < min)
            {
                min = val;
            }
            if (val > max)
            {
                max = val;
            }
        }
        double avg = sum / tbl.Length;
        Console.WriteLine($"sum = {sum}; product = {product}; average = {avg}; min = {min}; max = {max}");
    }
}


// 5. Write a program that displays numbers from 20 to 0, excluding the numbers {2, 6, 9, 15, 19}. To exclude these numbers, use the continue statement.

class ExerciseFive
{
    static void MainFive()  // there can be only one Main method in a single .cs file. Remove "Five" from this method name for it to work
    {
        int[] excluded_numbers = { 2, 6, 9, 15, 19 };
        for (int num = 20; num >= 0; num--) // for every num <20; 0>
        {
            if (Array.Exists(excluded_numbers, x => x == num))  // if num is in excluded_numbers
            {
                continue;   // next iteration
            }
            Console.Write($"{num} ");

        }
    }
}


/*  6. Write a program that continuously asks the user for integers. 
*   The infinite loop should terminate when the user enters a number less than zero. Use the break statement to exit the infinite loop. */

class ExerciseSix
{
    static void MainSix()  // there can be only one Main method in a single .cs file. Remove "Six" from this method name for it to work
    {
        while (true)
        {
            Console.Write("Enter an ineger: ");
            int input;
            while (!int.TryParse(Console.ReadLine(), out input))    // validate an input
            {
                Console.WriteLine("Your input is not an integer. Try again.");
                Console.Write("Enter an integer: ");
            }
            if (input < 0)  // check exit condition
            {
                Console.WriteLine("Provided integer is smaller than 0. Bye!");
                break;
            }
        }
    }
}


// 7. Write a program that allows input of n numbers and sorts these numbers using the bubble sort or insertion sort method. Display the results on the console.

class ExerciseSeven
{
    static void MainSeven()  // there can be only one Main method in a single .cs file. Remove "Seven" from this method name for it to work
    {
        int n = InputN();
        while (n < 1)
        {
            Console.WriteLine("Length of an array can't be negative or zero.");
            n = InputN();

        }
        Console.WriteLine($"Enter values for the array now.");
        double[] arr = InputArrayValues(n);
        Console.WriteLine($"Unsorted array = [{PrintArray(arr)}]");
        ApplyInsertionSort(arr);
        Console.WriteLine($"Sorted array = [{PrintArray(arr)}]");
    }
    static int InputN()
    {
        Console.Write("Enter a length of an array: ");
        int len;
        while (!int.TryParse(Console.ReadLine(), out len))
        {
            Console.WriteLine("Provided value is not an integer.");
            Console.Write("Enter a length of an array: ");

        }
        return len;
    }

    static double[] InputArrayValues(int n)
    {
        double[] arr = new double[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Enter a value for index = {i}: ");
            double val;
            while (!double.TryParse(Console.ReadLine(), out val)) {
                Console.Write("Provided value is not a double. Try again: ");
            }
            arr[i] = val;
        }
        return arr;
    }

    static double[] ApplyInsertionSort(double[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
        {
            double key = arr[i];
            int j = i - 1;
            while (j >= 0 && arr[j] > key)
            {
                arr[j + 1] = arr[j];
                j = j - 1;
            }
            arr[j + 1] = key;
        }
        return arr;
    }

    static string PrintArray(double[] arr) {
        return string.Join(", ", arr);
    }
}