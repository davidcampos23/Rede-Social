namespace backend.Models;

public record AddPostsRequest(string token, string username, string text);