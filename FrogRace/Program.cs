using System;
using System.Threading;

namespace FrogRace
{
    public class Program
    {
        private static int finisher;

        private static object threadLock;
         private static void Main(string[] args)
        {
            threadLock = new object();
            finisher = 0;


            Thread t1 = new Thread (FrogRace);
            Thread t2 = new Thread (FrogRace);
            Thread t3 = new Thread (FrogRace);

            t1.Name = "T_One";
            t2.Name = "T_Two";
            t3.Name = "T_Three";
            t1.Start(1);
            t2.Start(2);
            t3.Start(3);
            t1.Join();
            t2.Join();
            t3.Join();
        }

        public static void FrogRace (object obj)
        {
            int FrogNumb = (int)obj;
            
            string name = Thread.CurrentThread.Name;

            Random rnd = new Random(FrogNumb);

            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(rnd.Next(1001));
                Console.WriteLine($"Rã {FrogNumb} deu o salto {i + 1} (Thread {name})");
            }

            Console.WriteLine($"Rã{FrogNumb} acabou!");
            
            lock (threadLock)
            {
                if(finisher == 0)
                {
                    Console.WriteLine($"Rã {FrogNumb} ganhou!");
                }

                finisher ++;
            }
        }
    }
}
