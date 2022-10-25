using System;
using AutoMapper;
using Bussines.Contract;
using Common.Utilities.ResponseModels;
using Models.User;
using Services.UserServices.Contracts;

namespace Bussines.Implement;

public class UserActions : IUserActions
{
    private readonly IUserServiceRepository _userService;
    private readonly IMapper _mapper;

    public UserActions(IUserServiceRepository userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    public async Task<Response<List<UserModel>>> GetUsers()
    {
        var result = await _userService.GetUsers();
        Response<List<UserModel>> response = new()
        {
            Status = result.Status,
            Message = result.Message,
            ObjectResponse = result.ObjectResponse != null ?
                _mapper.Map<List<UserModel>>(result.ObjectResponse) : null
        };

        return response;
    }

    public async Task<Response<UserModel>> GetByIdUser(Guid id)
    {
        var result = await _userService.GetByIdUser(id);
        Response<UserModel> response = new()
        {
            Status = result.Status,
            Message = result.Message,
            ObjectResponse = result.ObjectResponse != null ?
                _mapper.Map<UserModel>(result.ObjectResponse) : null
        };
        return response;
    }

    public async Task<Response<UserModel>> CreateUser(UserModel user)
    {
        var result = await _userService.CreateUser(user);
        Response<UserModel> response = new()
        {
            Status = result.Status,
            Message = result.Message,
            ObjectResponse = result.ObjectResponse != null ?
                _mapper.Map<UserModel>(result.ObjectResponse) : null
        };
        return response;
    }
}

