using APIStudent.Model;

namespace APIStudent.DAO.Interfaces
{
    public interface IStudentService
    {
        public void Add(Etudiant etu);

        public void Update(Etudiant etu);
        public Etudiant? Find(string matricule);
        public IEnumerable<Etudiant> GetList();
    }
}
