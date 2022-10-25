using System;
using Common.Utilities.ResponseModels;
using Models.User;

namespace Bussines.Contract
{
    public interface IUserActions
    {
        Task<Response<List<UserModel>>> GetUsers();
        Task<Response<UserModel>> GetByIdUser(Guid id);
        Task<Response<UserModel>> CreateUser(UserModel user);
    }
}
