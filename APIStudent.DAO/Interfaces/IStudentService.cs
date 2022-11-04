using APIStudent.Model;

namespace APIStudent.DAO.Interfaces
{
    public interface IStudentService
    {
        public void Add(Etudiant etu);

        public void Update(int id,Etudiant etudiant);
        public Etudiant? Find(string matricule);

        public Etudiant? FindById(int id);
        public IEnumerable<Etudiant> GetList();

        public ListeEtudiantFormation GetEtudiantByFormationId(int formationId);
    }
}
