namespace LoginOrRegisterProject_Asp.Models.DBEntities;

public class User
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Password { get; set; }
    public string? ConfirmPassword { get; set; }
    public string? Email { get; set; }
}
