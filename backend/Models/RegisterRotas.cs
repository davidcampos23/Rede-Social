using backend.Data;
using backend.Security;
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

            return Results.Ok(true);
        });

        app.MapPost(pattern:"/api/register/user/login", handler:async(AddLoginRequest request, AppDbContext context)=>{
            if(request.Email == "" || request.Email == null || request.Password == "" || request.Password == null){
                return Results.BadRequest("Um ou mais valores Vazios.");
            }

            var searchUser = await context.registers.FirstOrDefaultAsync(x => x.Email == request.Email);

            if(searchUser == null){
                return Results.BadRequest("Usuario não Encontrado.");
            }

            HashAndSalt hashCrypto = new HashAndSalt();
            var loginEffect = hashCrypto.passwordVerify(request.Password, searchUser.Password);

            var result = new {
                LoginEffect = loginEffect,
                UserId = searchUser.Id
            };

            return Results.Ok(result);
        });

        app.MapPut(pattern:"/api/register/user/put/image", handler:async(AddImageRequestPut request, AppDbContext context)=>{
            if(request.idUser == null || request.imageUser == null){
                return Results.BadRequest("Um ou mais valores null");
            }

            var searchUser = await context.registers.FirstOrDefaultAsync(x => x.Id == request.idUser);

            if(searchUser == null){
                return Results.BadRequest("Usuario não Encontrado.");
            }

            searchUser.Image = request.imageUser;
            await context.SaveChangesAsync();

            return Results.Ok("Imagem Salva");
        });

        app.MapGet(pattern:"/api/register/user/get/image", handler:async(AppDbContext context, Guid userIdGet)=>{
            var searchUser = await context.registers.FirstOrDefaultAsync(x => x.Id == userIdGet);

            if (searchUser != null) {
                return Results.Ok(searchUser.Image);
            } else {
                return Results.NotFound();
            }
        });

    }
}