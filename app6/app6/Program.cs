using System;
using System.IO;
using System.Text;

namespace app6
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "staff.txt";
            string pathToFile = Directory.GetCurrentDirectory() + @"\files\";
            char inputKey = '0';
           
            // main loop
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
                    PrintFileContent(pathToFile, fileName);
                    Console.ReadKey();
                    break;
                    case '2': // inputing
                    Console.Clear();
                    WriteToFile(pathToFile, fileName);
                    Console.ReadKey();
                    break;
                    default: break;
                }
            } while (inputKey == '1' || inputKey == '2');
            Console.WriteLine();
            Console.WriteLine("Program is exitting");
        }

        public static void WriteToFile (string pathToFile, string fileName)
        {
            string filePath = pathToFile + fileName;
            // create if not present then create
            if (!File.Exists(filePath))
            {
                Directory.CreateDirectory(pathToFile);
                File.Create(filePath).Close();
            }
            // get last incrementor
            int incrementor = GetLastIncrementor(filePath);
            if(incrementor == -1)
            {
                incrementor = 1;
            }
            else
            {
                incrementor++;
            }
            // start input
            using (StreamWriter streamWriter = new StreamWriter (filePath, true, Encoding.Unicode))
            {
                // announce
                Console.WriteLine("Enter your data per each key");
                string dataRow = String.Empty;
                do
                {
                    // ID
                    dataRow += incrementor + "#";
                    // Date
                    dataRow += DateTime.Now.ToString("dd.mm.yyyy hh:mm") + "#";
                    // Full Name
                    Console.WriteLine("Enter Full Name");
                    dataRow += Console.ReadLine() + "#";
                    // Age
                    Console.WriteLine("Enter Age");
                    dataRow += int.Parse(Console.ReadLine()) + "#";
                    // Reach
                    Console.WriteLine("Enter Reach");
                    dataRow += int.Parse(Console.ReadLine()) + "#";
                    // DoB
                    Console.WriteLine("Enter Date of Birth in DD.MM.YYYY");
                    dataRow += DateTime.Parse(Console.ReadLine()).ToString("dd.mm.yyyy") + "#";
                    // Birthplace
                    Console.WriteLine("Birth place");
                    dataRow += Console.ReadLine() + "#";
                    Console.WriteLine("New staff info gathered, press any key to Continue");
                    if(dataRow != String.Empty)
                    {
                        streamWriter.WriteLine(dataRow);
                        break;
                    }
                } while (true);
            }
        }

        public static int GetLastIncrementor (string filePath)
        {
            int ans = -1;
            using (StreamReader streamReader = new StreamReader(filePath, Encoding.Unicode))
            {
                var streamFirstRead = streamReader.ReadLine();
                if(streamFirstRead != null)
                {
                    ans = int.Parse(streamFirstRead.ToString().Split("#")[0]);
                }
                streamReader.Close();
            }
            return ans;
        }

        public static void PrintFileContent (string pathToFile, string fileName)
        {
            string filePath = pathToFile + fileName;
            // give message if no file is present
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not created yet, please choose option to enter new data or exit\n");
            }
            // start printing
            else 
            {
                using (StreamReader streamReader = new StreamReader(filePath, Encoding.Unicode))
                {
                    if(streamReader.EndOfStream)
                    {
                        Console.WriteLine("The file is empty");
                    }
                    else
                    {
                        Console.WriteLine("Printing your data :");
                        Console.WriteLine("ID                      Date of Record          Full Name               Age                     Reach                   Date of birth           Birthplace");
                        while (!streamReader.EndOfStream)
                        {
                            string [] rowData = streamReader.ReadLine().Split("#");
                            for (int i = 0; i < rowData.Length; i++)
                            {                                
                                Console.Write($"{rowData[i],-20}\t");
                            }
                            Console.WriteLine();
                        }
                    }
                    Console.WriteLine("Press Any key to continue");
                    streamReader.Close();
                }
            }
        }
    }
}