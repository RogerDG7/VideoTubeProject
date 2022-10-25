namespace VideoTube.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserActions _userActions;

    public UserController(IUserActions userActions)
    {
        _userActions = userActions;
    }

    /// <summary>
    /// Get all User
    /// </summary>
    /// <returns>Response list model UserModel</returns>
    [HttpGet]
    [Route("[action]")]
    public async Task<Response<List<UserModel>>> GetAllUser()
    {
        Response<List<UserModel>> response = new();
        try
        {
            response = await _userActions.GetUsers();
            return response;
        }
        catch (Exception ex)
        {
            response.Status = false;
            response.Message = MessageExtension.AddMessageList(ex.Message);
            return response;
        }
    }

    /// <summary>
    /// Get User by ID
    /// </summary>
    /// <returns>Response model UserModel</returns>
    [HttpGet]
    [Route("[action]")]
    public async Task<Response<UserModel>> GetByIdUser(Guid id)
    {
        Response<UserModel> response = new();
        try
        {
            response = await _userActions.GetByIdUser(id);
            return response;
        }
        catch (Exception ex)
        {
            response.Status = false;
            response.Message = MessageExtension.AddMessageList(ex.Message);
            return response;
        }
    }

    /// <summary>
    /// create User
    /// </summary>
    /// <returns>Response model UserModel</returns>
    [HttpPost]
    [Route("[action]")]
    public async Task<Response<UserModel>> CreateUser(UserModel userModel)
    {
        Response<UserModel> response = new();
        try
        {
            response = await _userActions.CreateUser(userModel);
            return response;
        }
        catch (Exception ex)
        {
            response.Status = false;
            response.Message = MessageExtension.AddMessageList(ex.Message);
            return response;
        }
    }

}