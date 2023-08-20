using EntityLayer.WebApplication.ViewModels.ProjectCategoryViewModel;
using EntityLayer.WebApplication.ViewModels.ProjectViewModel;

namespace ServiceLayer.Services.WebApplication.Abstract
{
    public interface IProjectService
    {
        //ADMIN SIDE SERVICES-----------------

        //Signatures for methods
        Task<IEnumerable<ProjectAdminListVM>> GetProjectListAsync();
        Task<IEnumerable<ProjectListDashboardVM>> GetProjectListForDashboardAsync();
        Task<List<ProjectCategoryForProjectVM>> GetCategoriesForProjectAsync();      
        Task AddProjectAsync(ProjectAddVM request);
        Task DeleteProjectAsync(int id);
        Task UpdateProjectAsync(ProjectUpdateVM request);
        Task<ProjectUpdateVM> GetProjectByIdAsync(int id);
        Task<ProjectAdminListVM> GetProjectByIdFordetailAsync(int id);


        //ADMIN SIDE SERVICES-----------------

        //Signatures for methods
        Task<ProjectUserVM> GetProjectForUserByIdAsync(int id);

    }
}
