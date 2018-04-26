using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HelloAspNetCoreTagHelpers.Site.TagHelpers
{
    [HtmlTargetElement("home-link")]
    public class HomeLinkTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.PreElement.SetHtmlContent("<p>");

            output.TagName = "a";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.Add("href", "/");
            output.Attributes.Add("class", "btn btn-secondary");
            output.Content.SetHtmlContent("<i class='fas fa-home'></i> Home");

            output.PostElement.SetHtmlContent("</p>");
        }
    }
}
