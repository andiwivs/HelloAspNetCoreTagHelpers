using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HelloAspNetCoreTagHelpers.Site.TagHelpers
{
    [HtmlTargetElement("home-link")]
    public class HomeLinkTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.PreElement.SetHtmlContent("<p>&lt; ");

            output.TagName = "a";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.Add("href", "/");
            output.Content.SetContent("Home");

            output.PostElement.SetHtmlContent("</p>");
        }
    }
}
