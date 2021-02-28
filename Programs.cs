using System;
using System.Collections.Generic;
using System.Threading;
using System.Xml;

namespace ConsoleApp2
{
    static class Program
    {
        private static Timer TTimer = null;


        //client lcass
        static void Main(string[] args)
        {

            AutoResetEvent autoEvent = new AutoResetEvent(false);
            List<int> nos = new List<int>() { 1, 3, 6, 0, 1, 3, 2, 1, 0, 0, 5 };
            int onecount = 0;
            int zeroscount = 0;
            TTimer = new Timer(
            new TimerCallback(x=>Count(x, nos, ref onecount, ref zeroscount)),
            autoEvent,
            1000,
            5000);

            Console.ReadLine();
        }

        public static void Count(object stateInfo, List<int> nos, ref int onecount, ref int zeroscount )
        {
            AutoResetEvent autoEvent = (AutoResetEvent)stateInfo;
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId.ToString());
            foreach (int item in nos)
            {
                if (item == 0)
                {
                    zeroscount = zeroscount + 1;
                }
                else if (item == 1)
                {
                    onecount = onecount + 1;
                }
            }
            Thread.Sleep(6000);
            autoEvent.Set();

        }
    }
}
    

    


