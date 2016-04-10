using System;
using System.Threading;

namespace Task
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            System.Threading.Tasks.Task.Run(() =>
            {
                Thread.Sleep(500);
                return 1;
            }).ContinueWith(task => { Console.WriteLine(task.Result); }).Wait();
        }
    }
}