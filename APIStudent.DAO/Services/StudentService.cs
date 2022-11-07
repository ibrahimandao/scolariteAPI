﻿using APIStudent.DAO.Data;
using APIStudent.DAO.Interfaces;
using APIStudent.Model;
using Microsoft.EntityFrameworkCore;

namespace APIStudent.DAO.Services
{
    public class StudentService : IStudentService
    {
        private readonly ScolariteDBContext _context;
        public StudentService(ScolariteDBContext context) => _context = context;
        public  void Add(Etudiant etu)
        {           
            _context.Etudiants.Add(etu);
            _context.SaveChanges();
            string matricule = "MIT" + etu.Id.ToString().PadLeft(6, '0');

            etu.Matricule = matricule;

            _context.Entry(etu).State= EntityState.Modified;

            _context.SaveChanges();
        }

        public  Etudiant? Find(string matricule)
        {
           
            Etudiant? etu =  _context.Etudiants.Include("Formation").FirstOrDefault(a => a.Matricule.Equals(matricule)) ;
            
            return etu;           
            
        }

        public void Update(int id,Etudiant etudiant)
        {
            var etu = _context.Etudiants.Find(id);
            if(etu != null)
            {
                etu.Name = etudiant.Name;
                etu.Firstname = etudiant.Firstname;
                etu.Phone = etudiant.Phone;
                etu.City = etudiant.City;
                etu.Email = etudiant.Email;
                etu.Matricule =  "MIT" + etu.Id.ToString().PadLeft(6, '0'); 
                etu.FormationId = etudiant.FormationId;

                _context.Entry(etu).State = EntityState.Modified;

                _context.SaveChanges();

            }
             
        }

        public IEnumerable<Etudiant> GetList()
        {
            return _context.Etudiants.Include("Formation").ToList();
        }

        public ListeEtudiantFormation GetEtudiantByFormationId(int formationId)
        {
            var etudiants = _context.Etudiants.Include("Formation").Where(c => c.FormationId == formationId);

            return new ListeEtudiantFormation
            {
                Etudiants = etudiants,
                LibelleFormation = etudiants.First().Formation.Libelle
            };
        }

        public Etudiant? FindById(int id)
        {
            return _context.Etudiants.Find(id);
        }
    }
}