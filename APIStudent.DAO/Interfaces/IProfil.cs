using APIStudent.Model;

namespace APIStudent.DAO.Interfaces
{
    public interface IProfil
    {
        public IEnumerable<Profil> GetProfils();

        public Profil? GetProfilsById(int profilId);

        public void AddProfil(Profil profil);

        public void UpdateProfil(int profilId,Profil profil);
    }
}
