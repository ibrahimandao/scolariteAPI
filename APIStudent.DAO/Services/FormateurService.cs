using APIStudent.DAO.Data;
using APIStudent.DAO.Interfaces;
using APIStudent.Model;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Serialization;

namespace APIStudent.DAO.Services
{
    public class FormateurService : IFormateurService
    {
        private readonly ScolariteDBContext _context;
        public FormateurService(ScolariteDBContext context) => _context = context;
        public void add(Formateur formateur)
        {
            try
            {
                _context.Formateurs.Add(formateur);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public IEnumerable<Formateur> getAll()
        {
            try
            {
                return _context.Formateurs.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Formateur? getFormateurById(int id)
        {
            try
            {
                return _context.Formateurs.Find(id);
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
                var _forma = _context.Formateurs.Find(id);
                if (_forma != null)
                {
                    _context.Formateurs.Remove(_forma);
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

        public void update(int id, Formateur formateur)
        {
            try
            {
                var _forma = _context.Formateurs.Find(id);
                if(_forma != null)
                {
                    _forma.Email = formateur.Email;
                    _forma.Firstname=formateur.Firstname;
                    _forma.Name = formateur.Name;

                    _context.Entry(_forma).State = EntityState.Modified;
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
    }
}
