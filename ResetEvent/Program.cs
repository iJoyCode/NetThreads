using System;
using System.Threading;

namespace ResetEvent
{
    internal class Work
    {
        private readonly AutoResetEvent evt;

        public Work(AutoResetEvent evt)
        {
            this.evt = evt;
            new Thread(Run).Start();
        }

        public void Run()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Done!");

            evt.Set();
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            var evt = new AutoResetEvent(false);
            var work = new Work(evt);

            evt.WaitOne();

            Console.WriteLine("MainThread is ready");
        }
    }
}