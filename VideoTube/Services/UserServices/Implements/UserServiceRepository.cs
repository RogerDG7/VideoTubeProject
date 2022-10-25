using Models.User;
using Services.UserServices.Contracts;

namespace Services.UserServices.Implements;

public class UserServiceRepository : IUserServiceRepository
{
    private readonly VideoTubeContext _context;


    public UserServiceRepository(VideoTubeContext context)
    {
        _context = context;
    }

    public async Task<Response<Object>> GetUsers()
    {
        Response<Object> response = new();
        try
        {
            List<User> lstUsers = await _context.Users.OrderBy(o => o.Name).ToListAsync();

            response = new()
            {
                Message = MessageExtension.AddMessageList("Consulta Exitosa"),
                ObjectResponse = lstUsers,
                Status = true
            };

            return await Task.FromResult(response);
        }
        catch (Exception ex)
        {
            response.Status = false;
            response.ObjectResponse = null;
            response.Message = MessageExtension.AddMessageList(ex.Message);
            return response;
        }
    }

    public async Task<Response<object>> GetByIdUser(Guid id)
    {
        Response<Object> response = new();
        try
        {
            User? user = await _context.Users.Where(x => x.Id == id)
                                            .FirstOrDefaultAsync();

            if (user == null)
                throw new Exception("El usuario no existe o no es valido");

            response = new()
            {
                Message = MessageExtension.AddMessageList("Consulta Exitosa"),
                ObjectResponse = user,
                Status = true
            };

            return await Task.FromResult(response);
        }
        catch (Exception ex)
        {
            response.Status = false;
            response.ObjectResponse = null;
            response.Message = MessageExtension.AddMessageList(ex.Message);
            return response;
        }
    }

    public async Task<Response<object>> CreateUser(UserModel userModel)
    {
        Response<Object> response = new();
        try
        {
            User user = new()
            {
                Id = Guid.NewGuid(),
                Name = userModel.Name,
                UrlPicture = userModel.UrlPicture
            };
            _context.Add(user);
            _context.SaveChanges();
            response = new()
            {
                Message = MessageExtension.AddMessageList("Datos insertados correctamente"),
                ObjectResponse = user,
                Status = true
            };
            
            return await Task.FromResult(response);
        }
        catch (Exception ex)
        {
            response.Status = false;
            response.ObjectResponse = null;
            response.Message = MessageExtension.AddMessageList(ex.Message);
            return response;
        }
    }
}

