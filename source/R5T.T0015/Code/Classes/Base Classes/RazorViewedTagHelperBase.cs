using System;
using System.Threading.Tasks;

using R5T.D0061;


namespace Microsoft.AspNetCore.Razor.TagHelpers
{
    /// <summary>
    /// Base class for tag helpers that use a Razor view to specify markup.
    /// </summary>
    public abstract class RazorViewedTagHelperBase : TagHelper
    {
        protected abstract string ViewName { get; }
        protected abstract bool PreserveElement { get; }

        private IRazorViewStringRenderer RazorViewStringRenderer { get; }


        public RazorViewedTagHelperBase(
            IRazorViewStringRenderer razorViewStringRenderer)
        {
            this.RazorViewStringRenderer = razorViewStringRenderer;
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var viewHtmlContentString = await this.RazorViewStringRenderer.Render(this.ViewName);

            output.Content.SetHtmlContent(viewHtmlContentString); // Set the content.

            // Remove the element if we don't want to preserve it.
            if (!this.PreserveElement)
            {
                output.TagName = "";
            }
        }
    }
}
