namespace backend.Models;

public class Register{
    
    public Guid Id { get; init; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public byte[] Image { get; set; }

    public Register() {}

    public Register(string username, string email, string password, byte[] image)
    {
        Id = Guid.NewGuid();
        UserName = username;
        Email = email;
        Password = password;
        Image = image;
    }
}