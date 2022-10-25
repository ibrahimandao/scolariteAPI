using APIStudent.DAO.Data;
using APIStudent.DAO.Interfaces;
using APIStudent.Model;
using Microsoft.EntityFrameworkCore;

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


        public void Update(int id, Formation formation)
        {
            var form = _context.Formations.Find(id);
            if(form != null)
            {
                form.Libelle = formation.Libelle;
                form.Niveau = formation.Niveau;

                _context.Entry(form).State = EntityState.Modified;

                _context.SaveChanges();
            }
        }
    }
}
