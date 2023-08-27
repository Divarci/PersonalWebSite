using CoreLayer.Enums;
using EntityLayer.WebApplication.ViewModels.GenericImageVM;
using Microsoft.AspNetCore.Http;

namespace ServiceLayer.Helpers.ImagesHelper
{
    public interface IImageHelper
    {
        //signatures for image methods
        Task<GenericImageVM> ImageUpload(string name, IFormFile imageFile, ImageType imageType, string? folderName);
        string Delete(string imageName);
    }
}