using backend.Data;
using Microsoft.EntityFrameworkCore;

namespace backend.Models;

public static class UsersRotas
{
    public static void AddRotasUsers(this WebApplication app)
    {
        app.MapGet(pattern: "/api/users/get/info", handler: async(AppDbContext context) =>{
            
            var usersInfo = await context.registers
            .Select(r => new{r.UserName, r.Image})
            .Take(8)
            .ToListAsync();

            return Results.Ok(usersInfo);
        });

        app.MapPut(pattern:"/api/users/put/image", handler:async(AddImageRequestPut request, AppDbContext context)=>{
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

        app.MapGet(pattern:"/api/users/get/image", handler:async(AppDbContext context, Guid userIdGet)=>{
            var searchUser = await context.registers.FirstOrDefaultAsync(x => x.Id == userIdGet);

            if (searchUser != null) {
                return Results.Ok(searchUser.Image);
            } else {
                return Results.NotFound();
            }
        });
    }
}