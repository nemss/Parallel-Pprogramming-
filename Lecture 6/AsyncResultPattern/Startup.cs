namespace AsyncResultPattern
{
    using System;
    using System.Data.SqlClient;
    using System.Threading;

    public class Startup
    {
        private const string ConnectionString = "Server=.;Database=ShopDb;Integrated Security=True;";
        private const string DummyCommand = "WAITFOR DELAY '00:00:01:000';";

        public static void Main()
        {
            var conn = new SqlConnection(ConnectionString);
            conn.Open();
            using (conn)
            {
                Console.WriteLine($"Main thread id: {Thread.CurrentThread.ManagedThreadId}.");
                var cmd = new SqlCommand(DummyCommand, conn);
                Console.WriteLine("Execute db cmd synchronously");
                cmd.ExecuteNonQuery();
                Console.WriteLine("Synchronous execution completed.");

                Console.WriteLine();

                Console.WriteLine("Execute db cmd asynchronously.");
                cmd.BeginExecuteNonQuery(ExecQueryCallBack, null);
                Console.WriteLine("I am free to continue");


                Console.WriteLine("Press Enter to quit.");
                Console.ReadLine();
            }
        }

        static void ExecQueryCallBack(IAsyncResult result)
        {
            Console.WriteLine("Asynchronous execution completed.");
            Console.WriteLine($"Thread id: {Thread.CurrentThread.ManagedThreadId}.");
        }
    }
}
