using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace IOTAValue
{
    public static class Framework
    {
        #region Propriedades Privadas

        private static XmlDocument xdoc = new XmlDocument();

        #endregion

        #region Métodos Públicos

        public static void IOTABTC()
        {
            ObtenhaValorIOTABTC();
        }

        public static void IOTAUSD()
        {
            ObtenhaValorIOTAUSD();
        }

        #endregion

        #region Métodos Privados

        private static void ObtenhaValorIOTABTC()
        {
            using (var client_usd = new HttpClient())
            {
                client_usd.BaseAddress = new Uri(ApiBitfinex.GET_IOTABTC);
                var response = client_usd.GetAsync(string.Empty).Result;
                var contentToString = response.Content.ReadAsStringAsync();
                xdoc = JsonConvert.DeserializeXmlNode(contentToString.Result, "iota");
                xdoc.Save("iotabtc.xml");
                Console.WriteLine("********** IOTA BTC ********** - " + DateTime.Now);
                Console.WriteLine("Valor em Bitcoin (BTC): " + xdoc.GetElementsByTagName("last_price")[0].InnerText);
                Console.WriteLine();
            }
        }

        private static void ObtenhaValorIOTAUSD()
        {
            using (var client_btc = new HttpClient())
            {
                client_btc.BaseAddress = new Uri(ApiBitfinex.GET_IOTAUSD);
                var response = client_btc.GetAsync(string.Empty).Result;
                var contentToString = response.Content.ReadAsStringAsync();
                xdoc = JsonConvert.DeserializeXmlNode(contentToString.Result, "iota");
                xdoc.Save("iotausd.xml");
                var valor = xdoc.GetElementsByTagName("last_price")[0].InnerText;
                Console.WriteLine("********** IOTA $ ********** - " + DateTime.Now);
                Console.WriteLine("Valor em $ (USD): " + valor);
                Console.WriteLine("USD $ " + ApiBitfinex.MyIOTAs * double.Parse(valor));
                Console.WriteLine("R$ " + 3.29 * ApiBitfinex.MyIOTAs * double.Parse(valor));
                Console.WriteLine();
            }
        }

        #endregion
    }
}
