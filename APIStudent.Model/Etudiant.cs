﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace APIStudent.Model
{
    public class Etudiant
    {
        
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        public string Phone { get; set; }

        public string Matricule { get; set; }

        public string City { get; set; }

        [Required]
        public string Firstname { get; set; }

        [Required]
        public Formation Formation { get; set; }

        public int? FormationId { get; set; }
    }
}