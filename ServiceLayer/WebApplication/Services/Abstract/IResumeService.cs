using EntityLayer.WebApplication.ViewModels.ResumeViewModel;

namespace ServiceLayer.WebApplication.Services.Abstract
{
    public interface IResumeService
    {
        //Generic Methods
        Task AddResumeAsync(ResumeAddVM request);
        Task UpdateResumeAsync(ResumeUpdateVM request);
        Task DeleteResumeAsync(int id);
        Task<ResumeUpdateVM> GetResumeByIdAsync(int id);


        //Special Methods
        Task<IEnumerable<ResumeAdminListVM>> GetActiveResumeListAsync();
        Task<IEnumerable<ResumeAdminListVM>> GetInactiveResumeListAsync();
        Task SoftDeleteAsync(int id);
        Task ResumeActivateAsync(int id);
        Task MakeResumePublishedAsync(int id);
        Task MakeResumeEditableAsync(int id);
    }
}
