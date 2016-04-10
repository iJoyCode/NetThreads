using System;
using System.Threading;

namespace Pulse
{
    internal class TickTock
    {
        private readonly object lockObj = new object();

        public void Tick()
        {
            lock (lockObj)
            {
                for (var i = 0; i < 5; i++)
                {
                    Console.WriteLine("Tick");
                    Thread.Sleep(500);
                    Monitor.Pulse(lockObj);
                    Monitor.Wait(lockObj);
                }
            }
        }

        public void Tock()
        {
            lock (lockObj)
            {
                for (var i = 0; i < 5; i++)
                {
                    Console.WriteLine("Tock");
                    Thread.Sleep(500);
                    Monitor.Pulse(lockObj);
                    Monitor.Wait(lockObj);
                }
            }
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            var tt = new TickTock();

            new Thread(tt.Tick).Start();
            new Thread(tt.Tock).Start();
        }
    }
}