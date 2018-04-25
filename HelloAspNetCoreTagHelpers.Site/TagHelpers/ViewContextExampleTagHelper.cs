using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HelloAspNetCoreTagHelpers.Site.TagHelpers
{
    [HtmlTargetElement("view-context-example")]
    public class ViewContextExampleTagHelper : TagHelper
    {
        [ViewContext]               // this property will be bound to the executing request
        [HtmlAttributeNotBound]     // protects the property from being abused by a view, important given we have a handle on the executing request
        public ViewContext ViewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var isHttps = ViewContext.HttpContext.Request.IsHttps;
            var isValid = ViewContext.ModelState.IsValid;

            var summary = $"Is HTTPS: {isHttps} | ModelState valid: {isValid}";

            output.Content.SetContent(summary);
        }
    }
}
