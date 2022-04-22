using System;
using System.IO;
using System.Text;

namespace app7
{
    class Program
    {
        static void Main(string[] args)
        {
            // prerequisites
            string fileName = "staff.txt";
            string pathToFile = Directory.GetCurrentDirectory() + @"\files\";
            bool dataIsPresent = false;
            // declaring repo instance
            StaffRepository staffRepository = new StaffRepository(pathToFile, fileName);
            // main loop
            char inputKey = '0';
            do
            {
                // announce start
                Console.Clear();
                Console.WriteLine("Please choose option \n 1 - Work with current data \n 2 - Enter new data \n any other key to exit program");
                Console.WriteLine();
                inputKey = Console.ReadKey().KeyChar;
                switch (inputKey)
                {
                    case '1': // printing, viewing and other options
                        dataIsPresent = PrintStaffContents(staffRepository.ReadRepository());
                        if (dataIsPresent)
                        {
                            PrintViewOptions(staffRepository);
                        }
                        else Console.ReadKey();
                        break;
                    case '2': // inputing new staff info
                        AddNewStaff(staffRepository);
                        Console.ReadKey();
                        break;
                    default: break;
                }
            } while (inputKey == '1' || inputKey == '2');
            Console.WriteLine();
            Console.WriteLine("Program is exitting");
        }
        public static bool PrintStaffContents(Staff[] staffRepo)
        {
            Console.Clear();
            if (staffRepo.Length > 0)
            {
                Console.WriteLine("Index               ID                  Date of Record      Full Name           Age                 Reach               Date of birth       Birthplace");
                for (int i = 0; i < staffRepo.Length; i++)
                {
                    Console.Write($"{i + 1,-20}");
                    Console.Write($"{staffRepo[i].ID,-20}");
                    Console.Write($"{staffRepo[i].RecordDate.ToString("dd.MM.yyyy hh:mm"),-20}");
                    Console.Write($"{staffRepo[i].FullName,-20}");
                    Console.Write($"{staffRepo[i].Age,-20}");
                    Console.Write($"{staffRepo[i].Reach,-20}");
                    Console.Write($"{staffRepo[i].DateOfBirth.ToString("dd.MM.yyyy"),-20}");
                    Console.Write($"{staffRepo[i].BirthPlace,-20}\n");
                }
                return true;
            }
            else
            {
                Console.WriteLine("Staff repository is empty");
                return false;
            }
        }

        public static void PrintViewOptions(StaffRepository sr)
        {
            char inputKey = '0';
            do
            {
                Console.WriteLine(
                    @"
Please choose options :
Main commands:      1 - Refresh view            || 2 - View by specific ID  || 3 - View by given dates on birthdates || 4 - Edit row || 5 - Delete row || 
Sorting commands:   6 - Birthdate old to new    || 7 - Birthdate new to old || 8 - ID ascending || 9 - ID descending 
any other key to return"
                    );
                inputKey = Console.ReadKey().KeyChar;
                switch (inputKey)
                {
                    case '1': // refresh
                        PrintStaffContents(sr.ReadRepository());
                        PrintViewOptions(sr);
                        break;
                    case '2': // view by specific ID
                        PrintStaffContents(GetSpecificStaffInfoById(sr));
                        Console.ReadKey();
                        PrintStaffContents(sr.ReadRepository());
                        PrintViewOptions(sr);
                        break;
                    case '3': // view by specific dates
                        PrintStaffContents(GetSpecificStaffInfoByDates(sr));
                        Console.ReadKey();
                        PrintStaffContents(sr.ReadRepository());
                        PrintViewOptions(sr);
                        break;
                    case '4': // editting
                        PrintStaffContents(sr.ReadRepository());
                        EditStaff(sr);
                        PrintStaffContents(sr.ReadRepository());
                        break;
                    case '5': // deleting
                        PrintStaffContents(sr.ReadRepository());
                        DeleteStaff(sr);
                        PrintStaffContents(sr.ReadRepository());
                        break;
                    case '6': // sort by birthdates ascending
                        sr.SortByBirthDates(true);
                        PrintStaffContents(sr.ReadRepository());
                        PrintViewOptions(sr);
                        break;
                    case '7': // sort by id descending
                        sr.SortByBirthDates(false);
                        PrintStaffContents(sr.ReadRepository());
                        PrintViewOptions(sr);
                        break;
                    case '8': // sort by id ascending
                        sr.SortById(true);
                        PrintStaffContents(sr.ReadRepository());
                        PrintViewOptions(sr);
                        break;
                    case '9': // sort by id descending
                        sr.SortById(false);
                        PrintStaffContents(sr.ReadRepository());
                        PrintViewOptions(sr);
                        break;
                    default: break;
                }
            } while (inputKey == '4' || inputKey == '5');
        }

