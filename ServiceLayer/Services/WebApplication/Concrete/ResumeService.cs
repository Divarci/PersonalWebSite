using AutoMapper;
using AutoMapper.QueryableExtensions;
using CoreLayer.Messages.ToastyMessages;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.ResumeViewModel;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using RepositoryLayer.Repository.Generic.Abstract;
using RepositoryLayer.UnitOfWorks.Abstract;
using ServiceLayer.Services.WebApplication.Abstract;

namespace ServiceLayer.Services.WebApplication.Concrete
{
    public class ResumeService : IResumeService
    {
        //Dependancy injection
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Resume> _resumeRepository;
        private readonly IToastNotification _toasty;
        private readonly IResumeMessages _messages;


        public ResumeService(IMapper mapper, IUnitOfWork unitOfWork, IToastNotification toasty, IResumeMessages messages)
        {
            _resumeRepository = unitOfWork.GetGenericRepository<Resume>();
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _toasty = toasty;
            _messages = messages;
        }


        //Add Method
        public async Task AddResumeAsync(ResumeAddVM request)
        {
            var resume = _mapper.Map<Resume>(request);
            resume.IsPublished = false;
            await _resumeRepository.AddAsync(resume);
            var errorMessage = await _unitOfWork.CommitAsync();
            if (errorMessage != string.Empty)
            {
                _toasty.AddErrorToastMessage(errorMessage, new ToastrOptions { Title = "Opps!" });
                return;
            }
            _toasty.AddSuccessToastMessage(_messages.Add(resume.Title), new ToastrOptions { Title = "Congratulations!" });

        }

        //Update Method
        public async Task UpdateResumeAsync(ResumeUpdateVM request)
        {
            var resume = _mapper.Map<Resume>(request);
            _resumeRepository.Update(resume);
            var errorMessage = await _unitOfWork.CommitAsync();
            if (errorMessage != string.Empty)
            {
                _toasty.AddErrorToastMessage(errorMessage, new ToastrOptions { Title = "Opps!" });
                return;
            }
            _toasty.AddInfoToastMessage(_messages.Update(resume.Title), new ToastrOptions { Title = "Congratulations!" });

        }

        //Delete Method
        public async Task DeleteResumeAsync(int id)
        {
            var resume = await _resumeRepository.GetEntityByIdAsync(id);
            _resumeRepository.Delete(resume);
            var errorMessage = await _unitOfWork.CommitAsync();
            if (errorMessage != string.Empty)
            {
                _toasty.AddErrorToastMessage(errorMessage, new ToastrOptions { Title = "Opps!" });
                return;
            }
            _toasty.AddWarningToastMessage(_messages.Delete(resume.Title), new ToastrOptions { Title = "Congratulations!" });

        }

        //Selecting Method
        public async Task<ResumeUpdateVM> GetResumeByIdAsync(int id)
        {
            var resume = await _resumeRepository.Where(x => x.Id == id).ProjectTo<ResumeUpdateVM>(_mapper.ConfigurationProvider).SingleAsync();
            return resume;
        }

        //Active resume List Method
        public async Task<IEnumerable<ResumeAdminListVM>> GetActiveResumeListAsync()
        {
            var activeResumeList = await _resumeRepository.Where(x => x.IsDeleted == false).ProjectTo<ResumeAdminListVM>(_mapper.ConfigurationProvider).ToListAsync();
            return activeResumeList;
        }

        //Inactive resume List Method
        public async Task<IEnumerable<ResumeAdminListVM>> GetInactiveResumeListAsync()
        {
            var inactiveResumeList = await _resumeRepository.Where(x => x.IsDeleted == true).ProjectTo<ResumeAdminListVM>(_mapper.ConfigurationProvider).ToListAsync();
            return inactiveResumeList;
        }

        //make Inactive Method
        public async Task SoftDeleteAsync(int id)
        {
            var resume = await _resumeRepository.GetEntityByIdAsync(id);
            if (resume.IsEdited || resume.IsPublished)
            {
                _toasty.AddErrorToastMessage(_messages.CanNotDelete(resume.Title), new ToastrOptions { Title = "Opps!" });
                return;
            }          

            resume.IsDeleted = true;
            var errorMessage = await _unitOfWork.CommitAsync();
            if (errorMessage != string.Empty)
            {
                _toasty.AddErrorToastMessage(errorMessage, new ToastrOptions { Title = "Opps!" });
                return;
            }
            _toasty.AddWarningToastMessage(_messages.Inaktivated(resume.Title), new ToastrOptions { Title = "Congratulations!" });
            return;

        }

        //make Active Method
        public async Task ResumeActivateAsync(int id)
        {
            var resume = await _resumeRepository.GetEntityByIdAsync(id);
            resume.IsDeleted = false;
            var errorMessage = await _unitOfWork.CommitAsync();
            if (errorMessage != string.Empty)
            {
                _toasty.AddErrorToastMessage(errorMessage, new ToastrOptions { Title = "Opps!" });
                return;
            }
            _toasty.AddSuccessToastMessage(_messages.Aktivated(resume.Title), new ToastrOptions { Title = "Opps!" });

        }

