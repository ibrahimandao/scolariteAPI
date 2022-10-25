using APIStudent.Model;

namespace APIStudent.DAO.Interfaces
{
    public interface IModuleService
    {
        public void add(Module module);
        public void remove(int id);
        public void update(int id, Module module);

        public IEnumerable<Module> getAll();

        public Module? getModuleById(int id);
    }
}
