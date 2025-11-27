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
}