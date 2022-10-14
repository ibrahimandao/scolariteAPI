using APIStudent.DAO.Data;
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
        }

        public  Etudiant? Find(string matricule)
        {
           
            Etudiant? etu =  _context.Etudiants.Include("Formation").FirstOrDefault(a => a.Matricule.Equals(matricule)) ;
            
            return etu;           
            
        }

        public void Update(Etudiant etu)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Etudiant> GetList()
        {
            return _context.Etudiants.Include("Formation").ToList();
        }
    }
}