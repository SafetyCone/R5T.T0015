using System;
using System.Threading.Tasks;

using R5T.D0061;


namespace Microsoft.AspNetCore.Razor.TagHelpers
{
    /// <summary>
    /// Base class for tag helpers that use a Razor view to specify markup that wraps inner content.
    /// Note: Razor view must use <see cref="TagHelperContent"/> as its model.
    /// </summary>
    public abstract class RazorViewContentWrappingTagHelperBase : RazorViewModeledTagHelperBase<TagHelperContent>
    {
        public RazorViewContentWrappingTagHelperBase(IRazorViewStringRenderer razorViewStringRenderer)
            : base(razorViewStringRenderer)
        {
        }

        protected override Task<TagHelperContent> GetModel(TagHelperContext context, TagHelperOutput output)
        {
            var gettingChildContent = output.GetChildContentAsync();
            return gettingChildContent;
        }
    }
}
