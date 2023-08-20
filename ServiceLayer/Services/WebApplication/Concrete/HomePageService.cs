using AutoMapper;
using AutoMapper.QueryableExtensions;
using EntityLayer.Enums;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.HomePageViewModel;
using EntityLayer.WebApplication.ViewModels.ResumeViewModel;
using EntityLayer.WebApplication.ViewModels.SocialMediaViewModel;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using RepositoryLayer.Repository.Generic.Abstract;
using RepositoryLayer.UnitOfWorks.Abstract;
using ServiceLayer.Helpers.ImagesHelper;
using ServiceLayer.Helpers.ToastyMessages;
using ServiceLayer.Services.WebApplication.Abstract;

namespace ServiceLayer.Services.WebApplication.Concrete
{
    public class HomePageService : IHomePageService
    {
        //Dependency Injections
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<HomePage> _homePageRepository;
        private readonly IImageHelper _imageHelper;
        private readonly IToastNotification _toasty;
        private readonly IGenericMessages _messages;
        public HomePageService(IUnitOfWork unitOfWork, IMapper mapper, IImageHelper imageHelper, IToastNotification toasty, IGenericMessages messages)
        {
            _homePageRepository = unitOfWork.GetGenericRepository<HomePage>();
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _imageHelper = imageHelper;
            _toasty = toasty;
            _messages = messages;
        }

        //ADMIN SIDE SERVICES-----------------

        //Listing Method
        public async Task<IEnumerable<HomePageAdminListVM>> GetHomePageListAsync()
        {
            var educations = await _homePageRepository.Where(x => x.IsEdited == true).ProjectTo<HomePageAdminListVM>(_mapper.ConfigurationProvider).ToListAsync();
            return educations;
        }

        //Add Method
        public async Task AddHomePageAsync(HomePageAddVM request)
        {
            //creates new image           
            var imageUploadResume = await _imageHelper.ImageUpload(request.FullName, request.PhotoResumeCv, ImageType.Resume, null);
            request.ResumeCvFileName = imageUploadResume.FileName;
            request.ResumeCvFileType = request.PhotoResumeCv.ContentType;

            //try to create new aboutme data for db
            var editableResume = await _unitOfWork.GetGenericRepository<Resume>().Where(x => x.IsEdited == true).ProjectTo<ResumeIdVM>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();
            request.ResumeId = editableResume.Id;
            request.IsPublished = editableResume.IsPublished;

            var homepage = _mapper.Map<HomePage>(request);
            await _homePageRepository.AddAsync(homepage);
            var errorMessage = await _unitOfWork.CommitAsync();
            if (errorMessage != string.Empty)
            {
                //if exception, uploaded image deleted              
                _imageHelper.Delete(imageUploadResume.FileName);
                _toasty.AddErrorToastMessage(errorMessage, new ToastrOptions { Title = "Opps!" });
                return;
            }
            _toasty.AddSuccessToastMessage(_messages.Add(homepage.FullName), new ToastrOptions { Title = "Congratulations!" });
        }

        //Delete Method
        public async Task DeleteHomePageAsync(int id)
        {
            var homePage = await _homePageRepository.GetEntityByIdAsync(id);
            _homePageRepository.Delete(homePage);
            var errorMessage = await _unitOfWork.CommitAsync();
            if (errorMessage != string.Empty)
            {
                _toasty.AddErrorToastMessage(errorMessage, new ToastrOptions { Title = "Opps!" });
                return;
            }
            _imageHelper.Delete(homePage.ResumeCvFileName);
            _toasty.AddWarningToastMessage(_messages.Delete(homePage.FullName), new ToastrOptions { Title = "Congratulations!" });

        }

        //Update Method
        public async Task UpdateHomePageAsync(HomePageUpdateVM request)
        {
            var oldHomePage = await _homePageRepository.Where(x => x.Id == request.Id).AsNoTracking().SingleOrDefaultAsync();

            if (request.PhotoResumeCv != null)
            {
                //creates new image
                var imageUploadLogoResume = await _imageHelper.ImageUpload(request.FullName, request.PhotoResumeCv, ImageType.Resume, null);
                request.ResumeCvFileName = imageUploadLogoResume.FileName;
                request.ResumeCvFileType = request.PhotoResumeCv.ContentType;
            }

            //try to create aboutme data for db
            var homePage = _mapper.Map<HomePage>(request);
            _homePageRepository.Update(homePage);
            var errorMessage = await _unitOfWork.CommitAsync();
            if (errorMessage != string.Empty)
            {
                //if exception, uploaded image deleted
                if (request.PhotoResumeCv != null)
                {
                    _imageHelper.Delete(request.ResumeCvFileName);
                }
                _toasty.AddErrorToastMessage(errorMessage, new ToastrOptions { Title = "Opps!" });
                return;
            }
            //if succeed existing image will be deleted
            if (request.PhotoResumeCv != null)
            {
                _imageHelper.Delete(oldHomePage.ResumeCvFileName);
            }
            _toasty.AddInfoToastMessage(_messages.Update(homePage.FullName), new ToastrOptions { Title = "Congratulations!" });
        }

        //Selecting Method
        public async Task<HomePageUpdateVM> GetHomePageByIdAsync(int id)
        {
            var homePage = await _homePageRepository.Where(x => x.Id == id).ProjectTo<HomePageUpdateVM>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();
            return homePage;
        }



        //USER SIDE SERVICES-------------------

        //Listing Method
        public async Task<List<HomePageUserListVM>> HomePagePublishAsync()
        {

            var homePages = await _homePageRepository.Where(x => x.IsPublished == true).ProjectTo<HomePageUserListVM>(_mapper.ConfigurationProvider).ToListAsync();
            if(homePages.Count == 0)
            {
                return homePages;
            }
            var aboutMe =await _unitOfWork.GetGenericRepository<AboutMe>().GetAll().ToListAsync();

            if(aboutMe.Count == 0)
            {
                homePages.First().SocialMediaListVM = new SocialMediaListVM();
                return homePages;
            }
            var socialMedia = await _unitOfWork.GetGenericRepository<SocialMedia>().Where(x => x.AboutMe.ResumeId == homePages.First().ResumeId).ProjectTo<SocialMediaListVM>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();
            homePages.First().SocialMediaListVM = socialMedia;
            return homePages;
        }





    }
}