        //make Resume Published Method
        public async Task MakeResumePublishedAsync(int id)
        {
            var resumeOld = await _resumeRepository.Where(x => x.IsPublished == true).Include(x => x.Certificates).Include(x => x.Skills).Include(x => x.ProjectCategories).Include(x => x.Experiences).Include(x => x.Educations).Include(x => x.AboutMe).Include(x => x.HomePage).ToListAsync();


            if (resumeOld != null)
            {
                foreach (var resume in resumeOld)
                {
                    resume.IsPublished = false;

                    if (resume.Certificates != null)
                        foreach (var item in resume.Certificates)
                            item.IsPublished = false;

                    if (resume.Skills != null)
                        foreach (var item in resume.Skills)
                            item.IsPublished = false;

                    if (resume.ProjectCategories != null)
                        foreach (var item in resume.ProjectCategories)
                            item.IsPublished = false;

                    if (resume.Experiences != null)
                        foreach (var item in resume.Experiences)
                            item.IsPublished = false;

                    if (resume.Educations != null)
                        foreach (var item in resume.Educations)
                            item.IsPublished = false;

                    if (resume.AboutMe != null)
                        resume.AboutMe.IsPublished = false;

                    if (resume.HomePage != null)
                        resume.HomePage.IsPublished = false;
                }
            }


            var newResume = await _resumeRepository.Where(x => x.Id == id).Include(x => x.Certificates).Include(x => x.Skills).Include(x => x.ProjectCategories).Include(x => x.Experiences).Include(x => x.Educations).Include(x => x.AboutMe).Include(x => x.HomePage).ToListAsync();



            if (newResume != null)
            {
                foreach (var resume in newResume)
                {
                    resume.IsPublished = true;

                    if (resume.Certificates != null)
                        foreach (var item in resume.Certificates)
                            item.IsPublished = true;

                    if (resume.Skills != null)
                        foreach (var item in resume.Skills)
                            item.IsPublished = true;

                    if (resume.ProjectCategories != null)
                        foreach (var item in resume.ProjectCategories)
                            item.IsPublished = true;

                    if (resume.Experiences != null)
                        foreach (var item in resume.Experiences)
                            item.IsPublished = true;

                    if (resume.Educations != null)
                        foreach (var item in resume.Educations)
                            item.IsPublished = true;

                    if (resume.AboutMe != null)
                        resume.AboutMe.IsPublished = true;

                    if (resume.HomePage != null)
                        resume.HomePage.IsPublished = true;
                }
            }

            var errorMessage = await _unitOfWork.CommitAsync();
            if (errorMessage != string.Empty)
            {
                _toasty.AddErrorToastMessage(errorMessage, new ToastrOptions { Title = "Opps!" });
                return;
            }
            _toasty.AddSuccessToastMessage(_messages.Published(newResume.SingleOrDefault().Title), new ToastrOptions { Title = "Congratulations!" });

        }

        //make Resume editable Method
        public async Task MakeResumeEditableAsync(int id)
        {
            var resumeOld = await _resumeRepository.Where(x => x.IsEdited == true).Include(x => x.Certificates).Include(x => x.Skills).Include(x => x.ProjectCategories).Include(x => x.Experiences).Include(x => x.Educations).Include(x => x.AboutMe).Include(x => x.HomePage).Include(x => x.Messages).ToListAsync();

            if (resumeOld != null)
            {
                foreach (var resume in resumeOld)
                {
                    resume.IsEdited = false;

                    if (resume.Certificates != null)
                        foreach (var item in resume.Certificates)
                            item.IsEdited = false;

                    if (resume.Skills != null)
                        foreach (var item in resume.Skills)
                            item.IsEdited = false;

                    if (resume.ProjectCategories != null)
                        foreach (var item in resume.ProjectCategories)
                            item.IsEdited = false;

                    if (resume.Experiences != null)
                        foreach (var item in resume.Experiences)
                            item.IsEdited = false;

                    if (resume.Educations != null)
                        foreach (var item in resume.Educations)
                            item.IsEdited = false;

                    if (resume.Messages != null)
                        foreach (var item in resume.Messages)
                            item.IsEdited = false;

                    if (resume.AboutMe != null)
                        resume.AboutMe.IsEdited = false;

                    if (resume.HomePage != null)
                        resume.HomePage.IsEdited = false;
                }
            }
            var newResume = await _resumeRepository.Where(x => x.Id == id).Include(x => x.Certificates).Include(x => x.Skills).Include(x => x.ProjectCategories).Include(x => x.Experiences).Include(x => x.Educations).Include(x => x.AboutMe).Include(x => x.HomePage).Include(x => x.Messages).ToListAsync();


            if (newResume != null)
            {
                foreach (var resume in newResume)
                {
                    resume.IsEdited = true;

                    if (resume.Certificates != null)
                        foreach (var item in resume.Certificates)
                            item.IsEdited = true;

                    if (resume.Skills != null)
                        foreach (var item in resume.Skills)
                            item.IsEdited = true;

                    if (resume.ProjectCategories != null)
                        foreach (var item in resume.ProjectCategories)
                            item.IsEdited = true;

                    if (resume.Experiences != null)
                        foreach (var item in resume.Experiences)
                            item.IsEdited = true;

                    if (resume.Educations != null)
                        foreach (var item in resume.Educations)
                            item.IsEdited = true;

                    if (resume.Messages != null)
                        foreach (var item in resume.Messages)
                            item.IsEdited = true;

                    if (resume.AboutMe != null)
                        resume.AboutMe.IsEdited = true;

                    if (resume.HomePage != null)
                        resume.HomePage.IsEdited = true;
                }
            }


            var errorMessage = await _unitOfWork.CommitAsync();
            if (errorMessage != string.Empty)
            {
                _toasty.AddErrorToastMessage(errorMessage, new ToastrOptions { Title = "Opps!" });
                return;
            }
            _toasty.AddSuccessToastMessage(_messages.Editable(newResume.SingleOrDefault().Title), new ToastrOptions { Title = "Congratulations!" });

        }

    }


}

