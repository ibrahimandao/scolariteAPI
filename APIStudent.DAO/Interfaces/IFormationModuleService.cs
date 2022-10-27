using APIStudent.Model;

namespace APIStudent.DAO.Interfaces
{
    public interface IFormationModuleService
    {
        public void add(FormationModuleForAdd formationModule);

        public void remove(int id);

        public IEnumerable<Module> getModulesByFormationId(int formationid);

        public IEnumerable<FormationModule> get();
    }
}
