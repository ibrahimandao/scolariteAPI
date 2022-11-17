using APIStudent.DAO.Interfaces;
using APIStudent.Model;
using Microsoft.AspNetCore.Mvc;

namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly ILogger<RoleController> _logger;

        private readonly IRole _roleService;

        public RoleController(IRole role, ILogger<RoleController> logger)
        {
            _roleService = role;
            _logger = logger;
        }

        [Route("add")]
        [HttpPost]
        [ProducesResponseType(typeof(Role), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Role), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Role), StatusCodes.Status500InternalServerError)]
        public IActionResult AjouterRole([FromBody] Role role)
        {
            try
            {
                _logger.LogInformation($"Création d'un nouveau role sur la fonctionnalité  {role.CodeFonctionnalite}");

                _roleService.AddRole(role);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError($"Erreur lors de la création du  nouveau role sur la fonctionnalité  {role.CodeFonctionnalite}" + e.Message);
            }

            return BadRequest();
        }


        [Route("find/{id}")]
        [HttpGet]
        [ProducesResponseType(typeof(Role), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Role), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Role), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(Role), StatusCodes.Status404NotFound)]
        public IActionResult GetRoleById(int id)
        {
            try
            {
                _logger.LogInformation($"Récupération d'un role avec l'identifiant  {id}");

                var user = _roleService.GetRoleById(id);
                if (user != null)
                    return Ok(user);
            }
            catch (Exception e)
            {
                _logger.LogError("Erreur lors de la récupération du role" + e.Message);
                throw;
            }

            return NotFound();
        }

        [Route("profil/{profilId}/roles")]
        [HttpGet]
        [ProducesResponseType(typeof(Role), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Role), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Role), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(Role), StatusCodes.Status404NotFound)]
        public IActionResult GetRoleByProfilId(int profilId)
        {
            try
            {
                _logger.LogInformation($"Récupération de la liste des  roles du profil  {profilId}");

                var roles = _roleService.GetRolesByProfilId(profilId);
                if (roles != null)
                    return Ok(roles);
            }
            catch (Exception e)
            {
                _logger.LogError($"Erreur lors de la récupération de la liste des  roles du profil  {profilId}" + e.Message);
                throw;
            }

            return NotFound();
        }


        [Route("update/{id}")]
        [HttpPut]
        [ProducesResponseType(typeof(Role), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Role), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Role), StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateUtilisateur(int id, [FromBody] Role role)
        {
            try
            {
                _logger.LogInformation($"Mise à jour du rôle dont l'identifiant est  {role.Id}");


                _roleService.UpdateRole(id, role);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError("Erreur lors de la mise à jour d'un rôle" + e.Message);

            }

            return BadRequest();
        }
    }
}
