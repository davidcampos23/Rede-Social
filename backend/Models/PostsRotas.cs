using backend.Data;

namespace backend.Models;

public static class PostsRotas
{
    public static void AddRotasPosts(this WebApplication app)
    {
        //Post
        app.MapPost(pattern: "/posts", handler: async(AddPostsRequest request, AppDbContext context) =>{
            
            var novoPost = new Posts(request.token, request.username, request.text);

            await context.posts.AddAsync(novoPost);
            await context.SaveChangesAsync();
        });

        //Get
        //Delete
    }
}