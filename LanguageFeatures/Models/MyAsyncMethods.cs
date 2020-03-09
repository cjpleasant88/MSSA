//using System;
//using System.Collections.Generic;
//using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

namespace LanguageFeatures.Models
{
    public class MyAsyncMethods
    {
        //*****pg 101
        public async static Task<long?> GetPageLength()
        {
            HttpClient client = new HttpClient();

            var httpMessage = await client.GetAsync("http://apress.com");

            return httpMessage.Content.Headers.ContentLength;
        }
        //*****pg 100
        //public static Task<long?> GetPageLength()
        //{
        //    HttpClient client = new HttpClient();

        //    var httpTask = client.GetAsync("http://apress.com");

        //    return httpTask.ContinueWith((Task<HttpResponseMessage> antecedent) =>
        //    {
        //        return antecedent.Result.Content.Headers.ContentLength;
        //    });
        //}
    }
}
