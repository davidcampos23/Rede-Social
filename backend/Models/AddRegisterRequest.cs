namespace backend.Models;

public record AddRegisterRequest(string UserName, string Email, string Password, byte[] Image);