using LoginOrRegisterProject_Asp.Confugirations;
using LoginOrRegisterProject_Asp.Models.DBEntities;
using Microsoft.EntityFrameworkCore;
using System;

namespace LoginOrRegisterProject_Asp.Contextes;

public class Login_DB_Context:DbContext
{

    public Login_DB_Context(DbContextOptions<Login_DB_Context> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.ApplyConfiguration(new UserConfig());


        base.OnModelCreating(modelBuilder);
    }


    public DbSet<User> Users { get; set; }
}
