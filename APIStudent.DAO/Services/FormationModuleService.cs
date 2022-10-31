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
        public void add(FormationModuleForAdd formationModule)
        {
            try
            {
                if (formationModule != null && formationModule.FormationId > 0 && _context.Formations.Any(i => i.Id.Equals(formationModule.FormationId))
                                           && formationModule.ModuleId > 0 && _context.Modules.Any(i => i.Id.Equals(formationModule.ModuleId)))
                {
                    _context.FormationModules.Add(new FormationModule { ModuleId = formationModule.ModuleId,FormationId = formationModule.FormationId});
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

        public FormationModuleForAdd? getById(int id)
        {
            try
            {
                return (from formMod in _context.FormationModules.Where(item => item.Id.Equals(id))
                       select new FormationModuleForAdd
                       {
                           FormationId = formMod.FormationId,
                           ModuleId = formMod.ModuleId,
                       }).FirstOrDefault();


            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<FormationModule> get()
        {
            try
            {

                return from formMod in _context.FormationModules
                       join mod in _context.Modules.Include("Formateur") on formMod.ModuleId equals mod.Id
                       join form in _context.Formations on formMod.FormationId equals form.Id
                       join format in _context.Formateurs on mod.FormateurId equals format.Id
                       select new FormationModule
                       {
                           FormationId = form.Id,
                           ModuleId = mod.Id,
                           module = mod,
                           formation = form,
                           Id = formMod.Id,
                       };


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

        public void update(int id, FormationModuleForAdd formationModule)
        {
            try
            {
                var element = _context.FormationModules.Find(id);
                if (element != null)
                {
                    if (formationModule != null && formationModule.FormationId > 0 && _context.Formations.Any(i => i.Id.Equals(formationModule.FormationId))
                                       && formationModule.ModuleId > 0 && _context.Modules.Any(i => i.Id.Equals(formationModule.ModuleId)))
                    {                        
                        element.FormationId = formationModule.FormationId;
                        element.ModuleId = formationModule.ModuleId;

                        _context.Entry(element).State = EntityState.Modified;
                        _context.SaveChanges();
                    }
                    else
                        throw new Exception();
                    
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
