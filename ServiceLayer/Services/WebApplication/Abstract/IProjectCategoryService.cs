using EntityLayer.WebApplication.ViewModels.ProjectCategoryViewModel;

namespace ServiceLayer.Services.WebApplication.Abstract
{
    public interface IProjectCategoryService
    {

        //ADMIN SIDE SERVICES-----------------

        //Signatures for methods
        Task<IEnumerable<ProjectCategoryAdminListVM>> GetProjectCategoryListAsync();
        Task AddProjectCategoryAsync(ProjectCategoryAddVM request);
        Task DeleteProjectCategoryAsync(int id);
        Task UpdateProjectCategoryAsync(ProjectCategoryUpdateVM request);
        Task<ProjectCategoryUpdateVM> GetProjectCategoryByIdAsync(int id);


        //USER SIDE SERVICES-------------------

        //Signatures for methods
        Task<IEnumerable<ProjectCategoryForUserListVM>> GetProjectCategoryWithAllChildrenAsync();
    }
}
