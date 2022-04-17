using System;

namespace app4
{
    class Program
    {
        static void Main(string[] args)
        {
            // task # 1
            Console.WriteLine("Enter number of rows");
            int rows = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter number of columns");
            int columns = int.Parse(Console.ReadLine());
            int[,] matrix = new int [rows,columns];
            int summ = 0;
            Random randomValue = new Random();
            Console.WriteLine("Your matrix values are:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    int value = randomValue.Next(-100, 101);
                    matrix[i, j] = value;
                    summ += value;
                    Console.Write($"{value.ToString()}\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Total summ of matrix values is: {summ.ToString()}");
            Console.ReadKey();
            Console.Clear();

            // task # 2
            Console.WriteLine("Enter length of array");
            int arraySize = int.Parse(Console.ReadLine());
            int[] array = new int[arraySize];
            Console.WriteLine("Please enter values for each index");
            //array[0] = int.MaxValue;
            for (int i = 0; i < arraySize; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }
            // array sorting
            for (int i = arraySize; i >= 0; i--)
            {
                for (int j = 0; j < i - 1; j++)
                {
                    if(array[j] > array[j+1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
            // array print
            Console.WriteLine("Sorted array values are:");
            for (int i = 0; i < arraySize; i++)
            {
                Console.Write($"{array[i].ToString()}\t");
            }
            Console.ReadKey();
            Console.Clear();

            // task # 3
            Console.WriteLine("Enter positive integer for guessing range");
            int range = int.Parse(Console.ReadLine());
            Random randomGuess = new Random();
            int numberToGuess = randomGuess.Next(range);
            Console.WriteLine("Try to guess the number");
            while (true)
            {
                string userInput = Console.ReadLine();
                if(userInput == String.Empty)
                {
                    Console.WriteLine($"Ending guess game, the number was {numberToGuess.ToString()}");
                    break;
                }
                int userGuess = int.Parse(userInput);
                if(userGuess == numberToGuess)
                {
                    Console.WriteLine("Congratulations !!! You guess it");
                    break;
                }
                else if(userGuess > numberToGuess)
                {
                    Console.WriteLine("Try lower number");
                }
                else
                {
                    Console.WriteLine("Try higher number");
                }
            }
        }
    }
}
