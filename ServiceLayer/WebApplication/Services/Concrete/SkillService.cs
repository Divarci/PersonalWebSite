using AutoMapper;
using AutoMapper.QueryableExtensions;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.ResumeViewModel;
using EntityLayer.WebApplication.ViewModels.SkillViewModel;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using RepositoryLayer.Repository.Generic.Abstract;
using RepositoryLayer.UnitOfWorks.Abstract;
using ServiceLayer._SharedFolder.Messages.ToastyNotification;
using ServiceLayer.WebApplication.Services.Abstract;

namespace ServiceLayer.WebApplication.Services.Concrete
{

    public class SkillService : ISkillService
    {
        //dependancy injection
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Skill> _skillRepository;
        private readonly IToastNotification _toasty;
        private readonly IGenericMessages _messages;

        public SkillService(IUnitOfWork unitOfWork, IMapper mapper, IToastNotification toasty, IGenericMessages messages)
        {
            _skillRepository = unitOfWork.GetGenericRepository<Skill>();
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _toasty = toasty;
            _messages = messages;
        }

        //ADMIN SIDE ---------------------------

        //Listing Method
        public async Task<IEnumerable<SkillAdminListVM>> GetSkillListAsync()
        {
            var skills = await _skillRepository.Where(x => x.IsEdited == true).Include(x => x.Resume).ProjectTo<SkillAdminListVM>(_mapper.ConfigurationProvider).ToListAsync();
            return skills;
        }

        //Add method
        public async Task AddSkillAsync(SkillAddVM request)
        {
            var editableResume = await _unitOfWork.GetGenericRepository<Resume>().Where(x => x.IsEdited == true).ProjectTo<ResumeIdVM>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();
            request.ResumeId = editableResume.Id;
            request.IsPublished = editableResume.IsPublished;

            var skill = _mapper.Map<Skill>(request);
            await _skillRepository.AddAsync(skill);
            var errorMessage = await _unitOfWork.CommitAsync();
            if (errorMessage != string.Empty)
            {
                _toasty.AddErrorToastMessage(errorMessage, new ToastrOptions { Title = "Opps!" });
                return;
            }
            _toasty.AddSuccessToastMessage(_messages.Add(skill.Title), new ToastrOptions { Title = "Congratulations!" });

        }

        //Delete method
        public async Task DeleteSkillAsync(int id)
        {
            var skill = await _skillRepository.GetEntityByIdAsync(id);
            _skillRepository.Delete(skill);
            var errorMessage = await _unitOfWork.CommitAsync();
            if (errorMessage != string.Empty)
            {
                _toasty.AddErrorToastMessage(errorMessage, new ToastrOptions { Title = "Opps!" });
                return;
            }
            _toasty.AddWarningToastMessage(_messages.Delete(skill.Title), new ToastrOptions { Title = "Congratulations!" });

        }

        //Update Method
        public async Task UpdateSkillAsync(SkillUpdateVM request)
        {
            var skill = _mapper.Map<Skill>(request);
            _skillRepository.Update(skill);
            var errorMessage = await _unitOfWork.CommitAsync();
            if (errorMessage != string.Empty)
            {
                _toasty.AddErrorToastMessage(errorMessage, new ToastrOptions { Title = "Opps!" });
                return;
            }
            _toasty.AddInfoToastMessage(_messages.Update(skill.Title), new ToastrOptions { Title = "Congratulations!" });

        }

        //Selecting Method
        public async Task<SkillUpdateVM> GetSkillByIdAsync(int id)
        {
            var skill = await _skillRepository.Where(x => x.Id == id).ProjectTo<SkillUpdateVM>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();
            return skill;
        }



        //USER SIDE ---------------------------

        //Listing Method
        public async Task<IEnumerable<SkillUserListVM>> GetSkillListForUserAsync()
        {
            var skills = await _skillRepository.Where(x => x.IsPublished == true).ProjectTo<SkillUserListVM>(_mapper.ConfigurationProvider).ToListAsync();
            return skills;
        }
    }
}
