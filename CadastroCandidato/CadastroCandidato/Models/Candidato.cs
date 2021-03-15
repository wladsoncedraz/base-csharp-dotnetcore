using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroCandidato.Models
{
    [Table("Candidato")]
    public class Candidato
    {
        [Key]
        public int CandidatoID { get; set; }

        [Required]
        public string vchNome { get; set; }

        [Required]
        public string vchEmail { get; set; }

        [Required]
        public string vchCidade { get; set; }

        [Required]
        public string vchEstado { get; set; }
    }
}
