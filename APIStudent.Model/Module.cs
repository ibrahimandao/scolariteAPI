namespace APIStudent.Model
{
    public  class Module
    {
        public int Id { get; set; }
        public string Descriptif { get; set; }

        public Formateur Formateur { get; set; }

        public int? formateurId { get; set; }
    }
}
