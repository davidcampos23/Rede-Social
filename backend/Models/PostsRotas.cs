using backend.Data;

namespace backend.Models;

public static class PostsRotas
{
    public static void AddRotasPosts(this WebApplication app)
    {
        //Post
        app.MapPost(pattern: "/posts", handler: async(AddPostsRequest request, AppDbContext context) =>{
            
            var novoPost = new Posts(request.TokenImage, request.UserName, request.Menssage);

            await context.posts.AddAsync(novoPost);
            await context.SaveChangesAsync();
        });

        //Get
        app.MapGet(pattern: "/posts/obter", handler: (AppDbContext context)=>{
            var todosPosts = context.posts;
            return todosPosts;
        });

        //Delete
    }
}