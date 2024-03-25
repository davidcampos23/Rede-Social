using System.ComponentModel.DataAnnotations;
using backend.Security;

namespace backend.Models;

public class Register{
    
    public Guid Id { get; init; }

    [Required(ErrorMessage = "Campo Vazio")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "Campo Vazio")]
    [EmailAddress(ErrorMessage ="Formato Inadequado")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Campo Vazio")]
    public string Password { get; set; }

    public byte[] Image { get; set; }

    public Register() {}

    public Register(string username, string email, string password, byte[] image)
    {
        Id = Guid.NewGuid();
        UserName = username;
        Email = email;
        Image = image;

        HashAndSalt hashCrypto = new HashAndSalt();
        Password = hashCrypto.EncryptPassword(password);
    }
}