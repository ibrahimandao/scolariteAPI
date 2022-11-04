using APIStudent.Model;

namespace APIStudent.DAO.Interfaces
{
    public interface IFormationModuleService
    {
        public void add(FormationModuleForAdd formationModule);

        public void remove(int id);

        public ListeModuleFormation getModulesByFormationId(int formationid);

        public IEnumerable<FormationModule> get();

        public FormationModuleForAdd? getById(int id);

        public void update(int id, FormationModuleForAdd formationModule);
    }
}
