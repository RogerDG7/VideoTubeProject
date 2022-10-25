using System;
using Common.Utilities.ResponseModels;
using Entities.Entities;
using Models.User;

namespace Services.UserServices.Contracts
{
    public interface IUserServiceRepository
    {
        Task<Response<object>> GetUsers();
        Task<Response<object>> GetByIdUser(Guid id);
        Task<Response<object>> CreateUser(UserModel userModel);
    }
}

