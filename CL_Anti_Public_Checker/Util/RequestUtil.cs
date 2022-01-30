using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CL_Anti_Public_Checker.Util
{
    internal class RequestUtil
    {
        public static string getHashesInDB()
        {
            return new WebClient().DownloadString(StorageUtil.baseUrl + "/info/blank");
        }
        public static bool HashExists(string hash)
        {
            var result = "";
            //return bool.Parse(new WebClient().UploadString(StorageUtil.baseUrl + "/testdb/blank", "{\"hash\" : \"559aead08264d5795d3909718cdd05abd49572e84fe55590eef31a88a08fdffd\"}"));
            var url = "http://localhost:3000/testdb/blank";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "POST";

            httpRequest.ContentType = "application/json";

            var data = "{\"hash\" : \"" + hash + "\"}";

            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write(data);
            }

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
            return bool.Parse(result);
        }
    }
}
