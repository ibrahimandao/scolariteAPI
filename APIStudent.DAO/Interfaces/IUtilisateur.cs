using APIStudent.Model;

namespace APIStudent.DAO.Interfaces
{
    public  interface IUtilisateur
    {
        public Utilisateur? GetUtilisateurById(int utilisateurId);

        public void AddUtlisateur(Utilisateur utilisateur);

        public void UpdateUtlisateur(int utilisateurId, Utilisateur utilisateur);

        public Utilisateur? Connexion(string login,string password);
        public IEnumerable<Role> GetRolesByLogin(string login);
    }
}
