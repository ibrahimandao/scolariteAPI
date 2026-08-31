using APIStudent.Model;

namespace APIStudent.DAO.Interfaces
{
    public interface IProfilRole
    {
        public void Add(ProfilRoleLite profilRole);

        public void Update(int id, ProfilRoleLite profilRole);

        public void Delete(int id);
    }
}
