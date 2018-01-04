using System;
using System.Threading;

namespace IOTAValue
{
    class Program
    {
        static Timer timer = new Timer(ConsulteValores, null, 0, 60000);

        public static void Main(string[] args)
        {
            timer.InitializeLifetimeService();
            Console.Read();
        }

        private static void ConsulteValores(object state)
        {
            try
            {
                Framework.IOTABTC();
                Framework.IOTAUSD();
                Framework.XRPBTC();
                Framework.XRPUSD();

                Console.WriteLine();
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("\\\\\\\\\\\\\\\\\\\\\\" + ex.Message + " ////////////////////////////");
            }
        }
    }
}
