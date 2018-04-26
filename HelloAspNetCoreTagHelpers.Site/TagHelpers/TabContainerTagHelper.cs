using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HelloAspNetCoreTagHelpers.Site.TagHelpers
{
    [HtmlTargetElement("tab-container")]
    [RestrictChildren("tab")]
    public class TabContainerTagHelper : TagHelper
    {
        [HtmlAttributeName]
        public string Heading { get; set; }

        [HtmlAttributeName]
        public string ActivePage { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var heading = string.IsNullOrWhiteSpace(Heading)
                ? string.Empty 
                : $"<h3>{Heading}</h3>";

            output.TagName = "div";
            output.Attributes.Add("class", "container");
            output.PreContent.SetHtmlContent($"{heading}<ul class='nav nav-tabs'>");
            output.PostContent.SetHtmlContent("</ul>");

            context.Items["ActivePage"] = ActivePage; // this is accessible to our children...
        }
    }
}
