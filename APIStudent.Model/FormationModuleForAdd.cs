namespace APIStudent.Model
{
    public class FormationModuleForAdd
    {
        public int ModuleId { get; set; }
        public int FormationId { get; set; }

        public DateTime DateDebut { get; set; }

        public DateTime DateFin { get; set; }

        public string CreneauHoraireDebut { get; set; }

        public string CreneauHoraireFin { get; set; }

        public Periodicite Periodicite { get; set; }

        public DayOfWeek JourSemaine { get; set; }


    }
}
