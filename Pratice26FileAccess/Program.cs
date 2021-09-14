using System;
using System.Threading;
namespace Pratice26FileAccess
{
    class FileAccess
    {
        public void WriteData(string s)
        {
            lock(this)
            {
                Console.WriteLine(s);
                Console.WriteLine("Writing data completed");
            }

        }
    }
    class Program
    {
        static FileAccess obj = new FileAccess();

        public static void ChildThread1()
        {
            Console.WriteLine("Child1 started writing data");
            obj.WriteData("child 1 -- my new data");
        }
        public static void ChildThread2()
        {
            Console.WriteLine("Child2 started writing data");
            obj.WriteData("child 2 -- my new data");
        }
        static void Main(string[] args)
        {
            ThreadStart ts1 = new ThreadStart(ChildThread1);
            ThreadStart ts2 = new ThreadStart(ChildThread2);

            Thread t1 = new Thread(ts1);
            Thread t2 = new Thread(ts2);

            t1.Start();
            t2.Start();
        }
    }
}
