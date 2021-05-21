using System;
using System.Threading.Tasks;

using R5T.D0061;


namespace Microsoft.AspNetCore.Razor.TagHelpers
{
    /// <summary>
    /// Base class for tag helpers that use a Razor view to specify markup that uses <typeparamref name="TModel"/> as its model.
    /// </summary>
    public abstract class RazorViewedContentWrappingTagHelperBase<TModel> : RazorViewModeledTagHelperBase<TModel>
    {
        public RazorViewedContentWrappingTagHelperBase(IRazorViewStringRenderer razorViewStringRenderer)
            : base(razorViewStringRenderer)
        {
        }

        protected abstract Task<TModel> GetModel(TagHelperContext context, TagHelperOutput output, TagHelperContent childContent);

        protected override async Task<TModel> GetModel(TagHelperContext context, TagHelperOutput output)
        {
            var childContent = await output.GetChildContentAsync();

            var model = await this.GetModel(context, output, childContent);
            return model;
        }
    }
}
