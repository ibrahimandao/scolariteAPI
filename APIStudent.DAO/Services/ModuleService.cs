using APIStudent.DAO.Data;
using APIStudent.DAO.Interfaces;
using APIStudent.Model;
using Microsoft.EntityFrameworkCore;

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
                return _context.Modules.Include("Formateur").AsEnumerable();
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
            try
            {
                var module = _context.Modules.Find(id);

                if(module != null)
                {
                    _context.Modules.Remove(module);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void update(int id, Module module)
        {
            try
            {
                var item = _context.Modules.Find(id);

                if (item != null)
                {
                    item.Descriptif = module.Descriptif;
                    item.FormateurId = module.FormateurId;
                    item.IsOneline = module.IsOneline;
                    _context.Entry(item).State = EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
