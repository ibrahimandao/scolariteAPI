using APIStudent.DAO.Interfaces;
using APIStudent.Model;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilisateurController : ControllerBase
    {
        private readonly ILogger<UtilisateurController> _logger;

        private readonly IUtilisateur _utilisateurService;

        private readonly IProfil _profilService;

        public UtilisateurController(IUtilisateur utilisateur, IProfil profil, ILogger<UtilisateurController> logger)
        {
            _utilisateurService = utilisateur;
            _profilService = profil;
            _logger = logger;
        }

        [Route("add")]
        [HttpPost]
        [ProducesResponseType(typeof(Utilisateur), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Utilisateur), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Utilisateur), StatusCodes.Status500InternalServerError)]
        public IActionResult AjouterUtilisateur([FromBody] Utilisateur utilisateur)
        {
            try
            {
                _logger.LogInformation($"Création d'un nouvel utilisateur  {utilisateur.Nom} - {utilisateur.Prenom}");

                if (utilisateur.ProfilId.HasValue && utilisateur.ProfilId.Value > 0)
                {
                    var profil = _profilService.GetProfilsById(utilisateur.ProfilId.Value);

                    if (profil != null)
                        utilisateur.Profil = profil;
                    else
                        _profilService.AddProfil(utilisateur.Profil);
                }

                _utilisateurService.AddUtlisateur(utilisateur);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError("Erreur lors de la création du nouvel utilisateur" + e.Message);
            }

            return BadRequest();
        }

        [Route("update/{id}")]
        [HttpPut]
        [ProducesResponseType(typeof(Utilisateur), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Utilisateur), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Utilisateur), StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateUtilisateur(int id,[FromBody] Utilisateur utilisateur)
        {
            try
            {
                _logger.LogInformation($"Mise à jour de l'utilisateur dont l'identifiant est  {utilisateur.Id}");
               

                _utilisateurService.UpdateUtlisateur(id,utilisateur);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError("Erreur lors de la mise à jour de l'utilisateur" + e.Message);

            }

            return BadRequest();
        }

        [Route("find/{id}")]
        [HttpGet]
        [ProducesResponseType(typeof(Utilisateur), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Utilisateur), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Utilisateur), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(Utilisateur), StatusCodes.Status404NotFound)]
        public IActionResult GetUtilisateurById(int id)
        {
            try
            {
                _logger.LogInformation($"Récupération de l'utilisateur avec l'identifiant  {id}");

                var user = _utilisateurService.GetUtilisateurById(id);
                if(user != null)
                  return Ok(user);
            }
            catch (Exception e)
            {
                _logger.LogError("Erreur lors de la création du nouvel utilisateur" + e.Message);
                throw;
            }

            return NotFound();
        }

        [Route("connexion")]
        [HttpGet]
        [ProducesResponseType(typeof(Utilisateur), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Utilisateur), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Utilisateur), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(Utilisateur), StatusCodes.Status404NotFound)]
        public IActionResult Connexion([FromHeader] string  login, [FromHeader]  string password)
        {
            try
            {
                _logger.LogInformation($"Connexion de l'utilisateur avec l'identifiant  {login}");

                var user = _utilisateurService.Connexion(login, password);
                if (user != null)
                    return Ok(user);
            }
            catch (Exception e)
            {
                _logger.LogError("Erreur lors de la connexion du nouvel utilisateur" + e.Message);
                throw;
            }

            return NotFound();
        }

        [Route("roles")]
        [HttpGet]
        [ProducesResponseType(typeof(Role), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Role), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Role), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(Role), StatusCodes.Status404NotFound)]
        public IActionResult RolesByLogin(string login)
        {
            try
            {
                _logger.LogInformation($"Récupération des rôles de l'utilisateur avec l'identifiant  {login}");

                var roles = _utilisateurService.GetRolesByLogin(login);
                if (roles != null)
                    return Ok(roles);
            }
            catch (Exception e)
            {
                _logger.LogError("Erreur lors de la récupération des rôles de l'utilisateur" + e.Message);
                throw;
            }

            return NotFound();
        }
    }
}
