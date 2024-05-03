using AutoMapper;
using LoginOrRegisterProject_Asp.Contextes;
using LoginOrRegisterProject_Asp.Models.DBEntities;
using LoginOrRegisterProject_Asp.ViewModels;

namespace LoginOrRegisterProject_Asp.Services;

public class RegisterService
{
    private readonly Login_DB_Context? _context;
    private readonly IMapper? _mapper;

    public RegisterService( IMapper mapper, Login_DB_Context context)
    {
        _context = context;
        _mapper = mapper;   
    }

    public User ConvertTypeToUser(RegisterViewModel model)
    {
       return _mapper!.Map<User>(model);

    }
    public bool CheckPassword(User user)
    {
        if(user.Password == user.ConfirmPassword ) 
            return true;
        return false;
    }

    public void AddUser(User user)
    {
        _context!.Users.Add(user);
        _context!.SaveChanges();
    }

   

   
}
