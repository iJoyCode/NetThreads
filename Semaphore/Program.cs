using System;
using System.Threading;

namespace Semaphore
{
    internal class Program
    {
        static System.Threading.Semaphore semaphore = new System.Threading.Semaphore(0, 4);

        private static void Main(string[] args)
        {
            var threads = new Thread[10];

            for (var i = 0; i < 10; i++)
            {
                threads[i] = new Thread(Log);
            }

            for (var i = 0; i < 10; i++)
            {
                threads[i].Start();
            }

            semaphore.Release(4);
            Console.ReadLine();
            semaphore.Release(4);
            Console.ReadLine();
            semaphore.Release(4);
        }

        public static void Log()
        {
            semaphore.WaitOne();
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        }
    }
}