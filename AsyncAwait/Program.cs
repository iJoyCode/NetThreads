using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var task = Job();
            Job().Wait();

            Console.WriteLine(task.Result);
        }

        public static async Task<int> Job()
        {
            return await Task.Run(() =>
            {
                Thread.Sleep(1000);
                return 1;
            });
        }
    }
}