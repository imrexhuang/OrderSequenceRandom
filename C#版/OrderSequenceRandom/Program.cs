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
            Console.ReadLine();
        }
    }
}
