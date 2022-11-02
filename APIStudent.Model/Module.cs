using System.ComponentModel.DataAnnotations.Schema;

namespace APIStudent.Model
{
    public  class Module
    {
        public int Id { get; set; }
        public string Descriptif { get; set; }

        public Formateur Formateur { get; set; }

        [ForeignKey("Formateur")]
        public int? FormateurId { get; set; }

        public bool IsOneline { get; set; }

    }
}
