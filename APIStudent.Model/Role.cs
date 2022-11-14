using System.ComponentModel.DataAnnotations;

namespace APIStudent.Model
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CodeFonctionnalite { get; set; }

        public bool CanRead { get; set; }
        public bool CanWrite { get; set; }

        public bool CanEdit { get; set; }

        public bool CanDelete { get; set; }
    }
}
