using System;

namespace lab8
{
    internal class Program
    {

    public static bool isPrimeNumber(long number) {

        long  limit = (long)Math.Floor(Math.Sqrt(number));

        for (int i = 2; i <= limit; ++i)
        {
            if (number % i == 0)
            {
                return false;
            }
        }
        return number >= 2;
    }

        static void Main(string[] args)
        {

            bool help = true;
            int counter = 0;
            Object locker = new Object();

            Thread Thread1 = new Thread(() =>
            {
                for (int i = 0; help; i += 4)
                {
                    if (isPrimeNumber(i))
                    {
                        lock (locker) { counter += 1; }
                    }
                }
            });

            Thread Thread2 = new Thread(() =>
            {
                for (int i = 1; help; i += 4)
                {
                    if (isPrimeNumber(i))
                    {
                        lock (locker) { counter += 1; }
                    }
                }
            });

            Thread Thread3 = new Thread(() =>
            {
                for (int i = 2; help; i += 4)
                {
                    if (isPrimeNumber(i))
                    {
                        lock (locker) { counter += 1; }
                    }
                }
            });

            Thread Thread4 = new Thread(() =>
            {
                for (int i = 3; help; i += 4)
                {
                    if (isPrimeNumber(i))
                    {
                        lock (locker) { counter += 1; }
                    }
                }
            });
            Thread1.Start();
            Thread2.Start();
            Thread3.Start();
            Thread4.Start();

            Thread.Sleep(1000);
            help = false;
            Thread1.Join();
            Thread2.Join();
            Thread3.Join();
            Thread4.Join();
            Console.WriteLine(counter);
        }
    }
}