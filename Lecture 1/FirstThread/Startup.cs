namespace FirstThread
{
    using System;
    using System.Threading;

    public class Startup
    {
        private static void Main()
        {
            Console.WriteLine("Main app started.");

            Thread thread = new Thread(ThreadWorker);
            thread.Start();

            Thread.Sleep(100);
            Console.WriteLine("Press ENTER to quit.");

            Console.ReadLine();
        }

        private static void ThreadWorker()
        {
            Console.WriteLine("Hello from my first thread!");
        }
    }
}