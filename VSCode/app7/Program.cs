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
            // declaring repo instance
            StaffRepository staffRepository = new StaffRepository(pathToFile, fileName);
            // main loop
            char inputKey = '0';
            do
            {
                // announce start
                Console.Clear();
                Console.WriteLine("Please choose option \n 1 - Print current data in file \n 2 - Enter new data and append to file \n any other key to return or exit");
                Console.WriteLine();
                inputKey = Console.ReadKey().KeyChar;
                switch (inputKey)
                {
                    case '1': // printing
                    Console.Clear();
                    PrintStaffContents(staffRepository.ReadRepository());
                    Console.ReadKey();
                    break;
                    case '2': // inputing
                    Console.Clear();
                    AddNewStaff(staffRepository);
                    Console.ReadKey();
                    break;
                    default: break;
                }
            } while (inputKey == '1' || inputKey == '2');
            Console.WriteLine();
            Console.WriteLine("Program is exitting");
        }
        public static void PrintStaffContents(Staff[] staffRepo)
        {
            if(staffRepo.Length > 0)
            {
                Console.WriteLine("ID                      Date of Record          Full Name               Age                     Reach                   Date of birth           Birthplace");
                for (int i = 0; i < staffRepo.Length; i++)
                {
                    Console.Write($"{staffRepo[i].ID,-20}\t");
                    Console.Write($"{staffRepo[i].RecordDate.ToString("dd.mm.yyyy hh:mm"),-20}\t");
                    Console.Write($"{staffRepo[i].FullName,-20}\t");
                    Console.Write($"{staffRepo[i].Age,-20}\t");
                    Console.Write($"{staffRepo[i].Reach,-20}\t");
                    Console.Write($"{staffRepo[i].DateOfBirth,-20}\t");
                    Console.Write($"{staffRepo[i].BirthPlace,-20}\t");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Staff repository is empty, please choose option to enter new staff or exit");
            }
        }

        public static void AddNewStaff(StaffRepository sr)
        {
            Console.WriteLine("Enter your data per each key");
            // Full Name
            Console.WriteLine("Enter Full Name");
            string fullName = Console.ReadLine();
            // Age
            Console.WriteLine("Enter Age");
            int age = int.Parse(Console.ReadLine());
            // Reach
            Console.WriteLine("Enter Reach");
            int reach = int.Parse(Console.ReadLine());
            // DoB
            Console.WriteLine("Enter Date of Birth in DD.MM.YYYY");
            DateTime dob = DateTime.Parse(Console.ReadLine());
            // Birthplace
            Console.WriteLine("Birth place");
            string birthPlace = Console.ReadLine();
            Console.WriteLine("New staff info gathered, press any key to Continue");
            Staff staff = new Staff(fullName, age, dob, reach, birthPlace);
            sr.AddStaff(staff);
        }
    }
}