        public static void AddNewStaff(StaffRepository sr)
        {
            sr.AddStaff(CollectStaffInfoFromUser());
        }

        public static int GetValidNumberFromInput(int min = -1, int max = -1)
        {
            int ans = -1;
            string userInput = Console.ReadLine().ToString();
            if (!int.TryParse(userInput, out ans))
            {
                Console.WriteLine("Please enter a valid number");
                ans = GetValidNumberFromInput(min, max);
            }
            if ((min != -1 && max != -1) && (ans < min || ans > max))
            {
                Console.WriteLine("You need to enter between {0} and {1}", min, max);
                ans = GetValidNumberFromInput(min, max);
            }
            return ans;
        }

        public static DateTime GetValidDateTimeFromInput()
        {
            DateTime ans = DateTime.MinValue;
            string userInput = Console.ReadLine().ToString();
            if (!DateTime.TryParse(userInput, out ans))
            {
                Console.WriteLine("Please enter a valid date");
                ans = GetValidDateTimeFromInput();
            }
            return ans;
        }

        public static void EditStaff(StaffRepository sr)
        {
            Console.WriteLine("Select staff index to edit");
            int editStaffIndex = GetValidNumberFromInput(1, sr.RepoSize());
            sr.EditStaff(editStaffIndex - 1, CollectStaffInfoFromUser());
            Console.WriteLine("Staff info changed");
        }

        public static void DeleteStaff(StaffRepository sr)
        {
            Console.WriteLine("Select staff index to delete");
            int deleteStaffIndex = GetValidNumberFromInput(1, sr.RepoSize());
            sr.DeleteStaff(deleteStaffIndex - 1);
            Console.WriteLine("Staff deleted");
        }

        public static Staff CollectStaffInfoFromUser()
        {
            Console.WriteLine();
            Console.WriteLine("Enter Staff data per each key");
            // Full Name
            Console.WriteLine("Enter Full Name");
            string fullName = Console.ReadLine().ToString();
            // Age
            Console.WriteLine("Enter Age");
            int age = GetValidNumberFromInput();
            // Reach
            Console.WriteLine("Enter Reach");
            int reach = GetValidNumberFromInput();
            // DoB
            Console.WriteLine("Enter Date of Birth in DD.MM.YYYY");
            DateTime dob = GetValidDateTimeFromInput();
            // Birthplace
            Console.WriteLine("Birth place");
            string birthPlace = Console.ReadLine().ToString();
            Console.WriteLine("New staff info gathered");
            Staff staff = new Staff(fullName, age, dob, reach, birthPlace);
            return staff;
        }
        public static Staff[] GetSpecificStaffInfoById(StaffRepository sr)
        {
            Staff[] ans = new Staff[0];
            Staff[] repo = sr.ReadRepository();
            Console.WriteLine("\nEnter desired staff ID to view");
            int index = GetValidNumberFromInput();
            for (int i = 0; i < repo.Length; i++)
            {
                if (repo[i].ID == index)
                {
                    Array.Resize(ref ans, 1);
                    ans[0] = repo[i];
                    break;
                }
            }
            return ans;

        }
        public static Staff[] GetSpecificStaffInfoByDates(StaffRepository sr)
        {
            Staff[] ans = new Staff[0];
            Staff[] repo = sr.ReadRepository();
            Console.WriteLine("\nEnter date from");
            DateTime dateFrom = GetValidDateTimeFromInput();
            Console.WriteLine("\nEnter date to");
            DateTime dateTo = GetValidDateTimeFromInput();
            int index = 0;
            for (int i = 0; i < repo.Length; i++)
            {
                if (DateTime.Compare(dateFrom, repo[i].DateOfBirth) < 0 && DateTime.Compare(dateTo, repo[i].DateOfBirth) > 0)
                {
                    Array.Resize(ref ans, ans.Length + 1);
                    ans[index] = repo[i];
                    index++;
                }
            }
            return ans;
        }
    }
}