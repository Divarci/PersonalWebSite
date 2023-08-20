﻿using EntityLayer.WebApplication.ViewModels.MessageViewModel;

namespace ServiceLayer.Services.WebApplication.Abstract
{
    public interface IMessageService
    {
        //ADMIN SIDE SERVICES-----------------

        //Signatures for methods
        Task<IEnumerable<MessageAdminListVM>> GetMessageListAsync();
        Task DeleteMessageAsync(int id);
        Task<IEnumerable<MessageAdminListForDashboardVM>> GetMessageListForDashboardAsync();


        //USER SIDE SERVICES-----------------

        //Signatures for methods
        Task AddMessageAsync(MessageAddVM request);

    }
}
