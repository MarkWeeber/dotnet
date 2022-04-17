using System;

namespace app3
{
    class Program
    {
        static void Main(string[] args)
        {
            // task # 1
            Console.WriteLine("Enter desired number");
            int value = 0;
            value = int.Parse(Console.ReadLine());
            if (value % 2 == 0)
            {
                Console.WriteLine("you enterred even number");
            }
            else
            {
                Console.WriteLine("you enterred odd number");
            }
            Console.ReadKey();
            Console.Clear();

            // task # 2
            Console.WriteLine("How Many Cards Do You Have?");
            int cardsQuantity = 0;
            cardsQuantity = int.Parse(Console.ReadLine());
            int cardsSumm = 0;
            for (int i = 0; i < cardsQuantity; i++)
            {
                Console.WriteLine($"Enter card value for card number {(i+1).ToString()}");
                string cardValue = Console.ReadLine();
                int cardNumericValue = 0;
                char cardValueCharacter = 'A';
                // check if this is a valid digit
                if( int.TryParse(cardValue, out cardNumericValue) )
                {
                    cardsSumm += cardNumericValue;
                }
                else if( Char.TryParse(cardValue, out cardValueCharacter) )
                {
                    cardValueCharacter = Char.ToUpper(cardValueCharacter);
                    switch (cardValueCharacter)
                    {
                        case 'J':
                            cardNumericValue = 11;
                        break;
                        case 'Q':
                            cardNumericValue = 12;
                        break;
                        case 'K':
                            cardNumericValue = 13;
                        break;
                        case 'T':
                            cardNumericValue = 14;
                        break;
                        default: break;
                    }
                    cardsSumm += cardNumericValue;
                }
            }
            Console.WriteLine($"Your Hand Value is : {cardsSumm.ToString()}");
            Console.ReadKey();
            Console.Clear();

            // task # 3
            Console.WriteLine("Enter a prime number");
            int number = int.Parse(Console.ReadLine());
            bool isNotPrimeNumber = false;
            int divisor = 1;
            while(!isNotPrimeNumber)
            {
                divisor++;
                if(number % divisor == 0)
                {
                    isNotPrimeNumber = true;
                }
                if(divisor >= number - 1)
                {
                    break;
                }
            }
            if(isNotPrimeNumber)
            {
                Console.WriteLine($"{number.ToString()} is Not a prime number!");
            }
            else
            {
                Console.WriteLine($"{number.ToString()} is indeed  a prime number!");
            }
        }
    }
}
