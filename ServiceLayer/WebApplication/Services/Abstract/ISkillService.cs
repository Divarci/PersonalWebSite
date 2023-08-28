using EntityLayer.WebApplication.ViewModels.SkillViewModel;

namespace ServiceLayer.WebApplication.Services.Abstract
{
    public interface ISkillService
    {
        //ADMIN SIDE SERVICES-----------------

        //Signatures for methods
        Task<IEnumerable<SkillAdminListVM>> GetSkillListAsync();
        Task AddSkillAsync(SkillAddVM request);
        Task DeleteSkillAsync(int id);
        Task UpdateSkillAsync(SkillUpdateVM request);
        Task<SkillUpdateVM> GetSkillByIdAsync(int id);


        //USER SIDE SERVICES-------------------

        //Signatures for methods
        Task<IEnumerable<SkillUserListVM>> GetSkillListForUserAsync();
    }
}
