using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.scraping
{
    public class ScrapingService
    {
        /// <summary>
        /// https://qiita.com/matarillo/items/a92e7efbfd2fdec62595
        /// </summary>
        public const string url = "http://stocks.finance.yahoo.co.jp/stocks/detail/";

        public static async Task<int> GetFinancePriceAsync(string code)
        {
            string urlstring = $"{url}?code={code}";

            // 指定したサイトのHTMLをストリームで取得する
            var doc = default(IHtmlDocument);
            using (var client = new System.Net.Http.HttpClient())
            using (var stream = await client.GetStreamAsync(new Uri(urlstring)))
            {
                // AngleSharp.Html.Parser.HtmlParserオブジェクトにHTMLをパースさせる
                var parser = new HtmlParser();
                doc = await parser.ParseDocumentAsync(stream);
            }

            // クエリーセレクタを指定し株価部分を取得する
            var priceElement = doc.QuerySelector("#main td[class=stoksPrice]");

            // 取得した株価がstring型なのでint型にパースする
            int.TryParse(priceElement.TextContent, NumberStyles.AllowThousands, null, out var price);

            return price;
        }
    }
}
