using APIStudent.Model;

namespace APIStudent.DAO.Interfaces
{
    public interface IRole
    {
        public IEnumerable<Role> GetRolesByProfilId(int profilId);

        public Role? GetRoleById(int id);

        public void AddRole(Role role);

        public void UpdateRole(int roleId,Role role);
    }
}
