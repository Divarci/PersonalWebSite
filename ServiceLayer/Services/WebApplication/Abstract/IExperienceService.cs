using EntityLayer.WebApplication.ViewModels.ExperienceViewModel;

namespace ServiceLayer.Services.WebApplication.Abstract
{
    public interface IExperienceService
    {
        //ADMIN SIDE SERVICES-----------------

        //Signatures for methods
        Task<IEnumerable<ExperienceAdminListVM>> GetExperienceListAsync();
        Task AddExperienceAsync(ExperienceAddVM request);
        Task DeleteExperienceAsync(int id);
        Task UpdateExperienceAsync(ExperienceUpdateVM request);
        Task<ExperienceUpdateVM> GetExperienceByIdAsync(int id);

        //USER SIDE SERVICES-----------------

        //Listing Method
        Task<IEnumerable<ExperienceUserListVM>> GetExperienceForUserListAsync();
    }
}
