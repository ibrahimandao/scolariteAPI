using APIStudent.DAO.Data;
using APIStudent.DAO.Interfaces;
using APIStudent.Model;
using Microsoft.EntityFrameworkCore;

namespace APIStudent.DAO.Services
{
    public class UtilisateurService : IUtilisateur
    {
        private readonly ScolariteDBContext _context;
        public UtilisateurService(ScolariteDBContext context) => _context = context;
        public void AddUtlisateur(Utilisateur utilisateur)
        {
            try
            {
                _context.Utilisateurs.Add(utilisateur);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Utilisateur? GetUtilisateurById(int utilisateurId)
        {
            try
            {
                var user = _context.Utilisateurs.Include("Profil").FirstOrDefault(u => u.Id == utilisateurId);
                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateUtlisateur(int utilisateurId, Utilisateur utilisateur)
        {
            try
            {
                var user = _context.Utilisateurs.Find(utilisateurId);
                if( user != null)
                {
                    user.ProfilId = utilisateur.ProfilId;
                    user.Nom = utilisateur.Nom;
                    user.Prenom = utilisateur.Prenom;
                    user.Password = utilisateur.Password;

                    _context.Entry(user).State = EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Utilisateur? Connexion(string login, string password)
        {
            try
            {
                var user = _context.Utilisateurs.Include("Profil").Where(a=> a.Login.ToUpper() == login.ToUpper() && a.Password == password).FirstOrDefault();
                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<Role> GetRolesByLogin(string login)
        {
            try
            {
                var role = from r in _context.Roles
                           join pr in _context.ProfilRoles on r.Id equals pr.RoleId
                           join p in _context.Profils on pr.ProfilId equals p.Id
                           join u in _context.Utilisateurs on p.Id equals u.ProfilId
                           where u.Login == login
                           select r;
                return role;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
