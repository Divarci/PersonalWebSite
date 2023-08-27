using AutoMapper;
using AutoMapper.QueryableExtensions;
using CoreLayer.Messages.ToastyMessages;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.ExperienceViewModel;
using EntityLayer.WebApplication.ViewModels.ResumeViewModel;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using RepositoryLayer.Repository.Generic.Abstract;
using RepositoryLayer.UnitOfWorks.Abstract;
using ServiceLayer.Services.WebApplication.Abstract;

namespace ServiceLayer.Services.WebApplication.Concrete
{
    public class ExperienceService : IExperienceService
    {
        //Dependancy injection
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Experience> _experienceRepository;       
        private readonly IToastNotification _toasty;
        private readonly IGenericMessages _messages;
        public ExperienceService(IUnitOfWork unitOfWork, IMapper mapper, IToastNotification toasty, IGenericMessages messages)
        {
            _experienceRepository = unitOfWork.GetGenericRepository<Experience>();
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _toasty = toasty;
            _messages = messages;

        }
              
        //ADMIN SIDE SERVICES-----------------

        //Listing Method
        public async Task<IEnumerable<ExperienceAdminListVM>> GetExperienceListAsync()
        {
            var experiences = await _experienceRepository.Where(x => x.IsEdited == true).Include(x => x.Resume).OrderBy(x => x.Priorty).ProjectTo<ExperienceAdminListVM>(_mapper.ConfigurationProvider).ToListAsync();
            return experiences;
        }

        //Add Method
        public async Task AddExperienceAsync(ExperienceAddVM request)
        {
            var editableResume = await _unitOfWork.GetGenericRepository<Resume>().Where(x => x.IsEdited == true).ProjectTo<ResumeIdVM>(_mapper.ConfigurationProvider).SingleOrDefaultAsync(); 
            request.ResumeId = editableResume.Id;
            request.IsPublished = editableResume.IsPublished;

            var experience = _mapper.Map<Experience>(request);
            await _experienceRepository.AddAsync(experience);
            var errorMessage = await _unitOfWork.CommitAsync();
            if (errorMessage != string.Empty)
            {
                _toasty.AddErrorToastMessage(errorMessage, new ToastrOptions { Title = "Opps!" });
                return;
            }
            _toasty.AddSuccessToastMessage(_messages.Add(experience.Title), new ToastrOptions { Title = "Congratulations!" });

        }

        //Delete Method
        public async Task DeleteExperienceAsync(int id)
        {
            var experience = await _experienceRepository.GetEntityByIdAsync(id);
            _experienceRepository.Delete(experience);
            var errorMessage = await _unitOfWork.CommitAsync();
            if (errorMessage != string.Empty)
            {
                _toasty.AddErrorToastMessage(errorMessage, new ToastrOptions { Title = "Opps!" });
                return;
            }
            _toasty.AddWarningToastMessage(_messages.Delete(experience.Title), new ToastrOptions { Title = "Congratulations!" });

        }

        //Update method
        public async Task UpdateExperienceAsync(ExperienceUpdateVM request)
        {
            var experience = _mapper.Map<Experience>(request);
            _experienceRepository.Update(experience);
            var errorMessage = await _unitOfWork.CommitAsync();
            if (errorMessage != string.Empty)
            {
                _toasty.AddErrorToastMessage(errorMessage, new ToastrOptions { Title = "Opps!" });
                return;
            }
            _toasty.AddInfoToastMessage(_messages.Update(experience.Title), new ToastrOptions { Title = "Congratulations!" });

        }

        //Selecting Method
        public async Task<ExperienceUpdateVM> GetExperienceByIdAsync(int id)
        {
            var experience = await _experienceRepository.Where(x => x.Id == id).ProjectTo<ExperienceUpdateVM>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();
            return experience;
        }




        //USER SIDE SERVICES-----------------

        //Listing Method
        public async Task<IEnumerable<ExperienceUserListVM>> GetExperienceForUserListAsync()
        {
            var experienceList = await _experienceRepository.Where(x => x.IsPublished == true).OrderBy(x => x.Priorty).ProjectTo<ExperienceUserListVM>(_mapper.ConfigurationProvider).ToListAsync();
            return experienceList;
        }
    }
}
