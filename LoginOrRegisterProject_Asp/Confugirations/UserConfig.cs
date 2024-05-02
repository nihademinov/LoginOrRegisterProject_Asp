using LoginOrRegisterProject_Asp.Models.DBEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoginOrRegisterProject_Asp.Confugirations;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .Property(x => x.Email)
             .HasMaxLength(50);

        builder
            .Property(x => x.Password)
            .HasMaxLength(50);

        builder
            .Property(x=>x.Name)
            .HasMaxLength(50);
        builder
            .Property(x => x.ConfirmPassword)
            .HasMaxLength(50);
        

       

    }
}
