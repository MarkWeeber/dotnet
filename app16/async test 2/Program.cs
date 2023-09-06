using System;
using System.Threading;
using System.Threading.Tasks;

namespace async_test_2
{
    class Program
    {
        static int x = 1;
        static void Main(string[] args)
        {
            Console.WriteLine("Main Start");
            Task t1 = new Task(SomeMethod);
            t1.Start();
            //t1.Wait();
            Task t2 = new Task(SomeMethod2);
            t2.Start();
            //t2.Wait();
            //SomeMethod();
            //AsyncMethod1();
            //AsyncMethod2();
            //Task1();
            Thread.Sleep(10000);
            Console.WriteLine($"Main End, x = {x}");
        }

        private static void SomeMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"1st: {i+1}");
                Thread.Sleep(10);
            }
            x++;
        }

        private static void SomeMethod2()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"2nd: {i + 1}");
                Thread.Sleep(10);
            }
            x++;
        }

        private static async void AsyncMethod1()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("+");
                await Task.Delay(10);
            }
        }

        private static async void AsyncMethod2()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("-");
                await Task.Delay(10);
            }
        }

        private static async void Task1()
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("X");
                }
            });
        }
    }
}
