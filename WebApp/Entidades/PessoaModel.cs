using System.ComponentModel.DataAnnotations;

namespace WebApp.Entidades
{
    public class PessoaModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "Sobrenome é obrigatório")]
        public string Sobrenome { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }
    }
}
