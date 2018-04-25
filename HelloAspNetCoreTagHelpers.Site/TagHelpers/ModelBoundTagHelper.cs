using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HelloAspNetCoreTagHelpers.Site.TagHelpers
{
    [HtmlTargetElement("model-bound")]
    public class ModelBoundTagHelper : TagHelper
    {
        public ModelExpression HelperFor { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var input = HelperFor == null
                ? string.Empty
                : $"Name: {HelperFor.Name} | Model: {HelperFor.Model}";

            output.Content.SetContent(input);
        }
    }
}
