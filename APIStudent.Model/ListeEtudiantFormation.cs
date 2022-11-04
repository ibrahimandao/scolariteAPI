namespace APIStudent.Model
{
    public class ListeEtudiantFormation
    {
        public string LibelleFormation { get; set; }

        public IEnumerable<Etudiant> Etudiants { get; set; }
    }
}
