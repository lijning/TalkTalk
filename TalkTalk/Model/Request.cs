using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using Newtonsoft.Json;
//using Windows.Web.Http;

namespace TalkTalk.Model
{
    /* By passing in the message to send as a parameter, the caller can get 
     * both the reply and the query stored in the Record.
     * Call the Q&S method.
     */
    public class Connector
    {
        private const String host = "http://jisuznwd.market.alicloudapi.com";
        private const String path = "/iqa/query";
        private const String method = "GET";
        private const String appcode = "11cde8e24eb94641b44831fe09c66ad3";

        private async Task<string> SendMessage(string message)
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
        }
        private string GetContent(string json)
        {
            Reply reply = (Reply)JsonConvert.DeserializeObject<Reply>(json);
            return reply.result.content;
        }
        public async Task<string> QueryAndStore(string messageToSend)
        {
            string messageCore;
            Record.InitializeRecords();
            var reply = await SendMessage(messageToSend);
            try
            {
                Record.queries.Add(messageToSend);
            }
            catch (Exception) { }
            messageCore = GetContent(reply);
            Record.replies.Add(messageCore);
            return messageCore;
        }
    }

    public struct Reply
    {
        public int status;
        public string msg;
        public Result result;
    }
    public class Result
    {
        public string type;
        public string content;
        public string relquestion;
    }
}
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
