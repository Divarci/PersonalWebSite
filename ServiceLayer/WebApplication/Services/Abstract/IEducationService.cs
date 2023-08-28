using EntityLayer.WebApplication.ViewModels.EducationViewModel;

namespace ServiceLayer.WebApplication.Services.Abstract
{
    public interface IEducationService
    {
        //ADMIN SIDE SERVICES-----------------

        //Signatures for methods
        Task<IEnumerable<EducationAdminListVM>> GetEducationListAsync();
        Task AddEducationAsync(EducationAddVM request);
        Task DeleteEducationAsync(int id);
        Task UpdateEducationAsync(EducationUpdateVM request);
        Task<EducationUpdateVM> GetEducationByIdAsync(int id);


        //USER SIDE SERVICES-------------------

        //Signatures for methods
        Task<IEnumerable<EducationUserListVM>> GetEducationForUserListAsync();
    }
}
