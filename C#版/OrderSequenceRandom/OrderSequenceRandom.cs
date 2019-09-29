using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OrderSequenceRandom
{
    class OrderSequenceRandom
    {
        private static AutoResetEvent SyncEvent = new AutoResetEvent(true);

        //private static readonly String ORDERPREFIX = "SVSP";
        private static readonly String ORDERPREFIX = "";


        public static readonly String numberChar = "0123456789";

        public static readonly int numberFor = 12;
        static Random random = new Random();

        [MethodImpl(MethodImplOptions.Synchronized)]
        public String createOrderSnRandom()
        {
            SyncEvent.WaitOne();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < numberFor; i++)
            {
                //Java寫法 //sb.append(numberChar.charAt( random.nextInt(numberChar.length()) ));
                sb.Append(numberChar[random.Next(9)]); //C#寫法
            }
            //Java寫法 //return ORDERPREFIX + sdf.format(new Date()) + sb.toString();

            String rtnString = ORDERPREFIX + DateTime.Now.ToString("yyyyMMdd") + sb.ToString();
            Console.WriteLine(rtnString);
            SyncEvent.Set();
            return rtnString;
        }

    }
}
