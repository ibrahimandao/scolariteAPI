using System.ComponentModel.DataAnnotations;

namespace APIStudent.Model
{
    public class Utilisateur
    {
        [Key]
        public int Id { get; set; }

        
        public string Nom { get; set; }

        public string Prenom { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public Profil Profil { get; set; }

        public int ProfilId { get; set; }
    }
}
