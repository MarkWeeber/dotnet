using System;

namespace app5
{
    class Program
    {
        static void Main(string[] args)
        {
            // task # 1
            Console.WriteLine("Please type your sentence");
            string userSentence = Console.ReadLine();
            string[] words = GetWordsFromPhrase(userSentence);
            PrintWordsArray(words);
            Console.ReadKey();
            Console.Clear();

            // task # 2
            Console.WriteLine("Please type your sentence for reverse");
            Console.WriteLine(ReverseWords(GetWordsFromPhrase(Console.ReadLine())));

        }

        private static string[] GetWordsFromPhrase(string phrase)
        {
            return phrase.Split(' ');
        }

        private static void PrintWordsArray(string[] wordsArray)
        {
            foreach (string item in wordsArray)
            {
                Console.WriteLine(item);
            }
        }

        private static string ReverseWords(string[] wordsArray)
        {
            string result = String.Empty;
            Array.Reverse(wordsArray);
            foreach (string item in wordsArray)
            {
                result += item + " ";
            }
            result = result.Trim();
            return result;
        }
    }
}
