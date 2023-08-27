using AutoMapper;
using AutoMapper.QueryableExtensions;
using CoreLayer.Enums;
using CoreLayer.Messages.ToastyMessages;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.AboutMeViewModel;
using EntityLayer.WebApplication.ViewModels.ResumeViewModel;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using RepositoryLayer.Repository.Generic.Abstract;
using RepositoryLayer.UnitOfWorks.Abstract;
using ServiceLayer.Helpers.ImagesHelper;
using ServiceLayer.Services.WebApplication.Abstract;

namespace ServiceLayer.Services.WebApplication.Concrete
{
    public class AboutMeService : IAboutMeService
    {
        //Dependancy Injections
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<AboutMe> _aboutMeRepository;
        private readonly IImageHelper _imageHelper;
        private readonly IToastNotification _toasty;
        private readonly IGenericMessages _message;


        public AboutMeService(IMapper mapper, IUnitOfWork unitOfWork, IImageHelper imageHelper, IToastNotification toasty, IGenericMessages message)
        {
            _aboutMeRepository = unitOfWork.GetGenericRepository<AboutMe>();
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _imageHelper = imageHelper;
            _toasty = toasty;
            _message = message;

        }

        //ADMIN SIDE SERVICES-----------------

        //Update method
        public async Task UpdateAboutMeAsync(AboutMeUpdateVM request)
        {
            //gets data id
            var oldAboutMe = await _aboutMeRepository.Where(x => x.Id == request.Id).AsNoTracking().SingleOrDefaultAsync();

            //checks is there any photo update
            if (request.Photo != null)
            {
                //creates new image
                var imageUpload = await _imageHelper.ImageUpload(request.Title, request.Photo, ImageType.User, null);
                if (imageUpload.Error != null)
                {
                    _toasty.AddErrorToastMessage(_message.ImageError(), new ToastrOptions { Title = "Opps!" });
                    return;
                }
                request.FileName = imageUpload.FileName!;
                request.FileType = request.Photo.ContentType;
            }

            //try to create aboutme data for db
            var aboutMe = _mapper.Map<AboutMe>(request);
            _aboutMeRepository.Update(aboutMe);
            var errorMessage = await _unitOfWork.CommitAsync();
            if (errorMessage != string.Empty)
            {
                //if exception, uploaded image deleted
                if (request.Photo != null)
                {
                    _imageHelper.Delete(request.FileName!);

                }
                _toasty.AddErrorToastMessage(errorMessage, new ToastrOptions { Title = "Opps!" });
                return;
            }

            //if succeed existing image will be deleted
            if (request.Photo != null)
            {
                _imageHelper.Delete(oldAboutMe!.FileName!);
            }
            _toasty.AddInfoToastMessage(_message.Update(aboutMe.Title), new ToastrOptions { Title = "Congratulations" });

        }

        //add method
        public async Task AddAboutMeAsync(AboutMeAddVM request)
        {
            //creates new image
            var imageUpload = await _imageHelper.ImageUpload(request.Title, request.Photo, ImageType.User, null);
            if (imageUpload.Error != null)
            {
                _toasty.AddErrorToastMessage(_message.ImageError(), new ToastrOptions { Title = "Opps!" });
                return;
            }
            request.FileName = imageUpload.FileName!;
            request.FileType = request.Photo.ContentType;

            //try to create new aboutme data for db
            var editableRresume = await _unitOfWork.GetGenericRepository<Resume>().Where(x => x.IsEdited == true).ProjectTo<ResumeIdVM>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();
            request.ResumeId = editableRresume!.Id;
            request.IsPublished = editableRresume.IsPublished;

            var aboutMe = _mapper.Map<AboutMe>(request);
            await _aboutMeRepository.AddAsync(aboutMe);
            var errorMessage = await _unitOfWork.CommitAsync();

            if (errorMessage != string.Empty)
            {
                //if exception, uploaded image deleted
                _imageHelper.Delete(imageUpload.FileName!);
                _toasty.AddErrorToastMessage(errorMessage, new ToastrOptions { Title = "Oppps" });
                return;
            }
            _toasty.AddSuccessToastMessage(_message.Add(aboutMe.Title), new ToastrOptions { Title = "Congratulations" });
        }
        //delete method
        public async Task DeleteAboutMeAsync(int id)
        {
            var aboutMe = await _aboutMeRepository.GetEntityByIdAsync(id);
            _aboutMeRepository.Delete(aboutMe);
            var errorMessage = await _unitOfWork.CommitAsync();
            if (errorMessage != string.Empty)
            {
                _toasty.AddWarningToastMessage(errorMessage, new ToastrOptions { Title = "Opps!" });
                return;
            }
            _imageHelper.Delete(aboutMe.FileName!);
            _toasty.AddWarningToastMessage(_message.Delete(aboutMe.Title), new ToastrOptions { Title = "Congratulations" });
        }

        //Listing Method
        public async Task<IEnumerable<AboutMeAdminListVM>> GetAboutMeWithAllChildrenAsync()
        {
            var aboutMe = await _aboutMeRepository.Where(x => x.IsEdited == true).Include(x => x.Fact).Include(x => x.Contact).Include(x => x.SocialMedia).ProjectTo<AboutMeAdminListVM>(_mapper.ConfigurationProvider).ToListAsync();
            return aboutMe;
        }

        //Selecting Method
        public async Task<AboutMeUpdateVM> GetAboutMeWithAllChildrenByIdAsync(int id)
        {
            var aboutMe = await _aboutMeRepository.Where(x => x.Id == id).Include(x => x.Fact).Include(x => x.Contact).Include(x => x.SocialMedia).ProjectTo<AboutMeUpdateVM>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();
            return aboutMe;
        }




        //USER SIDE SERVICES-------------------

        //Listing Method
        public async Task<IEnumerable<AboutMeUserListVM>> GetAboutMeWithAllChildrenForUserAsync()
        {
            var aboutMe = await _aboutMeRepository.Where(x => x.IsPublished == true).Include(x => x.Fact).Include(x => x.Contact).Include(x => x.SocialMedia).ProjectTo<AboutMeUserListVM>(_mapper.ConfigurationProvider).ToListAsync();
            return aboutMe;
        }

        //Listing Method for Contact
        public async Task<IEnumerable<AboutMeForContactVM>> GetContactListForUserAsync()
        {
            var contactList = await _unitOfWork.GetGenericRepository<AboutMe>().Where(x => x.IsPublished).Include(x => x.Contact).ProjectTo<AboutMeForContactVM>(_mapper.ConfigurationProvider).ToListAsync();
            return contactList;
        }

    }
}
