using FluentValidation;
using LoginOrRegisterProject_Asp.Models.DBEntities;
using LoginOrRegisterProject_Asp.ViewModels;

namespace LoginOrRegisterProject_Asp.Validators.FluentValidators;

public class UserRegisterValidator : AbstractValidator<RegisterViewModel>
{
    public UserRegisterValidator()
    {
        RuleFor(u => u.Name).NotEmpty().WithMessage("Name is required.");
        RuleFor(u => u.Email).NotEmpty().WithMessage("Email is required.")
                             .EmailAddress().WithMessage("Invalid email address.");
        RuleFor(u => u.Password).NotEmpty().WithMessage("Password is required.")
                                 .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
                                 .Must(ContainUpperCase).WithMessage("Password must contain at least one uppercase letter.")
                                 .Must(ContainLowerCase).WithMessage("Password must contain at least one lowercase letter.")
                                 .Must(ContainDigit).WithMessage("Password must contain at least one digit.")
                                 .Must(ContainSpecialCharacter).WithMessage("Password must contain at least one special character.");
        RuleFor(u => u.ConfirmPassword).Equal(u => u.Password).WithMessage("Passwords do not match.");
    }

    private bool ContainUpperCase(string password)
    {
        if(password!=null)
            return password.Any(char.IsUpper);
        return false;
    }

    private bool ContainLowerCase(string password)
    {
        if(password!= null)
            return password.Any(char.IsLower);
        return false;
    }

    private bool ContainDigit(string password)
    {
        if(password!= null)
            return password.Any(char.IsDigit);
        return false;
    }

    private bool ContainSpecialCharacter(string password)
    {
        if(password!= null)
        {
            string specialCharacters = @"!@#$%^&*()-_+=[]{}|;:',.<>?";
            return password.Any(specialCharacters.Contains);
        }
        return false;
       
    }
}



