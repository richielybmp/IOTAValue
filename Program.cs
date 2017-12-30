using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading;
using System.Xml;

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
                Framework.IOTAUSD(); // iota - dolar
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
