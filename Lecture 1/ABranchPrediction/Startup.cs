using System;
using System.Diagnostics;

public class Startup
{
    private static int dataSize = 20_000_000;
    private static int[] data;

    private static void Main(string[] args)
    {
        GenerateData();
        Stopwatch watch = new Stopwatch();
        for (int i = 0; i < 11; i++)
        {
            watch.Restart();
            var ops = CountLess(i);
            watch.Stop();
            Console.WriteLine($"{i,2}. Count: {ops,8}, Time: {watch.ElapsedTicks,7}");
        }
        Console.WriteLine("Ready");
        Console.ReadLine();
    }

    private static void GenerateData()
    {
        data = new int[dataSize];
        Random rand = new Random();
        for (int i = 0; i < dataSize; i++)
        {
            data[i] = rand.Next(10);
        }
    }

    private static int CountLess(int boundary)
    {
        int result = 0;
        for (int i = 0; i < dataSize; i++)
        {
            //if (data[i] < boundary) result++;

            #region Alternative

            result = result - ((data[i] - boundary) >> 31);

            #endregion Alternative
        }
        return result;
    }
}