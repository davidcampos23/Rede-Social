using backend.Data;

namespace backend.Models;

public static class PostsRotas
{
    public static void AddRotasPosts(this WebApplication app)
    {
        //Post
        app.MapPost(pattern: "/api/feed/post", handler: async(AddPostsRequest request, AppDbContext context) =>{
            
            var novoPost = new Posts(request.Menssage, request.userId);

            //await context.posts.AddAsync(novoPost);
            await context.SaveChangesAsync();
        });

        //Get
        app.MapGet(pattern: "/api/feed/get", handler: (AppDbContext context)=>{
            //var todosPosts = context.posts;
            //return todosPosts;
        });

        //Delete
    }
}