using APIStudent.Model;

namespace APIStudent.DAO.Interfaces
{
    public interface IProfilRole
    {
        public void Add(ProfilRole profilRole);

        public void Update(int id,ProfilRole profilRole);

        public void Delete(int id);
    }
}
