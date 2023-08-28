using AutoMapper;
using AutoMapper.QueryableExtensions;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.ProjectCategoryViewModel;
using EntityLayer.WebApplication.ViewModels.ProjectViewModel;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using RepositoryLayer.Repository.Generic.Abstract;
using RepositoryLayer.UnitOfWorks.Abstract;
using ServiceLayer._SharedFolder.Messages.ToastyNotification;
using ServiceLayer.WebApplication.Services.Abstract;

namespace ServiceLayer.WebApplication.Services.Concrete
{
    public class ProjectService : IProjectService
    {
        //Dependancy injection
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Project> _projectRepository;
        private readonly IToastNotification _toasty;
        private readonly IGenericMessages _messages;

        public ProjectService(IMapper mapper, IUnitOfWork unitOfWork, IToastNotification toasty, IGenericMessages messages)
        {
            _projectRepository = unitOfWork.GetGenericRepository<Project>();
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _toasty = toasty;
            _messages = messages;
        }

        //ADMIN SIDE SERVICES-----------------

        //Listing Method
        public async Task<IEnumerable<ProjectAdminListVM>> GetProjectListAsync()
        {
            var projects = await _projectRepository.Where(x => x.Category.IsEdited == true).Include(x => x.Category).ProjectTo<ProjectAdminListVM>(_mapper.ConfigurationProvider).ToListAsync();
            return projects;
        }
        public async Task<IEnumerable<ProjectListDashboardVM>> GetProjectListForDashboardAsync()
        {
            var projects = await _projectRepository.Where(x => x.Category.IsPublished == true).Include(x => x.Images).ProjectTo<ProjectListDashboardVM>(_mapper.ConfigurationProvider).Take(7).ToListAsync();
            return projects;
        }

        //Category Listing method For Dropdown
        public async Task<List<ProjectCategoryForProjectVM>> GetCategoriesForProjectAsync()
        {
            var categories = await _unitOfWork.GetGenericRepository<ProjectCategory>().Where(x => x.IsEdited == true).ProjectTo<ProjectCategoryForProjectVM>(_mapper.ConfigurationProvider).ToListAsync();
            return categories;
        }

        //Add method
        public async Task AddProjectAsync(ProjectAddVM request)
        {
            var project = _mapper.Map<Project>(request);
            await _projectRepository.AddAsync(project);
            var errorMessage = await _unitOfWork.CommitAsync();
            if (errorMessage != string.Empty)
            {
                _toasty.AddErrorToastMessage(errorMessage, new ToastrOptions { Title = "Opps!" });
                return;
            }
            _toasty.AddSuccessToastMessage(_messages.Add(project.Title), new ToastrOptions { Title = "Congratulations!" });

        }

        //Delete method
        public async Task DeleteProjectAsync(int id)
        {
            var project = await _projectRepository.GetEntityByIdAsync(id);
            _projectRepository.Delete(project);
            var errorMessage = await _unitOfWork.CommitAsync();
            if (errorMessage != string.Empty)
            {
                _toasty.AddErrorToastMessage(errorMessage, new ToastrOptions { Title = "Opps!" });
                return;
            }
            _toasty.AddWarningToastMessage(_messages.Delete(project.Title), new ToastrOptions { Title = "Congratulations!" });

        }

        //Update Method
        public async Task UpdateProjectAsync(ProjectUpdateVM request)
        {
            var project = _mapper.Map<Project>(request);
            _projectRepository.Update(project);
            var errorMessage = await _unitOfWork.CommitAsync();
            if (errorMessage != string.Empty)
            {
                _toasty.AddErrorToastMessage(errorMessage, new ToastrOptions { Title = "Opps!" });
                return;
            }
            _toasty.AddInfoToastMessage(_messages.Update(project.Title), new ToastrOptions { Title = "Congratulations!" });

        }

        //Selecting Method for Update
        public async Task<ProjectUpdateVM> GetProjectByIdAsync(int id)
        {
            var project = await _projectRepository.Where(x => x.Id == id).ProjectTo<ProjectUpdateVM>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();
            return project;
        }

        //Selecting Method for Projectdetail
        public async Task<ProjectAdminListVM> GetProjectByIdFordetailAsync(int id)
        {
            var project = await _projectRepository.Where(x => x.Id == id).ProjectTo<ProjectAdminListVM>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();
            return project;
        }



        //USER SIDE SERVICES-----------------

        //Listing Method
        public async Task<ProjectUserVM> GetProjectForUserByIdAsync(int id)
        {
            var projectList = await _projectRepository.Where(x => x.Id == id).Include(x => x.Images).ProjectTo<ProjectUserVM>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();
            return projectList;
        }
    }
}
