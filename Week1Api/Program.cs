using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Week1Api
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseClient clientbase = new BaseClient("https://testonline.botswanapost.co.bw/api/api/v1/ApiUsers/authenticate", "username", "password");
            BaseResponse response = new BaseResponse();
            //BaseResponse respons = clientbase.GetCallV2Async("Candidate").Result;
        }
    }
        }

public class BaseResponse
{
    public int StatusCode { get; set; }
    public string ResponseMessage { get; set; }
}

public class BaseClient
{
    readonly HttpClient client;
    readonly BaseResponse baseresponse;

    public BaseClient(string baseAddress, string username, string password)
    {
        HttpClientHandler handler = new HttpClientHandler()
        {
            Proxy = new WebProxy("https://testonline.botswanapost.co.bw/api/api/v1/ApiUsers/authenticate"),
            UseProxy = false,
        };

        client = new HttpClient(handler);
        client.BaseAddress = new Uri(baseAddress);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        var byteArray = Encoding.ASCII.GetBytes(username + ":" + password);

        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

        baseresponse = new BaseResponse();

    }

    internal object GetCallV2Async(string v)
    {
        throw new NotImplementedException();
    }
}
    

