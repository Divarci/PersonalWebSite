using EntityLayer.WebApplication.ViewModels.ProjectImageViewModel;
using EntityLayer.WebApplication.ViewModels.ProjectViewModel;

namespace ServiceLayer.WebApplication.Services.Abstract
{
    public interface IProjectImageService
    {
        //Method signatures
        Task<IEnumerable<ProjectImageAdminListVM>> GetAllImageAsync(int id);
        Task AddImageAsync(ProjectImageAddVM request);
        Task<ProjectForImageVM> GetProjectByIdAsync(int id);
        Task UpdateImageAsync(ProjectImageUpdateVM request);
        Task<ProjectImageUpdateVM> GetImageByIdAsync(int id);
        Task<int> DeleteImage(int id);
    }
}
