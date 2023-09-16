using AutoMapper;
using AutoMapper.QueryableExtensions;
using CoreLayer.Enums;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.NewsFeedVM;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using RepositoryLayer.Repository.Generic.Abstract;
using RepositoryLayer.UnitOfWorks.Abstract;
using ServiceLayer._SharedFolder.Helpers.ImageHelper;
using ServiceLayer._SharedFolder.Messages.ToastyNotification;
using ServiceLayer.WebApplication.Services.Abstract;

namespace ServiceLayer.WebApplication.Services.Concrete
{
    public class NewsFeedService : INewsFeedService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<NewsFeed> _newsFeedRepository;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toasty;
        private readonly IMessageMessages _messages;
        private readonly IImageHelper _imageHelper;

        public NewsFeedService(IUnitOfWork unitOfWork, IMapper mapper, IToastNotification toasty, IMessageMessages messages, IImageHelper imageHelper)
        {
            _newsFeedRepository = unitOfWork.GetGenericRepository<NewsFeed>();
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _toasty = toasty;
            _messages = messages;
            _imageHelper = imageHelper;
        }


        //ADMIN SIDE SERVICES-------------------

        //List method
        public async Task<List<NewsFeedAdminListVM>> GetNewsListForAdminAsync()
        {
            var newsList = await _newsFeedRepository.GetAll().ProjectTo<NewsFeedAdminListVM>(_mapper.ConfigurationProvider).ToListAsync();
            return newsList;
        }

        //Add method
        public async Task AddNewsFeed(NewsFeedAddVM request)
        {
            //creates new image
            var imageUpload = await _imageHelper.ImageUpload(request.Title, request.Photo, ImageType.NewsImage, null);
            if (imageUpload.Error != null)
            {
                _toasty.AddErrorToastMessage(_messages.ImageError(), new ToastrOptions { Title = "Opps!" });
                return;
            }
            request.FileName = imageUpload.FileName!;
            request.FileType = request.Photo.ContentType;

            await _newsFeedRepository.AddAsync(_mapper.Map<NewsFeed>(request));
            var errorMessage = await _unitOfWork.CommitAsync();
            if (errorMessage != string.Empty)
            {
                _imageHelper.Delete(imageUpload.FileName!);
                _toasty.AddErrorToastMessage(errorMessage, new ToastrOptions { Title = "Opps!" });
                return;
            }
            _toasty.AddSuccessToastMessage(_messages.Add(request.Title), new ToastrOptions { Title = "Congratulations!" });
        }

        //Update method
        public async Task UpdateNewsFeed(NewsFeedUpdateVM request)
        {
            var oldNewsFeed = await _newsFeedRepository.Where(x => x.Id == request.Id).AsNoTracking().SingleOrDefaultAsync();

            //checks is there any photo update
            if (request.Photo != null)
            {
                //creates new image
                var imageUpload = await _imageHelper.ImageUpload(request.Title, request.Photo, ImageType.NewsImage, null);
                if (imageUpload.Error != null)
                {
                    _toasty.AddErrorToastMessage(_messages.ImageError(), new ToastrOptions { Title = "Opps!" });
                    return;
                }
                request.FileName = imageUpload.FileName!;
                request.FileType = request.Photo.ContentType;
            }

            _newsFeedRepository.Update(_mapper.Map<NewsFeed>(request));
            var errorMessage = await _unitOfWork.CommitAsync();
            if (errorMessage != string.Empty)
            {
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
                _imageHelper.Delete(oldNewsFeed!.FileName!);
            }
            _toasty.AddInfoToastMessage(_messages.Update(request.Title), new ToastrOptions { Title = "Congratulations!" });
        }

        //Delete Method
        public async Task DeleteNewsFeedById(int id)
        {
            var news = await _newsFeedRepository.GetEntityByIdAsync(id);
            _newsFeedRepository.Delete(news);
            var errorMessage = await _unitOfWork.CommitAsync();
            if (errorMessage != string.Empty)
            {
                _toasty.AddErrorToastMessage(errorMessage, new ToastrOptions { Title = "Opps!" });
                return;
            }
            _imageHelper.Delete(news.FileName!);
            _toasty.AddWarningToastMessage(_messages.Delete(news.Title), new ToastrOptions { Title = "Congratulations!" });
        }

        //Select Method
        public async Task<NewsFeedUpdateVM> GetNewsByIdAsync(int id)
        {
            var news = await _newsFeedRepository.Where(x => x.Id == id).ProjectTo<NewsFeedUpdateVM>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();
            return news;
        }



        //USER SIDE SERVICES-------------------

        //List method (queryable)
        public async Task<List<NewsFeedUserListVM>> GetLastFiveNewsListForUserAsync()
        {
            var newsList = await _newsFeedRepository.GetAll().ProjectTo<NewsFeedUserListVM>(_mapper.ConfigurationProvider).ToListAsync();
            if (newsList.Count != 0)
            {
                var orderedList = newsList.OrderByDescending(x => x.CreatedDate).Take(5).ToList();
                return orderedList;
            }
            return newsList!;
        }      

    }
}
