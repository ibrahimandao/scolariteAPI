using System.ComponentModel.DataAnnotations;

namespace APIStudent.Model
{
    public class Formation
    {
        [Key]
        public int Id { get; set; }

        
        public string Libelle { get; set; }

        
        public int Niveau { get; set; }

        public List<Module> Modules { get; set; }
    }
}
