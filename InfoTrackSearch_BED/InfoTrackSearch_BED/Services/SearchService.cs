using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using InfoTrackSearch_BED.Models;
using System.Text.RegularExpressions;

namespace InfoTrackSearch_BED.Services
{
    public class SearchService:ISearchService
    {
        private readonly IConfiguration _config;
        public SearchService(IConfiguration config)
        {
            _config = config;
        }

        private async Task<string> DownloadPageSource(string baseURL,int pagenum)
        {
            string res = string.Empty;
            using (var client = new WebClient())
            {
                var data = await client.DownloadDataTaskAsync(baseURL + "Page0"+pagenum+".html");
                res = System.Text.Encoding.Default.GetString(data);

            }
            return res;
        }
        public async Task<string> SearchGoogle(string searchValue)
        {
            string result = string.Empty;
            List<string> lstStr = new List<string>();
            string baseURL = _config.GetValue<string>("SearchURLs:GoogleURL");
            List<string> tmpStr = new List<string>();
            try
            {

                var t1 = DownloadPageSource(baseURL, 1);
                var t2 = DownloadPageSource(baseURL, 2);
                var t3 = DownloadPageSource(baseURL, 3);
                var t4 = DownloadPageSource(baseURL, 4);
                var t5 = DownloadPageSource(baseURL, 5);

                await Task.WhenAll(t1, t2, t3, t4, t5);
                lstStr.Add(await t1);
                lstStr.Add(await t2);
                lstStr.Add(await t3);
                lstStr.Add(await t4);
                lstStr.Add(await t5);

                foreach(string str in lstStr)
                {
                    int num =Regex.Matches(str, _config.GetValue<string>("TargetURL:URL")).Count;
                    tmpStr.Add(num.ToString());
                    result = string.Join(",", tmpStr);
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public async Task<string> SearchBing(string searchValue)
        {
            string result = string.Empty;
            List<string> lstStr = new List<string>();
            string baseURL = _config.GetValue<string>("SearchURLs:BingURL");
            List<string> tmpStr = new List<string>();
            try
            {

                var t1 = DownloadPageSource(baseURL, 1);
                var t2 = DownloadPageSource(baseURL, 2);
                var t3 = DownloadPageSource(baseURL, 3);
                var t4 = DownloadPageSource(baseURL, 4);
                var t5 = DownloadPageSource(baseURL, 5);

                await Task.WhenAll(t1, t2, t3, t4, t5);
                lstStr.Add(await t1);
                lstStr.Add(await t2);
                lstStr.Add(await t3);
                lstStr.Add(await t4);
                lstStr.Add(await t5);

                foreach (string str in lstStr)
                {
                    int num = Regex.Matches(str, _config.GetValue<string>("TargetURL:URL")).Count;
                    tmpStr.Add(num.ToString());
                    result = string.Join(",", tmpStr);
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
    }
}
