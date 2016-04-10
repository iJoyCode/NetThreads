using System;
using System.Threading;

namespace Mutex
{
    internal class SharedRes
    {
        public static int Count;
        public static System.Threading.Mutex mtx = new System.Threading.Mutex();
    }

    internal class IncThread
    {
        private int num;
        public Thread Thrd;

        public IncThread(string name, int n)
        {
            Thrd = new Thread(Run);
            num = n;
            Thrd.Name = name;
            Thrd.Start();
        }

        private void Run()
        {
            SharedRes.mtx.WaitOne();

            do
            {
                Thread.Sleep(500);
                SharedRes.Count++;
                Console.WriteLine("in Thread {0}, Count={1}", Thrd.Name, SharedRes.Count);
                num--;
            } while (num > 0);

            SharedRes.mtx.ReleaseMutex();
        }
    }

    internal class DecThread
    {
        private int num;
        public Thread Thrd;

        public DecThread(string name, int n)
        {
            Thrd = new Thread(Run);
            num = n;
            Thrd.Name = name;
            Thrd.Start();
        }

        // Точка входа в поток
        private void Run()
        {
            SharedRes.mtx.WaitOne();

            do
            {
                Thread.Sleep(500);
                SharedRes.Count--;
                Console.WriteLine("in Thread {0}, Count={1}", Thrd.Name, SharedRes.Count);
                num--;
            } while (num > 0);

            SharedRes.mtx.ReleaseMutex();
        }
    }

    internal class Program
    {
        private static void Main()
        {
            var mt1 = new IncThread("Inc thread", 5);

            Thread.Sleep(1);

            var mt2 = new DecThread("Dec thread", 5);

            mt1.Thrd.Join();
            mt2.Thrd.Join();
        }
    }
}