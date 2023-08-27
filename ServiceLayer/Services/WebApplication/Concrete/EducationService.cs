using AutoMapper;
using AutoMapper.QueryableExtensions;
using CoreLayer.Messages.ToastyMessages;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.EducationViewModel;
using EntityLayer.WebApplication.ViewModels.ResumeViewModel;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using RepositoryLayer.Repository.Generic.Abstract;
using RepositoryLayer.UnitOfWorks.Abstract;
using ServiceLayer.Services.WebApplication.Abstract;

namespace ServiceLayer.Services.WebApplication.Concrete
{
    public class EducationService : IEducationService
    {
        //Dependency Injections
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Education> _educationRepository;
        private readonly IToastNotification _toasty;
        private readonly IGenericMessages _messages;
        public EducationService(IUnitOfWork unitOfWork, IMapper mapper, IToastNotification toasty, IGenericMessages messages)
        {
            _educationRepository = unitOfWork.GetGenericRepository<Education>();
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _toasty = toasty;
            _messages = messages;
        }

        //ADMIN SIDE SERVICES-----------------

        //Listing Method
        public async Task<IEnumerable<EducationAdminListVM>> GetEducationListAsync()
        {
            var educations = await _educationRepository.Where(x => x.IsEdited == true).Include(x => x.Resume).OrderBy(x => x.Priorty).ProjectTo<EducationAdminListVM>(_mapper.ConfigurationProvider).ToListAsync();
            return educations;
        }

        //Add Method
        public async Task AddEducationAsync(EducationAddVM request)
        {
            var editableResume = await _unitOfWork.GetGenericRepository<Resume>().Where(x => x.IsEdited == true).ProjectTo<ResumeIdVM>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();
            request.ResumeId = editableResume.Id;
            request.IsPublished = editableResume.IsPublished;

            var education = _mapper.Map<Education>(request);
            await _educationRepository.AddAsync(education);
            var errorMessage = await _unitOfWork.CommitAsync();
            if (errorMessage != string.Empty)
            {
                _toasty.AddErrorToastMessage(errorMessage, new ToastrOptions { Title = "Opps!" });
                return;
            }
            _toasty.AddSuccessToastMessage(_messages.Add(education.Title), new ToastrOptions { Title = "Congratulations!" });

        }

        //Delete Method
        public async Task DeleteEducationAsync(int id)
        {
            var education = await _educationRepository.GetEntityByIdAsync(id);
            _educationRepository.Delete(education);
            var errorMessage = await _unitOfWork.CommitAsync();
            if (errorMessage != string.Empty)
            {
                _toasty.AddErrorToastMessage(errorMessage, new ToastrOptions { Title = "Opps!" });
                return;
            }
            _toasty.AddWarningToastMessage(_messages.Delete(education.Title), new ToastrOptions { Title = "Congratulations!" });

        }

        //Update Method
        public async Task UpdateEducationAsync(EducationUpdateVM request)
        {
            var education = _mapper.Map<Education>(request);
            _educationRepository.Update(education);
            var errorMessage = await _unitOfWork.CommitAsync();
            if (errorMessage != string.Empty)
            {
                _toasty.AddErrorToastMessage(errorMessage, new ToastrOptions { Title = "Opps!" });
                return;
            }
            _toasty.AddInfoToastMessage(_messages.Update(education.Title), new ToastrOptions { Title = "Congratulations!" });

        }

        //Selecting Method
        public async Task<EducationUpdateVM> GetEducationByIdAsync(int id)
        {
            var education = await _educationRepository.Where(x => x.Id == id).ProjectTo<EducationUpdateVM>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();
            return education;
        }



        //USER SIDE SERVICES-----------------

        //Listing Method
        public async Task<IEnumerable<EducationUserListVM>> GetEducationForUserListAsync()
        {
            var educationList = await _educationRepository.Where(x => x.IsPublished == true).OrderByDescending(x => x.Priorty).ProjectTo<EducationUserListVM>(_mapper.ConfigurationProvider).ToListAsync();
            return educationList;
        }

    }
}
