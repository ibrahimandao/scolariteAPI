using System.ComponentModel.DataAnnotations.Schema;

namespace APIStudent.Model
{
    public class FormationModule
    {
        public int Id { get; set; }

        [ForeignKey("Modules")]
        public int ModuleId { get; set; }

        [ForeignKey("Formations")]
        public int FormationId { get; set; }

        public Module module { get; set; }

        public Formation formation { get; set; }
    }
}
