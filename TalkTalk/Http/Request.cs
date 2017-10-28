using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;
using System.Text;
//using Windows.Web.Http;

namespace TalkTalk.Http
{
    public class ConnectionAPI
    {
        private const String host = "http://jisuznwd.market.alicloudapi.com";
        private const String path = "/iqa/query";
        private const String method = "GET";
        private const String appcode = "11cde8e24eb94641b44831fe09c66ad3";

        public async Task<string> SendMessage(string message)
        {
            String querys = "question="+message;
            String url = host + path;
            string reply;
            if (0 < querys.Length)
                url = url + "?" + querys;
            HttpClient client = new System.Net.Http.HttpClient();
            try
            {
                client.DefaultRequestHeaders.Add("Authorization", "APPCODE " + appcode);
                var reponse = await client.GetStreamAsync(url);
                var streamReader = new StreamReader(reponse, Encoding.UTF8);
                reply = streamReader.ReadToEnd();
            }catch(Exception err)
            {
                reply = err.Message;
            }
            finally
            {
                client.Dispose();
            }
            return reply;
            /*
            try
            {
                //ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                httpRequest = (HttpWebRequest)WebRequest.Create(new Uri(url));
            }
            catch (Exception)
            {

            }
            httpRequest.Method = method;
            HttpRequestHeaderColl cc = new HttpRequestHeader();
            httpRequest.Headers.Add("Authorization", "APPCODE " + appcode);
            try
            {
                httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            }
            catch (WebException ex)
            {
                httpResponse = (HttpWebResponse)ex.Response;
            }*/
        }
    }
}
