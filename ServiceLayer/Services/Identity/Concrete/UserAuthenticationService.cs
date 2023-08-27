using AutoMapper;
using CoreLayer.Enums;
using CoreLayer.Messages.ToastyMessages;
using EntityLayer.Identity.Entities;
using EntityLayer.Identity.ViewModes;
using Microsoft.AspNetCore.Identity;
using NToastNotify;
using ServiceLayer.Helpers.ImagesHelper;
using ServiceLayer.Services.Identity.Abstract;
using System.Security.Claims;

namespace ServiceLayer.Services.Identity.Concrete
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;
        private readonly IImageHelper _imageHelper;
        private readonly IToastNotification _toasty;
        private readonly IIdentityMessages _messages;

        public UserAuthenticationService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMapper mapper, IImageHelper imageHelper, IToastNotification toasty, IIdentityMessages messages)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _imageHelper = imageHelper;
            _toasty = toasty;
            _messages = messages;
        }


        //Get User By Name
        public async Task<UserEditVM> GetUserByNameAsync(ClaimsPrincipal signedInUser)
        {
            var user = await _userManager.FindByNameAsync(signedInUser.Identity!.Name);
            var userEditVM = _mapper.Map<UserEditVM>(user);
            return userEditVM;
        }

        //User Edit
        public async Task<IdentityResult> UserEditAsync(UserEditVM request, ClaimsPrincipal signedInUser)
        {
            //find authenticated user
            var user = await _userManager.FindByNameAsync(signedInUser.Identity!.Name);
            var oldFileName = user.FileName; // keep old picture path we might need it to delete it later

            //if we add photo creates new one
            if (request.Photo != null)
            {
                var image = await _imageHelper.ImageUpload(request.UserName, request.Photo, ImageType.SignedInUser, null);
                request.FileName = image.FileName;
                request.FileType = request.Photo.ContentType;

            }
            //if we dont add a photo
            else
            {
                request.FileName = user.FileName;
                request.FileType = user.FileType;
            }

            //update user
            var resultUpdateUser = await _userManager.UpdateAsync(_mapper.Map(request, user));
            if (resultUpdateUser.Succeeded)
            {
                //if we add photo it deletes the old one if it is exist
                if (request.Photo != null)
                {
                    if (oldFileName != null)
                    {
                        _imageHelper.Delete(oldFileName);
                    }
                }
                //if we dont have just saves it
                await _userManager.UpdateSecurityStampAsync(user);
                await _signInManager.SignOutAsync();
                await _signInManager.SignInAsync(user, true);
                _toasty.AddSuccessToastMessage(_messages.Update(user.UserName), new ToastrOptions { Title = "Congratulations!" });
                return resultUpdateUser;
            }

            //if failed deletes new added picture
            if (request.FileName != null)
            {
                _imageHelper.Delete(request.FileName);
            }

            //if we attempt to change password. we changed our password at ontroller before here, we got rollack here
            if (request.NewPassword != null)
            {
                await _userManager.ChangePasswordAsync(user, request.NewPassword, request.Password);
                await _userManager.UpdateSecurityStampAsync(user);
                await _signInManager.SignOutAsync();
                await _signInManager.SignInAsync(user, true);
            }
            return resultUpdateUser;
        }

        //Get User Image
        public async Task<UserThumbnailVM> GetUserImageAsync(string signedInUser)
        {
            //Selects the user image
            var user = await _userManager.FindByNameAsync(signedInUser);
            var userImage = _mapper.Map<UserThumbnailVM>(user);
            if (userImage == null)
            {
                return new UserThumbnailVM { FileName = "default" };
            }
            return userImage;
        }



    }
}
