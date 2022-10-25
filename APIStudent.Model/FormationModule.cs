using System.ComponentModel.DataAnnotations.Schema;

namespace APIStudent.Model
{
    public class FormationModule
    {
        public int Id { get; set; }

        [ForeignKey("Formateurs")]
        public int FormateurId { get; set; }

        [ForeignKey("Formations")]
        public int FormationId { get; set; }
    }
}
