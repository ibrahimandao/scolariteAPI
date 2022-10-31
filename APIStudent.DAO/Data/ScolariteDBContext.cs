﻿using APIStudent.Model;
using Microsoft.EntityFrameworkCore;

namespace APIStudent.DAO.Data
{
    public  class ScolariteDBContext : DbContext
    {
        public ScolariteDBContext() : base()
        {

        }
        public ScolariteDBContext(DbContextOptions<ScolariteDBContext> options) :   base(options)
        {

        }
        public DbSet<Etudiant> Etudiants { get; set; }

        public DbSet<Formation> Formations { get; set; }

        public DbSet<Formateur> Formateurs { get; set; }

        public DbSet<Module> Modules { get; set; }

        public DbSet<FormationModule> FormationModules { get; set; }
    }
}
