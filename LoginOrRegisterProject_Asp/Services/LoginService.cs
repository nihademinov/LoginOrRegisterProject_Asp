using AutoMapper;
using LoginOrRegisterProject_Asp.Contextes;
using LoginOrRegisterProject_Asp.Models.DBEntities;
using LoginOrRegisterProject_Asp.ViewModels;

namespace LoginOrRegisterProject_Asp.Services;

public class LoginService
{
    private readonly Login_DB_Context? _context;
    private readonly IMapper? _mapper;

    public LoginService(IMapper mapper, Login_DB_Context context)
    {
        _context = context;
        _mapper = mapper;
    }

    public User ConvertTypeToUser(LoginViewModel model)
    {
        return _mapper!.Map<User>(model);

    }

    public bool CheckUser(User user)
    {
        var allUsers = _context!.Users!.ToList();
        if (_context!.Users != null && user != null)
        {
            foreach(var us in allUsers) 
            {
                if(us.Email == user.Email && us.Password == user.Password) 
                    return true;
            }
        }

        return false;
    }

}
