using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Posts
    {
        public Guid Id { get; init; }

        [Required(ErrorMessage = "Texto vazio!")]
        public string Text { get; set; }

        public DateTime Date { get; set; }

        //public Guid User { get; set; }

        public Posts() {}

        public Posts(string text)
        {
            Id = Guid.NewGuid();
            Text = text;
            Date = DateTime.Now;
        }
    }
}