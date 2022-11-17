using System.ComponentModel.DataAnnotations;

namespace APIStudent.Model
{
    public class ProfilRole
    {
        [Key]
        public int Id { get; set; }

        public Role Role { get; set; }

        public int RoleId { get; set; }

        public Profil Profil { get; set; }

        public int ProfilId { get; set; }
    }

    public class ProfilRoleLite
    {      
        public int RoleId { get; set; }

        public int ProfilId { get; set; }
    }
}