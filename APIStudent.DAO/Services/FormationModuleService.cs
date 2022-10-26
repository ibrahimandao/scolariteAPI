using APIStudent.DAO.Data;
using APIStudent.DAO.Interfaces;
using APIStudent.Model;
using Microsoft.EntityFrameworkCore;

namespace APIStudent.DAO.Services
{
    public class FormationModuleService : IFormationModuleService
    {

        private readonly ScolariteDBContext _context;
        public FormationModuleService(ScolariteDBContext context) => _context = context;
        public void add(FormationModule formationModule)
        {
            try
            {
                if (formationModule != null && formationModule.FormationId > 0 && _context.Formations.Any(i => i.Id.Equals(formationModule.FormationId))
                                           && formationModule.ModuleId > 0 && _context.Modules.Any(i => i.Id.Equals(formationModule.ModuleId)))
                {
                    _context.FormationModules.Add(formationModule);
                    _context.SaveChanges();
                }
                else
                    throw new Exception();
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Module> getModulesByFormationId(int formationid)
        {
            try
            {
               
                var modules = from a in _context.Modules.Include("Formateur")
                              join b in _context.FormationModules on a.Id equals b.ModuleId
                              where b.FormationId == formationid
                              select a;

                return modules;


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
                var element = _context.FormationModules.Find(id);
                if(element != null)
                {
                    _context.FormationModules.Remove(element);
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
