using APIStudent.DAO.Interfaces;
using APIStudent.Model;
using Microsoft.AspNetCore.Mvc;

namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilController : ControllerBase
    {
        private readonly ILogger<ProfilController> _logger;

        private readonly IProfil _profilService;

        public ProfilController(IProfil profil, ILogger<ProfilController> logger)
        {
            _profilService = profil;
            _logger = logger;
        }

        [Route("add")]
        [HttpPost]
        [ProducesResponseType(typeof(Profil), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Profil), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Profil), StatusCodes.Status500InternalServerError)]
        public IActionResult AjouterProfil([FromBody] Profil profil)
        {
            try
            {
                _logger.LogInformation($"Création d'un nouveau profil utilisateur : {profil.Libelle}");

                _profilService.AddProfil(profil);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError($"Erreur lors de la création du  nouveau profil utilisateur  {profil.Libelle}" + e.Message);
            }

            return BadRequest();
        }


        [Route("all")]
        [HttpGet]
        [ProducesResponseType(typeof(Profil), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Profil), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Profil), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(Profil), StatusCodes.Status404NotFound)]
        public IActionResult GetProfils()
        {
            try
            {
                _logger.LogInformation($"Récupération de la liste des profils");

                var profils = _profilService.GetProfils();
                if (profils != null)
                    return Ok(profils);
            }
            catch (Exception e)
            {
                _logger.LogError("Erreur lors de la récupération des profils" + e.Message);
                throw;
            }

            return NotFound();
        }

        [Route("find/{id}")]
        [HttpGet]
        [ProducesResponseType(typeof(Profil), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Profil), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Profil), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(Profil), StatusCodes.Status404NotFound)]
        public IActionResult GetProfilById(int id)
        {
            try
            {
                _logger.LogInformation($"Récupération du profil dont l'identifiant est {id}");

                var profil = _profilService.GetProfilsById(id);
                if (profil != null)
                    return Ok(profil);
            }
            catch (Exception e)
            {
                _logger.LogError($"Erreur lors de la récupération du profil dont l'identifiant est {id}" + e.Message);
                throw;
            }

            return NotFound();
        }


        [Route("update/{id}")]
        [HttpPut]
        [ProducesResponseType(typeof(Profil), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Profil), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Profil), StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateProfil(int id, [FromBody] Profil profil)
        {
            try
            {
                _logger.LogInformation($"Mise à jour du profil dont l'identifiant est  {id}");


                _profilService.UpdateProfil(id, profil);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError($"Erreur lors de la mise à jour du profil dont l'identifiant est  {id}" + e.Message);

            }

            return BadRequest();
        }
    }
}
