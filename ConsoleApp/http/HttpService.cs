using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.http
{
    public class HttpService
    {
        /// <summary>
        /// test server
        /// git@github.com:parmalatinter/node-test-server.git :by heroku app
        /// </summary>
        public const string url = "https://node-easy-test-server.herokuapp.com";
        public static async Task<string> HttpAjaxPostAsync()
        {
            var json = @"{""foo"":""hoge"", ""bar"":123, ""baz"":[""あ"", ""い"", ""う""]}";
            var content = new StringContent(json, Encoding.UTF8, @"application/json");

            HttpResponseMessage response;
            using (var client = new HttpClient())
            {
                response = await client.PostAsync(url, content);
            }
            return response.ReasonPhrase;
        }
    }
}
