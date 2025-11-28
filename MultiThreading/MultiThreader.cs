using System.Collections.Concurrent;
using static System.Threading.Thread;

namespace design_patterns.MultiThreading;

public class MultiThreader
{
    public static void WriteThreadId()
    {
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine($"The current thread is {Environment.CurrentManagedThreadId}");
        }
    }

    public static int SumSegment(int[] array, int start, int end)
    {
        int segmentSum = 0;
        for (int i = start; i < end; i++)
        {
            Thread.Sleep(10);
            segmentSum += array[i];
        }

        return segmentSum;
    }

    public static void SetupWebServer()
    {
        Console.WriteLine("Service is running, please type 'exit' to stop");
        // Setting up Request queue
        ConcurrentQueue<string?> requestQueue = new();
        Thread monitoringThread = new Thread(MonitorQueue);
        monitoringThread.Start(requestQueue);
        while (true)
        {
            string? input = Console.ReadLine();
            if (input?.ToLower() == "exit")
                break;

            requestQueue.Enqueue(input);
        }
    }

    private static void MonitorQueue(object? o)
    {
        if (o is not ConcurrentQueue<string?> requestQueue)
        {
            Console.WriteLine("Incorrect Implementation - Queue monitor expecting Concurrent queue");
        }
        else
        {
            while (true)
            {
                if (!requestQueue.IsEmpty)
                {
                    requestQueue.TryDequeue(out string? result);
                    Thread processingThread = new(() => ProcessRequest(result));
                    processingThread.Start();
                }

                // Ensuring loop here doesn't explode from too many requests and take up too much CPU
                Thread.Sleep(100);
            }
        }
    }

    private static void ProcessRequest(string? input)
    {
        Thread.Sleep(2000);
        Console.WriteLine($"Processed input {input}");
    }

    public static void SetupIncrementerBlocking()
    {
        int counter = 0;
        Thread thread1 = new(Increment);
        Thread thread2 = new(Increment);
        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();
        Console.WriteLine($"Counter value is currently at: {counter}");

        void Increment()
        {
            for (int i = 0; i < 100000; i++)
            {
                counter++;
            }
        }
    }

    public static void SetupIncrementerNonBlocking()
    {
        int counter = 0;
        Lock counterLock = new();
        Thread thread1 = new(Increment);
        Thread thread2 = new(Increment);
        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();
        Console.WriteLine($"Counter value is currently at: {counter}");

        void Increment()
        {
            for (int i = 0; i < 100000; i++)
            {
                lock (counterLock)
                {
                    counter++;
                }
            }
        }
    }
}