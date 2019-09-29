using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OrderSequenceRandom
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderSequenceRandom osr = new OrderSequenceRandom();
            osr.createOrderSnRandom();
            osr.createOrderSnRandom();

            for (int i = 0; i < 100; i++)
            {
                int idx = i;
                ThreadPool.QueueUserWorkItem(_ =>
                {
                    OrderSequenceRandom osr1 = new OrderSequenceRandom();
                    osr1.createOrderSnRandom();
                }); ;
            }

            Thread.Sleep(1000);
            Console.WriteLine(new String('=', 80));

            // 這裡是在每個執行緒內產生一個 Ramdom 物件
            for (int i = 0; i < 100; i++)
            {
                ThreadPool.QueueUserWorkItem(_ =>
                {
                    Random rm = new Random();
                    int foo = rm.Next();
                    Console.WriteLine(foo);
                });
            }

            Thread.Sleep(1000);
            Console.WriteLine(new String('-', 80));

            // 這裡使用同一個 Ramdom 物件
            Random rmSingle = new Random();
            for (int i = 0; i < 100; i++)
            {
                ThreadPool.QueueUserWorkItem(_ =>
                {
                    int foo = rmSingle.Next();
                    Console.WriteLine(foo);
                });
            }
            Console.ReadLine();
        }
    }
}
