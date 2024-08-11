using System.ComponentModel.DataAnnotations;

namespace AgendaOnline.Models
{
    public class AgendaModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do Usuário!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Digite o nome da Gerência!")]
        public string Gerencia { get; set; }

        [Required(ErrorMessage = "Digite o número do Ramal!")]
        public string Ramal { get; set; }

        [Required(ErrorMessage = "Digite a sigla do Usuário!")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "Digite a Função!")]
        public string Funcao { get; set; }

        [Required(ErrorMessage = "Digite o E-mail!")]
        public string Email { get; set; }
        public DateTime UltimaAtualizacao { get; set; } = DateTime.Now;
    }
}