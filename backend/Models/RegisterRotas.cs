using backend.Data;
using System.Drawing;
using Microsoft.EntityFrameworkCore;

namespace backend.Models;

public static class RegisterRotas{
    public static void AddRotasRegister(this WebApplication app)
    {
        app.MapPost(pattern: "/api/register/user/create", handler:async(AddRegisterRequest request, AppDbContext context)=>{
           
            var existingUser = await context.registers.FirstOrDefaultAsync(x => x.Email == request.Email); 
            
            if (existingUser != null)
            {
                return Results.BadRequest("O Email já está em uso.");
            }

            var newRegister = new Register(request.UserName, request.Email, request.Password, request.Image);
            
            await context.registers.AddAsync(newRegister);
            await context.SaveChangesAsync();

            return Results.Ok("Conta Criada.");
        });
        
    }
}