using APIStudent.DAO.Interfaces;
using APIStudent.Model;
using Microsoft.AspNetCore.Mvc;

namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilRoleController : ControllerBase
    {
        private readonly ILogger<ProfilRoleController> _logger;

        private readonly IProfilRole _profilRoleService;

        public ProfilRoleController(IProfilRole profilRole, ILogger<ProfilRoleController> logger)
        {
            _profilRoleService = profilRole;
            _logger = logger;
        }

        [Route("add")]
        [HttpPost]
        [ProducesResponseType(typeof(ProfilRoleLite), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProfilRoleLite), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProfilRoleLite), StatusCodes.Status500InternalServerError)]
        public IActionResult RattachementProfilRole([FromBody] ProfilRoleLite profilRole)
        {
            try
            {
                _logger.LogInformation($"Rattachement profil: {profilRole.ProfilId} au role : {profilRole.RoleId}");

                _profilRoleService.Add(profilRole);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError($"Erreur lors du rattachement profil: {profilRole.ProfilId} au role : {profilRole.RoleId}" + e.Message);
            }

            return BadRequest();
        }


        [Route("delete/{id}")]
        [HttpDelete]
        [ProducesResponseType(typeof(ProfilRoleLite), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProfilRoleLite), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProfilRoleLite), StatusCodes.Status500InternalServerError)]
        public IActionResult SuppressionLienProfilRole(int id)
        {
            try
            {
                _logger.LogInformation($"Supression rattachement profil -> role : {id}");

                _profilRoleService.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError($"Erreur lors de la supression rattachement profil -> role : {id}" + e.Message);
            }

            return BadRequest();
        }

        [Route("update/{id}")]
        [HttpPut]
        [ProducesResponseType(typeof(ProfilRoleLite), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProfilRoleLite), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProfilRoleLite), StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateLienProfilRole(int id, [FromBody] ProfilRoleLite profilRole)
        {
            try
            {
                _logger.LogInformation($"Mise à jour rattachement profil -> role : {id}");

                _profilRoleService.Update(id, profilRole);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError($"Erreur lors de la modification du rattachement profil -> role : {id}" + e.Message);
            }

            return BadRequest();
        }
    }
}
