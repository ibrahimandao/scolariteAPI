using System.ComponentModel.DataAnnotations;

namespace APIStudent.Model
{
    public class Formateur
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }


        [Required]
        public string Firstname { get; set; }
    }
}
