using APIStudent.DAO.Interfaces;
using APIStudent.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormateurController : ControllerBase
    {
        private readonly ILogger<FormateurController> _logger;

        private readonly IFormateurService _formateurService;

        public FormateurController(IFormateurService service, ILogger<FormateurController> logger)
        {
            _formateurService = service;
            _logger = logger;
        }

        [Route("add")]
        [HttpPost]
        [ProducesResponseType(typeof(Formateur), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Formateur), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Formateur), StatusCodes.Status500InternalServerError)]
        public IActionResult AjouterFormateur([FromBody] Formateur formateur)
        {
            try
            {
                _logger.LogInformation("Création d'un formateur");

                _formateurService.add(formateur);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError("Erreur lors de la création du nouveau formateur" + e.Message);
            }

            return BadRequest();
        }

        

        [Route("all")]
        [HttpGet]
        [ProducesResponseType(typeof(Formateur), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Formateur), StatusCodes.Status404NotFound)]
        public IActionResult Get()
        {
            try
            {
                _logger.LogInformation("appel méthode");
                var formateurs = _formateurService.getAll();
                return formateurs == null ? NotFound() : Ok(formateurs);
            }
            catch (Exception)
            {

            }

            return NotFound();
        }

        [Route("findbyid/{id}")]
        [HttpGet]
        [ProducesResponseType(typeof(Formateur), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Formateur), StatusCodes.Status404NotFound)]
        public IActionResult GetEtudiantById(int id)
        {
            try
            {
                _logger.LogInformation("Récupération d'un formateur de par son id");
                var formateur = _formateurService.getFormateurById(id);
                return formateur == null ? NotFound() : Ok(formateur);
            }
            catch (Exception)
            {

            }

            _logger.LogInformation("formateur non trouvé");
            return NotFound();
        }


        [Route("update/{id}")]
        [HttpPut]
        [ProducesResponseType(typeof(Formateur), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Formateur), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Formateur), StatusCodes.Status500InternalServerError)]
        public IActionResult ModifierFormateur(int id, [FromBody] Formateur formateur)
        {
            try
            {
                _logger.LogInformation("Modification d'un formateur");

                _formateurService.update(id, formateur);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError("Erreur lors de la modification d'un formateur" + e.Message);
            }

            return BadRequest();
        }
    }
}
