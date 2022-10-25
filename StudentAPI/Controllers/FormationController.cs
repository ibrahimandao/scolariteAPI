using APIStudent.DAO.Interfaces;
using APIStudent.DAO.Services;
using APIStudent.Model;
using Microsoft.AspNetCore.Mvc;

namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormationController : ControllerBase
    {
        private readonly ILogger<FormationController> _logger;

        private readonly IFormationService _formationService;

        public FormationController(IFormationService formationService, ILogger<FormationController> logger) 
        {
            this._formationService = formationService;
            this._logger = logger;
        }  


        [Route("add")]
        [HttpPost]
        [ProducesResponseType(typeof(Formation), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Formation), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Formation), StatusCodes.Status500InternalServerError)]
        public IActionResult AjouterFormation([FromBody] Formation formation)
        {
            try
            {
                _logger.LogInformation("Création d'une formation");

                _formationService.Add(formation);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError("Erreur lors de la création d'une formation" + e.Message);
            }

            return BadRequest();
        }

        [Route("all")]
        [HttpGet]
        public IActionResult Get()
        {
            var formations = _formationService.GetFormations();

            return formations == null ? NotFound() : Ok(formations);
        }

        [Route("find/{id}")]
        [HttpGet]
        public IActionResult GetFormationByid(int id)
        {
            var formation = _formationService.GetFormationById(id);

            return formation == null ? NotFound() : Ok(formation);
        }

        [Route("delete/{formationId}")]
        [HttpDelete]
        [ProducesResponseType(typeof(Formation), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Formation), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Formation), StatusCodes.Status500InternalServerError)]
        public IActionResult SupprimerFormation(int formationId)
        {
            try
            {
                _logger.LogInformation("suppression d'une formation");

                _formationService.Delete(formationId);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError("Erreur lors de la suppression d'une formation" + e.Message);
            }

            return BadRequest();
        }


        [Route("update/{id}")]
        [HttpPut]
        [ProducesResponseType(typeof(Formation), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Formation), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Formation), StatusCodes.Status500InternalServerError)]
        public IActionResult ModifierFormation(int id,[FromBody] Formation formation)
        {
            try
            {
                _logger.LogInformation("Modification d'une formation");

                _formationService.Update(id, formation);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError("Erreur lors de la modification d'une formation" + e.Message);
            }

            return BadRequest();
        }
    }
}
