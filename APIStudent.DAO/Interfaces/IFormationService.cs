using APIStudent.Model;

namespace APIStudent.DAO.Interfaces
{
    public interface IFormationService
    {
        public int Add(Formation formation);

        public Formation? GetFormationById(int id);

        public IEnumerable<Formation> GetFormations();

        public int Delete(int formationId);

        public void Update(int id, Formation formation);
    }
}
