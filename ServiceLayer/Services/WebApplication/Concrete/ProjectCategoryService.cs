using AutoMapper;
using AutoMapper.QueryableExtensions;
using CoreLayer.Messages.ToastyMessages;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.ProjectCategoryViewModel;
using EntityLayer.WebApplication.ViewModels.ResumeViewModel;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using RepositoryLayer.Repository.Generic.Abstract;
using RepositoryLayer.UnitOfWorks.Abstract;
using ServiceLayer.Services.WebApplication.Abstract;

namespace ServiceLayer.Services.WebApplication.Concrete
{
    public class ProjectCategoryService : IProjectCategoryService
    {
        //dependancy injection
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<ProjectCategory> _categoryRepository;      
        private readonly IToastNotification _toasty;
        private readonly IGenericMessages _messages;
        public ProjectCategoryService(IUnitOfWork unitOfWork, IMapper mapper, IToastNotification toasty, IGenericMessages messages)
        {
            _categoryRepository = unitOfWork.GetGenericRepository<ProjectCategory>();
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _toasty = toasty;
            _messages = messages;
        }

        //ADMIN SIDE SERVICES-----------------

        //Listing Method
        public async Task<IEnumerable<ProjectCategoryAdminListVM>> GetProjectCategoryListAsync()
        {
            var categories = await _categoryRepository.Where(x => x.IsEdited == true).Include(x => x.Resume).ProjectTo<ProjectCategoryAdminListVM>(_mapper.ConfigurationProvider).ToListAsync();
            return categories;
        }

        //Add method
        public async Task AddProjectCategoryAsync(ProjectCategoryAddVM request)
        {
            var editableResume = await _unitOfWork.GetGenericRepository<Resume>().Where(x => x.IsEdited == true).ProjectTo<ResumeIdVM>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();
            request.ResumeId = editableResume.Id;
            request.IsPublished = editableResume.IsPublished;

            var category = _mapper.Map<ProjectCategory>(request);
            await _categoryRepository.AddAsync(category);
            var errorMessage = await _unitOfWork.CommitAsync();
            if (errorMessage != string.Empty)
            {
                _toasty.AddErrorToastMessage(errorMessage, new ToastrOptions { Title = "Opps!" });
                return;
            }
            _toasty.AddSuccessToastMessage(_messages.Add(category.Title), new ToastrOptions { Title = "Congratulations!" });

        }

        //Delete method
        public async Task DeleteProjectCategoryAsync(int id)
        {
            var category = await _categoryRepository.GetEntityByIdAsync(id);
            _categoryRepository.Delete(category);
            var errorMessage = await _unitOfWork.CommitAsync();
            if (errorMessage != string.Empty)
            {
                _toasty.AddErrorToastMessage(errorMessage, new ToastrOptions { Title = "Opps!" });
                return;
            }
            _toasty.AddWarningToastMessage(_messages.Delete(category.Title), new ToastrOptions { Title = "Congratulations!" });

        }

        //Update Method
        public async Task UpdateProjectCategoryAsync(ProjectCategoryUpdateVM request)
        {
            var category = _mapper.Map<ProjectCategory>(request);
            _categoryRepository.Update(category);
            var errorMessage = await _unitOfWork.CommitAsync();
            if (errorMessage != string.Empty)
            {
                _toasty.AddErrorToastMessage(errorMessage, new ToastrOptions { Title = "Opps!" });
                return;
            }
            _toasty.AddInfoToastMessage(_messages.Update(category.Title), new ToastrOptions { Title = "Congratulations!" });

        }

        //Selecting Method
        public async Task<ProjectCategoryUpdateVM> GetProjectCategoryByIdAsync(int id)
        {
            var category = await _categoryRepository.Where(x => x.Id == id).ProjectTo<ProjectCategoryUpdateVM>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();
            return category;
        }


        //USER SIDE SERVICES-----------------

        //Listing Method
        public async Task<IEnumerable<ProjectCategoryForUserListVM>> GetProjectCategoryWithAllChildrenAsync()
        {
            var allCategoryList =await _categoryRepository.Where(x => x.IsPublished == true).Include(x => x.Projects).ThenInclude(x => x.Images).ProjectTo<ProjectCategoryForUserListVM>(_mapper.ConfigurationProvider).ToListAsync();
            return allCategoryList;
        }
    }
}
