using APIStudent.DAO.Data;
using APIStudent.DAO.Interfaces;
using APIStudent.Model;
using Microsoft.EntityFrameworkCore;

namespace APIStudent.DAO.Services
{
    public class ProfilRoleService : IProfilRole
    {
        private readonly ScolariteDBContext _context;
        public ProfilRoleService(ScolariteDBContext context) => _context = context;
        public void Add(ProfilRoleLite profilRole)
        {
            try
            {
                if (_context.Profils.Any(a => a.Id == profilRole.ProfilId) && _context.Roles.Any(a => a.Id == profilRole.RoleId))
                {
                    var item = new ProfilRole();
                    item.ProfilId = profilRole.ProfilId;
                    item.RoleId = profilRole.RoleId;
                    _context.ProfilRoles.Add(item);
                    _context.SaveChanges();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                var item = _context.ProfilRoles.Find(id);
                if (item != null)
                {
                    _context.ProfilRoles.Remove(item);
                    _context.SaveChanges();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(int id, ProfilRoleLite profilRole)
        {
            try
            {
                var item = _context.ProfilRoles.Find(id);
                if (item != null)
                {
                    item.ProfilId = profilRole.ProfilId;
                    item.RoleId = profilRole.RoleId;
                    _context.Entry(item).State = EntityState.Modified;
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
