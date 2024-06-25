using backend.Data;
using Microsoft.EntityFrameworkCore;

namespace backend.Models;

public static class PostsRotas
{
    public static void AddRotasPosts(this WebApplication app)
    {
        //Post
        app.MapPost(pattern: "/api/feed/post", handler: async(AddPostsRequest request, AppDbContext context) =>{
            
            var novoPost = new Posts(request.Menssage, request.userId);

            await context.posts.AddAsync(novoPost);
            await context.SaveChangesAsync();
        });

        //Get
        app.MapGet(pattern: "/api/feed/get", handler: async(AppDbContext context)=>{
            
            var postsWithUserInfo = await context.posts.Join(
                context.registers,
                post => post.User,
                user => user.Id,
                (post, user) => new {post.Id, post.Date, post.Text, user.UserName, user.Image } 
            ).ToListAsync();
            
            if (postsWithUserInfo == null)
            {
                return Results.NotFound();
            }
            
            return Results.Ok(postsWithUserInfo);
        });
    }
}