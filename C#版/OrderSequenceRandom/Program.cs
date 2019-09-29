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

            Thread thread1 = new Thread(Function1);
            Thread thread2 = new Thread(Function2);
            Thread thread3 = new Thread(Function3);
            thread1.Start();
            thread2.Start();
            thread3.Start();
            Console.ReadLine();
        }

        static void Function1()
        {
            OrderSequenceRandom osr1 = new OrderSequenceRandom();
            osr1.createOrderSnRandom();
        }

        static void Function2()
        {
            OrderSequenceRandom osr2 = new OrderSequenceRandom();
            osr2.createOrderSnRandom();
        }

        static void Function3()
        {
            OrderSequenceRandom osr3 = new OrderSequenceRandom();
            osr3.createOrderSnRandom();
        }

    }
}
