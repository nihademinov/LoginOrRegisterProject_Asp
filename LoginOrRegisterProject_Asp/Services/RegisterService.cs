using LoginOrRegisterProject_Asp.Contextes;
using LoginOrRegisterProject_Asp.Models.DBEntities;

namespace LoginOrRegisterProject_Asp.Services;

public class RegisterService
{
    private readonly Login_DB_Context? _context;

    public bool CheckPassword(User user)
    {
        if(user.Password == user.ConfirmPassword ) 
            return true;
        return false;
    }


   

   
}
