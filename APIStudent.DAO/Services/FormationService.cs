using APIStudent.DAO.Data;
using APIStudent.DAO.Interfaces;
using APIStudent.Model;

namespace APIStudent.DAO.Services
{
    public class FormationService : IFormationService
    {
        private readonly ScolariteDBContext _context;
        public FormationService(ScolariteDBContext context) => _context = context;

        public int Add(Formation formation)
        {
            _context.Add(formation);
            return _context.SaveChanges();
        }

        public Formation? GetFormationById(int id)
        {
            return _context.Formations.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Formation> GetFormations()
        {
            return _context.Formations.ToList();
        }

        public int Delete(int formationId)
        {
            var formation = GetFormationById(formationId);
            if(formation != null)
            {
                _context.Remove(formation);
                return _context.SaveChanges();
            }

            return -1;
        }
    }
}
