using APIStudent.Model;

namespace APIStudent.DAO.Interfaces
{
    public interface IStudentService
    {
        public void Add(Etudiant etu);

        public void Update(int id,Etudiant etudiant);
        public Etudiant? Find(string matricule);
        public IEnumerable<Etudiant> GetList();
    }
}
