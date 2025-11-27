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
}