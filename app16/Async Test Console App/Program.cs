using System;
using System.Threading.Tasks;

namespace Async_Test_Console_App
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //Test();
            //Test2();
            //await RunAB();
            await Task.WhenAll(Program.RunAB(), Program.RunBA());
            //Task<int> taskName = Task.Run(() =>
            //{
            //    int ans = 0;
            //    for (int i = 0; i < 5; i++)
            //    {
            //        ans += i;
            //    }
            //    return ans;
            //});
            //await Task.Delay(3000);
            //Console.WriteLine("NEXT UP");
            //int x = await taskName;
            //Console.WriteLine($" {x}");
        }

        private static async void Test()
        {
            await Task.Delay(0);
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"1st: {i}");
            }
        }

        private static async void Test2()
        {
            await Task.Delay(0);
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"2nd: {i}");
            }
        }

        private static async Task<string> GetName(string name)
        {
            await Task.Delay(0);
            string ans = "";
            return ans;
        }

        private static async Task RunAB()
        {
            await Task.Run(() =>
            {
                float z = 0;
                for (int i = 0; i < 10; i++)
                {
                    for (int x = 0; x < 1000; x++)
                    {
                        z += x * i;
                    }
                    Console.WriteLine($"AB = {i + 1} result = {z.ToString()}");
                }
            });
        }

        private static async Task RunBA()
        {
            await Task.Run(() =>
            {
                float z = 0;
                for (int i = 0; i < 10; i++)
                {
                    for (int x = 0; x < 1000; x++)
                    {
                        z += x * i;
                    }
                    Console.WriteLine($"BA = {i + 1} result = {z.ToString()}");
                }
            });
        }

        private static async Task RunAA()
        {
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(10);
                Console.WriteLine($"AA = {i + 1}");
            }
        }

        private static async Task RunBB()
        {
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(10);
                Console.WriteLine($"BB = {i + 1}");
            }
        }
    }
}
