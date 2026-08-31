using APIStudent.DAO.Data;
using APIStudent.DAO.Interfaces;
using APIStudent.Model;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace APIStudent.DAO.Services
{
    public class RoleService : IRole
    {
        private readonly ScolariteDBContext _context;
        public RoleService(ScolariteDBContext context) => _context = context;
        public void AddRole(Role role)
        {
            try
            {
                _context.Roles.Add(role);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Role? GetRoleById(int id)
        {
            try
            {
                var role = _context.Roles.Find(id);
                return role;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Role> GetRolesByProfilId(int profilId)
        {
            try
            {
                var role = from r in _context.Roles 
                           join pr in _context.ProfilRoles on r.Id equals pr.RoleId
                           join p in _context.Profils on pr.ProfilId equals p.Id
                           where p.Id == profilId
                           select r;
                return role;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateRole(int roleId, Role role)
        {
            try
            {
                var roleTmp = _context.Roles.Find(roleId);
                if(roleTmp != null)
                {
                    roleTmp.CanWrite = role.CanWrite;
                    roleTmp.CanRead = role.CanRead;
                    roleTmp.CanDelete = role.CanDelete;
                    roleTmp.CanEdit = role.CanEdit;
                    roleTmp.CodeFonctionnalite = role.CodeFonctionnalite;

                    _context.Entry(roleTmp).State = EntityState.Modified;

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
