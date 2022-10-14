using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace APIStudent.Model
{
    public class Formation
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }

        [Required]
        public string Libelle { get; set; }

        [Required]
        public int Niveau { get; set; }
    }
}
