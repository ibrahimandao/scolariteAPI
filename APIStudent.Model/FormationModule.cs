using System.ComponentModel.DataAnnotations;
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

        public DateTime DateDebut   { get; set; }

        public DateTime DateFin { get; set; }
       
        public string CreneauHoraireDebut { get; set; }

        public string CreneauHoraireFin { get; set; }

        public Periodicite Periodicite { get; set; }

        public DayOfWeek JourSemaine { get; set; }

    }

    public enum Periodicite
    {
        Quotidien,
        Hebdomadaire
    }
}
