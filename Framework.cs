using Newtonsoft.Json;
using System;
using System.Net.Http;
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

        public static void XRPBTC()
        {
            ObtenhaValorXRPBTC();
        }

        public static void XRPUSD()
        {
            ObtenhaValorXRPUSD();
        }

        public static void IOTAUSD()
        {
            ObtenhaValorIOTAUSD();
        }

        #endregion

        #region Métodos Privados
        #region IOTA
        private static void ObtenhaValorIOTABTC()
        {
            using (var client_usd = new HttpClient())
            {
                client_usd.BaseAddress = new Uri(ApiBitfinex.GET_IOTABTC);
                var response = client_usd.GetAsync(string.Empty).Result;
                var contentToString = response.Content.ReadAsStringAsync();
                xdoc = JsonConvert.DeserializeXmlNode(contentToString.Result, "iota");
                xdoc.Save("iotabtc.xml");
                Console.WriteLine("********** IOTA BTC **********");
                Console.WriteLine(" " + DateTime.Now);
                Console.WriteLine(" Valor em Bitcoin (BTC): " + xdoc.GetElementsByTagName("last_price")[0].InnerText);
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
                decimal NoDecimal = decimal.Parse(valor.Replace(".", ","));
                NoDecimal = Math.Round(NoDecimal, 2);
                Console.WriteLine("********** IOTA $ **********");
                Console.WriteLine(" " + DateTime.Now);
                Console.WriteLine(" Valor em $ (USD): " + NoDecimal);
                Console.WriteLine(" USD $ " + ApiBitfinex.MyIOTAs * NoDecimal);
                Console.WriteLine(" R$ " + 3.2350m * ApiBitfinex.MyIOTAs * NoDecimal);
                Console.WriteLine();
            }
        }
        #endregion

        #region RIPPLE
        private static void ObtenhaValorXRPBTC()
        {
            using (var client_usd = new HttpClient())
            {
                client_usd.BaseAddress = new Uri(ApiBitfinex.GET_RIPPLEBTC);
                var response = client_usd.GetAsync(string.Empty).Result;
                var contentToString = response.Content.ReadAsStringAsync();
                xdoc = JsonConvert.DeserializeXmlNode(contentToString.Result, "ripple");
                xdoc.Save("xrpbtc.xml");
                Console.WriteLine("********** RIPPLE BTC **********");
                Console.WriteLine(" " + (DateTime.Now));
                Console.WriteLine(" Valor em Bitcoin (BTC): " + xdoc.GetElementsByTagName("last_price")[0].InnerText);
                Console.WriteLine();
            }
        }

        private static void ObtenhaValorXRPUSD()
        {
            using (var client_btc = new HttpClient())
            {
                client_btc.BaseAddress = new Uri(ApiBitfinex.GET_RIPPLEUSD);
                var response = client_btc.GetAsync(string.Empty).Result;
                var contentToString = response.Content.ReadAsStringAsync();
                xdoc = JsonConvert.DeserializeXmlNode(contentToString.Result, "ripple");
                xdoc.Save("xrpusd.xml");
                var valor = xdoc.GetElementsByTagName("last_price")[0].InnerText;
                decimal NoDecimal = decimal.Parse(valor.Replace(".", ","));
                NoDecimal = Math.Round(NoDecimal, 2);
                Console.WriteLine("********** RIPPLE $ **********");
                Console.WriteLine(" " + DateTime.Now);
                Console.WriteLine(" Valor em $ (USD): " + NoDecimal);
                Console.WriteLine(" USD $ " + ApiBitfinex.MyXRPs * NoDecimal);
                Console.WriteLine(" R$ " + 3.2350m * ApiBitfinex.MyXRPs * NoDecimal);
                Console.WriteLine();
            }
        }
        #endregion
        #endregion
    }
}
