using APIStudent.DAO.Data;
using APIStudent.DAO.Interfaces;
using APIStudent.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace APIStudent.DAO.Services
{
    public class FormationModuleService : IFormationModuleService
    {

        private readonly ScolariteDBContext _context;
        public FormationModuleService(ScolariteDBContext context) => _context = context;
        public void add(FormationModuleForAdd formationModule)
        {
            try
            {
                if (formationModule != null && formationModule.FormationId > 0 && _context.Formations.Any(i => i.Id.Equals(formationModule.FormationId))
                                           && formationModule.ModuleId > 0 && _context.Modules.Any(i => i.Id.Equals(formationModule.ModuleId)))
                {
                    _context.FormationModules.Add(new FormationModule 
                    {   
                        ModuleId = formationModule.ModuleId,
                        FormationId = formationModule.FormationId,
                        DateDebut = formationModule.DateDebut,
                        DateFin = formationModule.DateFin,
                        CreneauHoraireDebut = formationModule.CreneauHoraireDebut,
                        CreneauHoraireFin = formationModule.CreneauHoraireFin,
                        Periodicite = (Periodicite)formationModule.Periodicite,
                        JourSemaine = (DayOfWeek)formationModule.JourSemaine
                    });
                    _context.SaveChanges();
                }
                else
                    throw new Exception();
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        public FormationModuleForAdd? getById(int id)
        {
            try
            {
                return (from formMod in _context.FormationModules.Where(item => item.Id.Equals(id))
                       select new FormationModuleForAdd
                       {
                           FormationId = formMod.FormationId,
                           ModuleId = formMod.ModuleId,
                           DateDebut = formMod.DateDebut,
                           DateFin = formMod.DateFin,
                           CreneauHoraireDebut = formMod.CreneauHoraireDebut,
                           CreneauHoraireFin = formMod.CreneauHoraireFin,
                           Periodicite = (int)formMod.Periodicite,
                           JourSemaine = (int)formMod.JourSemaine
                       }).FirstOrDefault();


            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<FormationModule> get()
        {
            try
            {

                return from formMod in _context.FormationModules
                       join mod in _context.Modules.Include("Formateur") on formMod.ModuleId equals mod.Id
                       join form in _context.Formations on formMod.FormationId equals form.Id
                       join format in _context.Formateurs on mod.FormateurId equals format.Id
                       select new FormationModule
                       {
                           FormationId = form.Id,
                           ModuleId = mod.Id,
                           module = mod,
                           formation = form,
                           Id = formMod.Id,
                           DateDebut = formMod.DateDebut,
                           DateFin = formMod.DateFin,
                           CreneauHoraireDebut = formMod.CreneauHoraireDebut,
                           CreneauHoraireFin = formMod.CreneauHoraireFin,
                           Periodicite   = formMod.Periodicite,
                           JourSemaine = formMod.JourSemaine,
                       };


            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<FormationModule> getByDate(DateTime? dateDebut, DateTime? dateFin)
        {
            try
            {

                return from formMod in _context.FormationModules
                       join mod in _context.Modules.Include("Formateur") on formMod.ModuleId equals mod.Id
                       join form in _context.Formations on formMod.FormationId equals form.Id
                       join format in _context.Formateurs on mod.FormateurId equals format.Id
                       where (!dateDebut.HasValue || (formMod.DateDebut >= dateDebut && dateDebut.HasValue)) &&
                             (!dateFin.HasValue || (formMod.DateDebut >= dateFin && dateFin.HasValue))
                       select new FormationModule
                       {
                           FormationId = form.Id,
                           ModuleId = mod.Id,
                           module = mod,
                           formation = form,
                           Id = formMod.Id,
                           DateDebut = formMod.DateDebut,
                           DateFin = formMod.DateFin,
                           CreneauHoraireDebut = formMod.CreneauHoraireDebut,
                           CreneauHoraireFin = formMod.CreneauHoraireFin,
                           Periodicite = formMod.Periodicite,
                           JourSemaine = formMod.JourSemaine,
                       };


            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<FormationModule> getPlanningDelaSemaine()
        {
            try
            {

                return from formMod in _context.FormationModules
                       join mod in _context.Modules.Include("Formateur") on formMod.ModuleId equals mod.Id
                       join form in _context.Formations on formMod.FormationId equals form.Id
                       join format in _context.Formateurs on mod.FormateurId equals format.Id
                       where formMod.DateDebut <= DateTime.Now && formMod.DateFin >= DateTime.Now && formMod.Periodicite == Periodicite.Hebdomadaire
                       select new FormationModule
                       {
                           FormationId = form.Id,
                           ModuleId = mod.Id,
                           module = mod,
                           formation = form,
                           Id = formMod.Id,
                           DateDebut = formMod.DateDebut,
                           DateFin = formMod.DateFin,
                           CreneauHoraireDebut = formMod.CreneauHoraireDebut,
                           CreneauHoraireFin = formMod.CreneauHoraireFin,
                           Periodicite = formMod.Periodicite,
                           JourSemaine = formMod.JourSemaine,
                       };


            }
            catch (Exception)
            {
                throw;
            }
        }

        public ListeModuleFormation getModulesByFormationId(int formationid)
        {
            try
            {

                var modules = from a in _context.Modules.Include("Formateur")
                              join b in _context.FormationModules on a.Id equals b.ModuleId
                              join c in _context.Formations on b.FormationId equals c.Id
                              where b.FormationId == formationid
                              select a;

                var formation = _context.Formations.Find(formationid);
                var libelle = formation == null ? string.Empty : formation.Libelle;

                return     new ListeModuleFormation 
                              { 
                                  LibelleFormation = libelle,
                                  Modules = modules
                              };

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void remove(int id)
        {
            try
            {
                var element = _context.FormationModules.Find(id);
                if(element != null)
                {
                    _context.FormationModules.Remove(element);
                    _context.SaveChanges();
                }
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void update(int id, FormationModuleForAdd formationModule)
        {
            try
            {
                var element = _context.FormationModules.Find(id);
                if (element != null)
                {
                    if (formationModule != null && formationModule.FormationId > 0 && _context.Formations.Any(i => i.Id.Equals(formationModule.FormationId))
                                       && formationModule.ModuleId > 0 && _context.Modules.Any(i => i.Id.Equals(formationModule.ModuleId)))
                    {                        
                        element.FormationId = formationModule.FormationId;
                        element.ModuleId = formationModule.ModuleId;
                        element.DateDebut = formationModule.DateDebut;
                        element.DateFin = formationModule.DateFin;
                        element.CreneauHoraireDebut = formationModule.CreneauHoraireDebut;
                        element.CreneauHoraireFin = formationModule.CreneauHoraireFin;
                        element.Periodicite = (Periodicite)formationModule.Periodicite;
                        element.JourSemaine = (DayOfWeek)formationModule.JourSemaine;

                        _context.Entry(element).State = EntityState.Modified;
                        _context.SaveChanges();
                    }
                    else
                        throw new Exception();
                    
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
