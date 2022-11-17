using APIStudent.DAO.Data;
using APIStudent.DAO.Interfaces;
using APIStudent.Model;
using Microsoft.EntityFrameworkCore;

namespace APIStudent.DAO.Services
{
    public class ProfilService : IProfil
    {
        private readonly ScolariteDBContext _context;
        public ProfilService(ScolariteDBContext context) => _context = context;
        public void AddProfil(Profil profil)
        {
            try
            {
                _context.Profils.Add(profil);
                _context.SaveChanges();
            }
            catch(Exception)
            {
                throw ;
            }
        }
       
        public IEnumerable<Profil> GetProfils()
        {
            try
            {
                var profils = _context.Profils.AsEnumerable();
                return profils;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Profil? GetProfilsById(int profilId)
        {
            try
            {
                var profil = _context.Profils.Find(profilId);
               
                return profil;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateProfil(int profilId, Profil profil)
        {
            try
            {
                var profilTmp = _context.Profils.Find(profilId);
                if(profilTmp != null)
                {
                    profilTmp.Libelle = profil.Libelle;
                    profilTmp.Code = profil.Code;

                    _context.Entry(profilTmp).State = EntityState.Modified;
                    _context.SaveChanges();
                }
               
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
