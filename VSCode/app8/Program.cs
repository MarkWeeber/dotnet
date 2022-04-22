using System;
using System.IO;
using System.Text;

namespace app8
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // task # 1
            List<int> randomNumbers = new List<int>();
            FillListWithRandomNumbers(ref randomNumbers, 100, 0, 100);
            Console.Clear();
            Console.WriteLine("Printing random numbers");
            PrintList(randomNumbers);
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Printing random numbers after removing");
            randomNumbers.RemoveAll(s => (s > 20 && s < 50));
            PrintList(randomNumbers);

            // task # 2
            Dictionary<string, string> phoneBook = new Dictionary<string, string>();
            string inputString = "";
            do
            {
                Console.Clear();
                Console.WriteLine("Enter Person's phone number");
                inputString = Console.ReadLine().ToString();
                string phoneNumber = inputString.Trim();
                if(inputString == "")
                {
                    break;
                }
                Console.WriteLine("Enter Person's name");
                inputString = Console.ReadLine().ToString();
                string name = inputString.Trim();
                if(inputString == "")
                {
                    break;
                }
                phoneBook.Add(phoneNumber, name);
            } while (true);
            PrintDictionary(phoneBook);
        }

        public static void FillListWithRandomNumbers(ref List<int> list, int size, int minValue, int maxValue)
        {
            Random rnd = new Random();
            for (int i = 0; i < size; i++)
            {
                list.Add(rnd.Next(minValue, maxValue+1));
            }
        }

        public static void PrintList<T>(List<T> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public static void PrintDictionary<T>(Dictionary<T,T> dict)
        {
            foreach (var item in dict)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public static void FindInDictionary()
        {

        }
    }
}