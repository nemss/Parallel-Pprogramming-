namespace AsyncAwaitDemo
{
    using System;
    using System.Data.SqlClient;
    using System.Threading;
    using System.Threading.Tasks;

    public class Startup
    {
        private const string ConnectionString = "Server=.;Database=ShopDb;Integrated Security=True;";
        private const string DummyCommand = "WAITFOR DELAY '00:00:01:000';";

        public static void Main()
        {
            Console.WriteLine($"Main thread id {Thread.CurrentThread.ManagedThreadId}.");

            var t = CallDatabase();
            t.Wait();

            Console.WriteLine("Press ENTER to quit.");
            Console.ReadLine();
        }

        private static async Task CallDatabase()
        {
            var conn = new SqlConnection(ConnectionString);
            conn.Open();
            var cmd = new SqlCommand(DummyCommand, conn);

            Console.WriteLine($"Thread id {Thread.CurrentThread.ManagedThreadId}.");

            Console.WriteLine("Begin async execution...");

            await cmd.ExecuteNonQueryAsync();

            Console.WriteLine("Async execution completed.");
            Console.WriteLine($"Thread id {Thread.CurrentThread.ManagedThreadId}.");
        }
    }
}
