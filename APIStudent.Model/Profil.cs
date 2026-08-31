using System.ComponentModel.DataAnnotations;

namespace APIStudent.Model
{
    public class Profil
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Libelle { get; set; }

        [Required]
        public string Code { get; set; }
    }

    
}
