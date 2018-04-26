using System;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HelloAspNetCoreTagHelpers.Site.TagHelpers
{
    [HtmlTargetElement("tab")]
    public class TabTagHelper : TagHelper
    {
        public string Title { get; set; }

        public string Href { get; set; }

        public bool IsDisabled { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var linkCssClass = BuildLinkCssClass(context);
            var link = $"<a href='{Href}' class='{linkCssClass}'>{Title}</a>";

            output.TagName = "li";
            output.Attributes.Add("class", "nav-item");
            output.Content.SetHtmlContent(link);
        }

        private string BuildLinkCssClass(TagHelperContext context)
        {
            var cssClass = "nav-link";

            if (IsDisabled)
                cssClass += " disabled";

            var activePage = context.Items["ActivePage"] as string;

            if (activePage == null)
                return cssClass;

            if (activePage.Equals(Title, StringComparison.InvariantCultureIgnoreCase))
                cssClass += " active";

            return cssClass;
        }
    }
}
