using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadReentranceProblem
{
    class Program
    {
        private static Cache<int> cachedInt;

        static void Main(string[] args)
        {
            cachedInt = new Cache<int>(
                async () =>
                {
                    //simulate some work
                    await Task.Delay(2000);
                    return 1;
                });

            DoWork();
            Console.ReadLine();
        }

        static async void DoWork()
        {
            Console.WriteLine(await cachedInt.Value);
            Console.WriteLine(await cachedInt.Value);
            Console.WriteLine(await cachedInt.Value);
        }
    }
}
