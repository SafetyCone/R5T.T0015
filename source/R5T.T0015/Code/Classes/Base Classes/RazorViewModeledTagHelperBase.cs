using System;
using System.Threading.Tasks;

using R5T.D0061;
using R5T.T0016;


namespace Microsoft.AspNetCore.Razor.TagHelpers
{
    /// <summary>
    /// Base class for tag helpers that use a Razor view to specify markup that uses <typeparamref name="TModel"/> as its model.
    /// </summary>
    public abstract class RazorViewModeledTagHelperBase<TModel> : TagHelper
    {
        protected abstract string ViewName { get; }
        protected abstract bool PreserveElement { get; }

        private IRazorViewStringRenderer RazorViewStringRenderer { get; }


        public RazorViewModeledTagHelperBase(
            IRazorViewStringRenderer razorViewStringRenderer)
        {
            this.RazorViewStringRenderer = razorViewStringRenderer;
        }

        protected abstract Task<TModel> GetModel(TagHelperContext context, TagHelperOutput output);

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var model = await this.GetModel(context, output);

            var viewHtmlContentString = await this.RazorViewStringRenderer.Render(this.ViewName, model);

            output.Content.SetHtmlContent(viewHtmlContentString); // Set the content.

            // Remove the element if we don't want to preserve it.
            if (this.PreserveElement)
            {
                output.TagName = HtmlTags.div;
            }
            else
            {
                output.TagName = Strings.Empty;
            }
        }
    }
}
