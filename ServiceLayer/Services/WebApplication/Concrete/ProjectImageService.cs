using AutoMapper;
using AutoMapper.QueryableExtensions;
using EntityLayer.Enums;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.ProjectImageViewModel;
using EntityLayer.WebApplication.ViewModels.ProjectViewModel;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using RepositoryLayer.Repository.Generic.Abstract;
using RepositoryLayer.UnitOfWorks.Abstract;
using ServiceLayer.Helpers.ImagesHelper;
using ServiceLayer.Helpers.ToastyMessages;
using ServiceLayer.Services.WebApplication.Abstract;

namespace ServiceLayer.Services.WebApplication.Concrete
{
    public class ProjectImageService : IProjectImageService
    {
        //dependancy injection
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<ProjectImage> _imageRepository;
        private readonly IImageHelper _imageHelper;
        private readonly IToastNotification _toasty;
        private readonly IGenericMessages _messages;

        public ProjectImageService(IUnitOfWork unitOfWork, IMapper mapper, IImageHelper imageHelper, IToastNotification toasty, IGenericMessages messages)
        {
            _imageRepository = unitOfWork.GetGenericRepository<ProjectImage>();
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _imageHelper = imageHelper;
            _toasty = toasty;
            _messages = messages;
        }

        //ADMIN SIDE SERVICES----------------------

        //Get All Image List With Project
        public async Task<IEnumerable<ProjectImageAdminListVM>> GetAllImageAsync(int id)
        {
            var images = await _imageRepository.Where(x => x.ProjectId == id).Include(x => x.Project).ProjectTo<ProjectImageAdminListVM>(_mapper.ConfigurationProvider).ToListAsync();
            return images;
        }

        //Add Method
        public async Task AddImageAsync(ProjectImageAddVM request)
        {
            //creates new image
            var imageUpload = await _imageHelper.ImageUpload(request.Title, request.Photo, ImageType.Project, null);
            if (imageUpload.Error != null)
            {
                _toasty.AddErrorToastMessage(_messages.ImageError(), new ToastrOptions { Title = "Opps!" });
                return;
            }
            //try to create new aboutme data for db
            request.FileName = imageUpload.FileName!;
            request.FileType = request.Photo.ContentType;

            var image = _mapper.Map<ProjectImage>(request);
            await _imageRepository.AddAsync(image);
            var errorMessage = await _unitOfWork.CommitAsync();
            if (errorMessage != string.Empty)
            {
                //if exception, uploaded image deleted
                _imageHelper.Delete(imageUpload.FileName!);
                _toasty.AddErrorToastMessage(errorMessage, new ToastrOptions { Title = "Opps!" });
                return;
            }
            _toasty.AddSuccessToastMessage(_messages.Add(image.FileName), new ToastrOptions { Title = "Congratulations!" });
        }
        //Select Project for information
        public async Task<ProjectForImageVM> GetProjectByIdAsync(int id)
        {
            var project = await _unitOfWork.GetGenericRepository<Project>().Where(x => x.Id == id).ProjectTo<ProjectForImageVM>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();
            return project;
        }

        //Update Method
        public async Task UpdateImageAsync(ProjectImageUpdateVM request)
        {
            //gets data id
            var imageOld = await _imageRepository.Where(x => x.Id == request.Id).Include(x => x.Project).AsNoTracking().SingleOrDefaultAsync();

            //creates new image
            var imageUpload = await _imageHelper.ImageUpload(imageOld.Project.Title, request.Photo, ImageType.Project, null);
            if (imageUpload.Error != null)
            {
                _toasty.AddErrorToastMessage(_messages.ImageError(), new ToastrOptions { Title = "Opps!" });
                return;
            }
            request.FileName = imageUpload.FileName!;
            request.FileType = request.Photo.ContentType;

            //try to create aboutme data for db
            var image = _mapper.Map<ProjectImage>(request);
            _imageRepository.Update(image);
            var errorMessage = await _unitOfWork.CommitAsync();
            if (errorMessage != string.Empty)
            {
                //if exception, uploaded image deleted
                _imageHelper.Delete(imageUpload.FileName!);
                _toasty.AddErrorToastMessage(errorMessage, new ToastrOptions { Title = "Opps!" });
                return;
            }
            //if succeed existing image will be deleted
            _imageHelper.Delete(imageOld.FileName);
            _toasty.AddInfoToastMessage(_messages.Update(image.FileName), new ToastrOptions { Title = "Congratulations!" });

        }

        //Select Image for information
        public async Task<ProjectImageUpdateVM> GetImageByIdAsync(int id)
        {
            var image = await _imageRepository.Where(x => x.Id == id).ProjectTo<ProjectImageUpdateVM>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();
            var project = await _unitOfWork.GetGenericRepository<Project>().Where(x => x.Id == image.ProjectId).ProjectTo<ProjectForImageVM>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();
            image.Title = project.Title;
            return image;
        }

        //Delete Method
        public async Task<int> DeleteImage(int id)
        {
            var image = await _imageRepository.GetEntityByIdAsync(id);
            _imageRepository.Delete(image);
            var errorMessage = await _unitOfWork.CommitAsync();
            if (errorMessage != string.Empty)
            {
                _toasty.AddErrorToastMessage(errorMessage, new ToastrOptions { Title = "Opps!" });
                return image.ProjectId; ;
            }
            _imageHelper.Delete(image.FileName);
            _toasty.AddWarningToastMessage(_messages.Delete(image.FileName), new ToastrOptions { Title = "Congratulations!" });
            return image.ProjectId;

        }
    }

}
