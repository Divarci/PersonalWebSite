using CoreLayer.Enums;
using EntityLayer.WebApplication.ViewModels.GenericImageVM;
using Microsoft.AspNetCore.Http;

namespace ServiceLayer._SharedFolder.Helpers.ImageHelper
{
    public interface IImageHelper
    {
        //signatures for image methods
        Task<GenericImageVM> ImageUpload(string name, IFormFile imageFile, ImageType imageType, string? folderName);
        string Delete(string imageName);
    }
}