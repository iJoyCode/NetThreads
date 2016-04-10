using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPool
{
    class Program
    {
        private static readonly AutoResetEvent evt = new AutoResetEvent(false);
        private static int jobCount;

        static void Main()
        {
            int nWorkerThreads;
            int nCompletionThreads;

            System.Threading.ThreadPool.GetMaxThreads(out nWorkerThreads, out nCompletionThreads);

            Console.WriteLine("Max threads: " + nWorkerThreads + "\nMax I/O Threads: " + nCompletionThreads);

            for (int i = 0; i < 5; i++)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(JobForAThread);
            }

            evt.WaitOne();

            Console.WriteLine("Work is done!");
        }

        static void JobForAThread(object state)
        {
            Console.WriteLine("WorkThread: {0}", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(500);

            jobCount++;
            if (jobCount == 5)
            {
                evt.Set();
            }
        }
    }

}
