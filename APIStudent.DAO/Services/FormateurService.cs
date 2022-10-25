using APIStudent.DAO.Data;
using APIStudent.DAO.Interfaces;
using APIStudent.Model;

namespace APIStudent.DAO.Services
{
    public class FormateurService : IFormateurService
    {
        private readonly ScolariteDBContext _context;
        public FormateurService(ScolariteDBContext context) => _context = context;
        public void add(Formateur formateur)
        {
            try
            {
                _context.Formateurs.Add(formateur);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public IEnumerable<Formateur> getAll()
        {
            try
            {
                return _context.Formateurs.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Formateur? getFormateurById(int id)
        {
            try
            {
                return _context.Formateurs.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void remove(int id)
        {
            throw new NotImplementedException();
        }

        public void update(int id, Formateur formateur)
        {
            throw new NotImplementedException();
        }
    }
}
