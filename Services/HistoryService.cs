
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;
using MAUI_History_app.ViewModel;

namespace MAUI_History_app.Services
{

    public class HistoryService
    {

        HttpClient httpClient;
        public string SNstring;
        public string Serverstr;
        public string Portstr;
        public string Barcode;
        public HistoryService()
        {
            this.httpClient = new HttpClient();
        }
        public List<History> HistoryList;
        public async Task<List<History>> GetHistories()
        {

            if (HistoryList?.Count > 0)
                return HistoryList;

            SNstring = SNstring.Replace("+", "%2b");
            string UiSN = SNstring;
            string UiServer = Serverstr;
            string UiPort = Portstr;
            string UiBarcode = Barcode;

            string Ipextract = null;
            //string hostname = UiServer;
            if (UiServer != null)
            {
                var host = Dns.GetHostEntry(UiServer);
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        Ipextract = ip.ToString();
                    }
                    //return "";
                }
                //throw new Exception("Local IP Address Not Found!");
            }
            //if (UiServer != null)
            //{
            //    IPAddress[] addresslist = Dns.GetHostAddresses(UiServer);

            //    foreach (IPAddress theaddress in addresslist)
            //    {
            //        Ipextract = theaddress.ToString();
            //    }

            //}

            //var sndurl = string.Format(@"http://{0}:{1}/api/GetProductDetailsFromSN?SerialNumber={2}",UiServer,UiPort,UiSN);
            //var sndresponse = await httpClient.GetStringAsync(sndurl);

            ////api/UnitDetails?UnitId={UnitId}&SerialNumber={SerialNumber}
            ////var url = @"http://{0}:{1}/api/SerialnumberHistory?serialNumber={0}&unitId=1341B1BD-3989-448A-8E92-23BF480C2C9E",UiSN);


            var url = string.Format(@"http://{0}:{1}/api/SerialnumberHistory?serialNumber={2}", Ipextract, UiPort, UiSN);
            var response = await httpClient.GetStringAsync(url);

            if (response != null)
            {
                // string Xmlapi = response;

                string Xml1 = response.Replace("{", "").Replace("}", "").Replace(@"""[", "").Replace(@"]""", "");
                Regex regex = new Regex(",");         // Split on commas
                string[] Xmlarr = regex.Split(Xml1);
                List<string> Xmllist = new List<string>();
                foreach (string XmlarrItem in Xmlarr)
                {
                    string Xmlarritemc = XmlarrItem.Insert(0, @"""").Insert(XmlarrItem.Length + 1, @"""");
                    int Arritemcolonidx = Xmlarritemc.IndexOf(':', 0);
                    string Xmlarritemf = String.Empty;
                    Xmlarritemf = Xmlarritemc.Insert(Arritemcolonidx + 1, @"""").Insert(Arritemcolonidx, @"""");
                    Xmllist.Add(Xmlarritemf);
                }
                string output = string.Join(",", Xmllist.ToArray());
                string OutputJson = output.Replace(@",""UNIT_EVENT_ID""", @"},{""UNIT_EVENT_ID""");
                string Jsoned = @"[{" + OutputJson + @"}]";

                HistoryList = JsonSerializer.Deserialize<List<History>>(Jsoned);
            }
            return HistoryList;
        }
    }
}