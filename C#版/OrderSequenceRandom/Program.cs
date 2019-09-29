using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSequenceRandom
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderSequenceRandom osr = new OrderSequenceRandom();
            Console.WriteLine(OrderSequenceRandom.createOrderSnRandom());
            Console.ReadLine();
        }
    }
}
