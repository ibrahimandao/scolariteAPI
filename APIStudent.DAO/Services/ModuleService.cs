using APIStudent.DAO.Data;
using APIStudent.DAO.Interfaces;
using APIStudent.Model;

namespace APIStudent.DAO.Services
{
    public class ModuleService : IModuleService
    {
        private readonly ScolariteDBContext _context;
        public ModuleService(ScolariteDBContext context) => _context = context;
        public void add(Module module)
        {
            try
            {                
                _context.Modules.Add(module);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Module> getAll()
        {
            try
            {
                return _context.Modules.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Module? getModuleById(int id)
        {
            try
            {
                return _context.Modules.Find(id);
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

        public void update(int id, Module module)
        {
            throw new NotImplementedException();
        }
    }
}
