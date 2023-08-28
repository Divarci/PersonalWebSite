using AutoMapper;
using AutoMapper.QueryableExtensions;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.MessageViewModel;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using RepositoryLayer.Repository.Generic.Abstract;
using RepositoryLayer.UnitOfWorks.Abstract;
using ServiceLayer._SharedFolder.Messages.ToastyNotification;
using ServiceLayer.WebApplication.Services.Abstract;

namespace ServiceLayer.WebApplication.Services.Concrete
{
    public class MessageService : IMessageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Message> _messageRepository;
        private readonly IToastNotification _toasty;
        private readonly IMessageMessages _messages;

        public MessageService(IUnitOfWork unitOfWork, IMapper mapper, IGenericRepository<Message> messageRepository, IToastNotification toasty, IMessageMessages messages)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _messageRepository = messageRepository;
            _toasty = toasty;
            _messages = messages;
        }

        public int NumberGenerator()
        {
            Random randomNumber = new();
            return randomNumber.Next(0, 9);
        }


        //ADMIN SIDE SERVICES-----------------

        //Listing Method
        public async Task<IEnumerable<MessageAdminListVM>> GetMessageListAsync()
        {
            var messages = await _messageRepository.Where(x => x.IsEdited == true).Include(x => x.Resume).OrderBy(x => x.CreatedDate).ProjectTo<MessageAdminListVM>(_mapper.ConfigurationProvider).ToListAsync();
            return messages;
        }
        //Listing for Dashboard
        public async Task<IEnumerable<MessageAdminListForDashboardVM>> GetMessageListForDashboardAsync()
        {
            var messages = await _messageRepository.GetAll().Include(x => x.Resume).Where(x => x.Resume.IsPublished == true).OrderByDescending(x => x.CreatedDate).Take(5).ProjectTo<MessageAdminListForDashboardVM>(_mapper.ConfigurationProvider).ToListAsync();
            return messages;
        }

        //Delete Method
        public async Task DeleteMessageAsync(int id)
        {
            var message = await _messageRepository.GetEntityByIdAsync(id);
            _messageRepository.Delete(message);
            var errorMessage = await _unitOfWork.CommitAsync();
            if (errorMessage != string.Empty)
            {
                _toasty.AddErrorToastMessage(errorMessage, new ToastrOptions { Title = "Opps!" });
                return;
            }
            _toasty.AddWarningToastMessage(_messages.MessageDeleted(), new ToastrOptions { Title = "Congratulations!" });

        }



        //USER SIDE SERVICES-----------------

        //Add Method
        public async Task AddMessageAsync(MessageAddVM request)
        {
            var publishedResume = await _unitOfWork.GetGenericRepository<Resume>().Where(x => x.IsPublished == true).SingleOrDefaultAsync();

            var message = _mapper.Map<Message>(request);
            message.IsEdited = publishedResume.IsEdited;
            message.ResumeId = publishedResume.Id;
            await _messageRepository.AddAsync(message);
            var errorMessage = await _unitOfWork.CommitAsync();
            if (errorMessage != string.Empty)
            {
                _toasty.AddErrorToastMessage(errorMessage, new ToastrOptions { Title = "Opps!" });
                return;
            }
            _toasty.AddSuccessToastMessage(_messages.MessageSent(), new ToastrOptions { Title = "Congratulations!" });

        }

        public string CaptchaGenerator()
        {
            List<string> randomSigns = new() { "*", "/", "+", "!", "%", "£", "$", "^", "&", "=" };
            List<string> captcha = new();
            for (int i = 0; i < 3; i++)
            {
                captcha.Add(NumberGenerator().ToString());
                captcha.Add(randomSigns[NumberGenerator()].ToString());
            }
            string captchaString = captcha[0] + captcha[1] + captcha[2] + captcha[3] + captcha[4] + captcha[5];

            return captchaString;
        }
    }
}
