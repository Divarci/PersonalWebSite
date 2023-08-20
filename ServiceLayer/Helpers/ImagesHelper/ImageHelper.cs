using EntityLayer.Enums;
using EntityLayer.WebApplication.ViewModels.GenericImageVM;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace ServiceLayer.Helpers.ImagesHelper
{
    //Helper area for adding image
    public class ImageHelper : IImageHelper
    {
        //Dependancy Injections and folder names
        private readonly IHostEnvironment _hostEnvironment;
        private readonly string wwwroot;
        private const string imagesFolder = "images";
        private const string projectImagesFolder = "projectImages";
        private const string userImagesFolder = "userImage";
        private const string resumeImagesFolder = "resumeImages";
        private const string signedInUserFolder = "signedInUserImages";
        private const string newsFeedimageFolder = "newsFeedImages";

        //define path for images
        public ImageHelper(IHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
            wwwroot = hostEnvironment.ContentRootPath + "wwwroot/";
        }

        //fixing file names
        private string ReplaceInvalidChars(string fileName)
        {
            return fileName.Replace("İ", "I")
                 .Replace("ı", "i")
                 .Replace("Ğ", "G")
                 .Replace("ğ", "g")
                 .Replace("Ü", "U")
                 .Replace("ü", "u")
                 .Replace("ş", "s")
                 .Replace("Ş", "S")
                 .Replace("Ö", "O")
                 .Replace("ö", "o")
                 .Replace("Ç", "C")
                 .Replace("ç", "c")
                 .Replace("é", "")
                 .Replace("!", "")
                 .Replace("'", "")
                 .Replace("^", "")
                 .Replace("+", "")
                 .Replace("%", "")
                 .Replace("/", "")
                 .Replace("(", "")
                 .Replace(")", "")
                 .Replace("=", "")
                 .Replace("?", "")
                 .Replace("_", "")
                 .Replace("*", "")
                 .Replace("æ", "")
                 .Replace("ß", "")
                 .Replace("@", "")
                 .Replace("€", "")
                 .Replace("<", "")
                 .Replace(">", "")
                 .Replace("#", "")
                 .Replace("$", "")
                 .Replace("½", "")
                 .Replace("{", "")
                 .Replace("[", "")
                 .Replace("]", "")
                 .Replace("}", "")
                 .Replace(@"\", "")
                 .Replace("|", "")
                 .Replace("~", "")
                 .Replace("¨", "")
                 .Replace(",", "")
                 .Replace(";", "")
                 .Replace("`", "")
                 .Replace(".", "")
                 .Replace(":", "")
                 .Replace(" ", "");
        }

        //image add method
        public async Task<GenericImageVM> ImageUpload(string name, IFormFile imageFile, ImageType imageType, string? folderName)
        {
            //folder creation. Always come null and define a folder name

            if (folderName == null)
            {
                switch (imageType)
                {
                    case ImageType.User:
                        folderName = userImagesFolder;
                        break;
                    case ImageType.Project:
                        folderName = projectImagesFolder;
                        break;
                    case ImageType.Resume:
                        folderName = resumeImagesFolder;
                        break;
                    case ImageType.SignedInUser:
                        folderName = signedInUserFolder;
                        break;
                    case ImageType.NewsImage:
                        folderName = newsFeedimageFolder;
                        break;
                    default:
                        break;
                }
            }

            //decide what should we do with defined foldername via if status
            if (!Directory.Exists($"{wwwroot}/{imagesFolder}/{folderName}"))
                Directory.CreateDirectory(($"{wwwroot}/{imagesFolder}/{folderName}"));

            //name fixing area
            string fileExtension = Path.GetExtension(imageFile.FileName);
            if(fileExtension != ".jpg" && fileExtension != ".jpeg" && fileExtension != ".png")
            {
                return new GenericImageVM { Error = "You have to upload a JPG,JPEG or PNG" };
            }
            string oldFileName = Path.GetFileNameWithoutExtension(imageFile.FileName);
            name = ReplaceInvalidChars(name) + "_" + ReplaceInvalidChars(oldFileName);
            DateTime datetime = DateTime.Now;
            var newFileName = $"{name}_{datetime.Millisecond}{fileExtension}";


            //define save path
            string path = Path.Combine($"{wwwroot}/{imagesFolder}/{folderName}", newFileName);

            //save picture
            await using var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);
            await imageFile.CopyToAsync(stream);
            await stream.FlushAsync();

            return new GenericImageVM { FileName = $"{folderName}/{newFileName}" };

        }

        //delete method for pictures
        public string Delete(string imageName)
        {

            var fileToDelete = Path.Combine($"{wwwroot}/{imagesFolder}/{imageName}");
            if (File.Exists(fileToDelete)) File.Delete(fileToDelete);

            return "Deleted";
        }



    }
}
