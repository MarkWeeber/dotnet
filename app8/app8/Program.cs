using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;

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
            Console.WriteLine("\nPrinting random numbers after removing between 20 and 50");
            randomNumbers.RemoveAll(s => (s > 20 && s < 50));
            PrintList(randomNumbers);

            // task # 2
            Console.ReadKey();
            Console.Clear();
            Dictionary<string, string> phoneBook = new Dictionary<string, string>();
            string inputString = "";
            do
            {
                Console.Clear();
                Console.WriteLine("Enter Person's phone number");
                inputString = Console.ReadLine().ToString().Trim();
                string phoneNumber = inputString;
                if (inputString == String.Empty)
                {
                    break;
                }
                Console.WriteLine("Enter Person's name");
                inputString = Console.ReadLine().ToString().Trim();
                string name = inputString.Trim();
                if (inputString == String.Empty)
                {
                    break;
                }
                phoneBook.Add(phoneNumber, name);
            } while (true);
            PrintDictionary(phoneBook);
            // finding the value per key
            Console.WriteLine("Search Person by it's phone number\nEnter phone number: ");
            inputString = Console.ReadLine().ToString();
            string value = "";
            if (FindInDictionary(inputString, phoneBook, out value))
            {
                Console.WriteLine("Found a person per this number: {0}", value);
            }
            else
            {
                Console.WriteLine("No person found per this number");
            }

            // task # 3
            Console.ReadKey();
            Console.Clear();
            HashSet<int> setOfNumbers = new HashSet<int>();
            int newNumber = -1;
            do
            {
                Console.Clear();
                Console.WriteLine("Enter a number for Set");
                newNumber = GetValidNumberFromInput();
                if (!setOfNumbers.Contains(newNumber))
                {
                    setOfNumbers.Add(newNumber);
                    Console.WriteLine("Number successfully added");
                }
                else
                {
                    Console.WriteLine("Number already added, try different");
                }
                Console.WriteLine("Number enter loop finished, please press Enter to enter new number, or or any other to key to continue");
                if (Console.ReadKey().Key != ConsoleKey.Enter)
                {
                    break;
                }

            } while (true);
            Console.WriteLine("Your HashSet contents: ");
            PrintHashSet(setOfNumbers);

            // task # 4
            Console.ReadKey();
            string inputStringData = "";
            do
            {
                Console.Clear();
                Console.WriteLine("Please enter fill your notebook with new person details\n =================");
                // Name
                Console.WriteLine("Please enter Person's Name: ");
                inputStringData = Console.ReadLine().ToString();
                XElement person = new XElement("Person");
                XAttribute personFullName = new XAttribute("name", inputStringData);
                // Streed address
                Console.WriteLine("Please enter Address street name: ");
                inputStringData = Console.ReadLine().ToString();
                XElement street = new XElement("Street");
                street.Add(inputStringData);
                // House number
                Console.WriteLine("Please enter Address house number: ");
                inputStringData = Console.ReadLine().ToString();
                XElement houseNumber = new XElement("HouseNumber");
                houseNumber.Add(inputStringData);
                // Flat number
                Console.WriteLine("Please enter Flat number: ");
                inputStringData = Console.ReadLine().ToString();
                XElement flatNumber = new XElement("FlatNumber");
                flatNumber.Add(inputStringData);
                // Mobile phone
                Console.WriteLine("Please enter Person's mobile phone number: ");
                inputStringData = Console.ReadLine().ToString();
                XElement mobilePhone = new XElement("MobilePhone");
                mobilePhone.Add(inputStringData);
                // Flat phone
                Console.WriteLine("Please enter Person's flat phone number: ");
                inputStringData = Console.ReadLine().ToString();
                XElement flatPhone = new XElement("FlatPhone");
                flatPhone.Add(inputStringData);

                // combining elements
                XElement address = new XElement("Address");
                address.Add(street, houseNumber, flatNumber);
                XElement phones = new XElement("Phones");
                phones.Add(mobilePhone, flatPhone);
                person.Add(personFullName, address, phones);
                person.Save("notebook.xml");
                Console.WriteLine("Person added to notebook, please any key to continue");
                Console.ReadKey();
            } while (false);
            
            // program end
            Console.WriteLine("\nProgram finished, press any key to exit");
            Console.ReadKey();
        }

        public static void FillListWithRandomNumbers(ref List<int> list, int size, int minValue, int maxValue)
        {
            Random rnd = new Random();
            for (int i = 0; i < size; i++)
            {
                list.Add(rnd.Next(minValue, maxValue + 1));
            }
        }

        public static void PrintList<T>(List<T> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if(i % 10 == 0)
                {
                    Console.WriteLine();
                }
                Console.Write($"{list[i].ToString(),-5}\t");
            }
        }

        public static void PrintDictionary<T>(Dictionary<T, T> dict)
        {
            foreach (var item in dict)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public static void PrintHashSet<T>(HashSet<T> hashSet)
        {
            foreach (var item in hashSet)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public static bool FindInDictionary(string key, Dictionary<string, string> dict, out string value)
        {
            bool ans = false;
            value = "";
            foreach (var item in dict)
            {
                if (dict.TryGetValue(key, out value))
                {
                    ans = true;
                    break;
                }
            }
            return ans;
        }
        public static int GetValidNumberFromInput()
        {
            int ans = -1;
            string userInput = Console.ReadLine().ToString();
            if (!int.TryParse(userInput, out ans))
            {
                Console.WriteLine("Please enter a valid number");
                ans = GetValidNumberFromInput();
            }
            return ans;
        }
    }
}