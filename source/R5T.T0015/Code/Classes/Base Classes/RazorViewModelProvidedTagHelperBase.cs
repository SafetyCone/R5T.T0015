using System;
using System.Threading.Tasks;

using R5T.D0061;


namespace Microsoft.AspNetCore.Razor.TagHelpers
{
    public abstract class RazorViewModelProvidedTagHelperBase<TModel> : RazorViewModeledTagHelperBase<TModel>
    {
        public TModel Model { get; set; }


        public RazorViewModelProvidedTagHelperBase(IRazorViewStringRenderer razorViewStringRenderer)
            : base(razorViewStringRenderer)
        {
        }

        protected override Task<TModel> GetModel(TagHelperContext context, TagHelperOutput output)
        {
            return Task.FromResult(this.Model);
        }
    }
}
