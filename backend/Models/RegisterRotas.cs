using backend.Data;
using System.Drawing;   

namespace backend.Models;

public static class RegisterRotas{
    public static void AddRotasRegister(this WebApplication app)
    {
        app.MapPost(pattern: "/api/register/user/create", handler:async(AddRegisterRequest request, AppDbContext context)=>{
           
            var newRegister = new Register(request.UserName, request.Email, request.Password, request.Image);
            
            await context.registers.AddAsync(newRegister);
            await context.SaveChangesAsync();
        });

        app.MapGet(pattern: "/api/register/user/login", handler:()=>{});
        
    }
}