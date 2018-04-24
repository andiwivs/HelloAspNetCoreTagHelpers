using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace HelloAspNetCoreTagHelpers.Site.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("slow-to-process")]
    public class SlowToProcessTagHelper : TagHelper
    {
        /**************************************************************************************
         * slow sync code that will be converted to async process instead
         **************************************************************************************
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string data;

            using (var client = new HttpClient())
            {
                var uri = new Uri("https://jsonplaceholder.typicode.com/comments"); // dummy REST api that returns some JSON data

                data = client.GetStringAsync(uri).Result;
            }

            var content = data
                .Replace(Environment.NewLine, "<br />")
                .Replace(" ", "&nbsp;");

            output.Content.SetHtmlContent(content);
        }
        **************************************************************************************/

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            int threadIdBefore, threadIdAfter;
            string content;

            threadIdBefore = Thread.CurrentThread.ManagedThreadId;

            using (var client = new HttpClient())
            {
                var uri = new Uri("https://jsonplaceholder.typicode.com/comments"); // dummy REST api that returns some JSON data

                using (var response = await client.GetAsync(uri))
                {
                    response.EnsureSuccessStatusCode();

                    content = await response.Content.ReadAsStringAsync();

                    threadIdAfter = Thread.CurrentThread.ManagedThreadId;
                }
            }

            content = $"Slow process began with thread {threadIdBefore} and completed with thread {threadIdAfter}. Response data from external Api call was:"
                + content
                .Replace(Environment.NewLine, "<br />")
                .Replace(" ", "&nbsp;");

            output.Content.SetHtmlContent(content);
        }
    }
}
