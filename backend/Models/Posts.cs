using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Posts
    {
        public Guid Id { get; init; }

        [Required(ErrorMessage = "imagem vazia!")]
        public byte[] Token { get; set; }

        [Required(ErrorMessage = "Nome vazio!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Texto vazio!")]
        public string Text { get; set; }

        public DateTime Date { get; set; }

        public Posts() {}

        public Posts(string token, string username, string text)
        {
            Id = Guid.NewGuid();
            UserName = username;
            Token = System.Convert.FromBase64String(token);
            Text = text;
            Date = DateTime.Now;
        }
    }
}