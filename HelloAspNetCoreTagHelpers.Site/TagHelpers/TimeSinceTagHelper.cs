using System;
using HelloAspNetCoreTagHelpers.Site.Infrastructure;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HelloAspNetCoreTagHelpers.Site.TagHelpers
{
    [HtmlTargetElement("time-since")]
    public class TimeSinceTagHelper : TagHelper
    {
        private readonly ITimeSinceService _timeSinceService;

        public string CompareDateTime { get; set; }

        public TimeSinceTagHelper(ITimeSinceService timeSinceService)
        {
            _timeSinceService = timeSinceService;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var compareFrom = DateTime.Parse(CompareDateTime);
            var timeSince = _timeSinceService.TimeSince(compareFrom);

            output.Content.SetContent(timeSince);
        }
    }
}
