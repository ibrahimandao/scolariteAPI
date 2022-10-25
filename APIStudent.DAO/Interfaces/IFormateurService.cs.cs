using APIStudent.Model;

namespace APIStudent.DAO.Interfaces
{
    public interface IFormateurService
    {
        public void add(Formateur formateur);
        public void remove(int id);
        public void update(int id, Formateur formateur);

        public IEnumerable<Formateur> getAll();

        public Formateur? getFormateurById(int id);
    }
}
