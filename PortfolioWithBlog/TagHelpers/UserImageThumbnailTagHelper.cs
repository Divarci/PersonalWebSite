using EntityLayer.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ServiceLayer.Helpers.TagHelpers
{
    public class UserImageThumbnailTagHelper : TagHelper
    {
        //prop that we need it for define source
        public string? FileName { get; set; }

        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHostEnvironment _environment;
        private readonly string imageFolderPath;

        public UserImageThumbnailTagHelper(IHostEnvironment environment, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _environment = environment;
            imageFolderPath = _environment.ContentRootPath + "wwwroot/images/signedInUserImages/";
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public override async Task<Task> ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "img";

            var signedInUser = _signInManager.Context.User.Identity!.Name!.ToString();
            var user = await _userManager.FindByNameAsync(signedInUser);

            if (!string.IsNullOrEmpty(user.FileName))
            {
                output.Attributes.SetAttribute("src", $"/images/{FileName}");
                return base.ProcessAsync(context, output);

            }

            output.Attributes.SetAttribute("src", $"/images/signedInUserImages/defaultUser.png");
            return base.ProcessAsync(context, output);
        }
    }
}
