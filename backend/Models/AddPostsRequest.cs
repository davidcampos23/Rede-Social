namespace backend.Models;

public record AddPostsRequest(byte[] TokenImage, string UserName, string Menssage);