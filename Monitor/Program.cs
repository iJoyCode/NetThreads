using System;
using System.Threading;

namespace Monitor
{
    internal class Numbers
    {
        private readonly object lockObj = new object();

        public void ShowNumbers()
        {
            System.Threading.Monitor.Enter(lockObj);

            var r = new Random();

            for (var i = 0; i < 10; i++)
            {
                Thread.Sleep(r.Next(3000));
                Console.Write(i);
            }
            Console.WriteLine();

            System.Threading.Monitor.Exit(lockObj);
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            var numbers = new Numbers();

            var threads = new Thread[10];

            for (var i = 0; i < 10; i++)
            {
                threads[i] = new Thread(numbers.ShowNumbers);
            }

            for (var i = 0; i < 10; i++)
            {
                threads[i].Start();
            }
        }
    }
}