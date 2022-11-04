namespace APIStudent.Model
{
    public class ListeModuleFormation
    {
        public string LibelleFormation { get; set; }

        public IEnumerable<Module> Modules { get; set; }
    }
}
