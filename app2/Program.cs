using System;

namespace app
{
    public class Programm
    {
        public static void Main(string[] args)
        {
            // task # 1
            // variables
            string fullName = "John Perkins";
            int age = 48;
            string e_mailAddress = "jperkins@microsoft.com";
            double computerScienceScore = 78.5;
            double mathScore = 61.3;
            double physicsScore = 45.9;
            // formatted output
            Console.WriteLine($"--== BIO INFORMATION ==--\nFull name:\t{fullName}\nAge:\t\t{age}\ne-mail:\t\t{e_mailAddress}\n--== SCORES ==--\nComputer Science:\t{computerScienceScore.ToString("#.##")}\nMath:\t\t\t{mathScore.ToString("#.##")}\nPhysics:\t\t{physicsScore.ToString("#.##")}");

            //task # 2
            // variables
            double summ = 0;
            summ = computerScienceScore + mathScore + physicsScore;
            double average = 0;
            average = summ / 3;
            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine($"TOTAL SCORE:\t\t{summ.ToString("#.##")}\nAVERAGE SCORE:\t\t{average.ToString("#.##")}");
        }
    }
}