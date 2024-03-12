using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Posts
    {
        public Guid IdMessage { get; set; }

        [Required(ErrorMessage = "imagem vazia!")]
        public string Token { get; set; }

        [Required(ErrorMessage = "Nome vazio!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Texto vazio!")]
        public string Text { get; set; }

        public DateTime Date { get; set; }

        public Posts(string token, string username, string text)
        {
            IdMessage = Guid.NewGuid();
            UserName = username;
            Token = token;
            Text = text;
            Date = DateTime.Now;
        }
    }
}