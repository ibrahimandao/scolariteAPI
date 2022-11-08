using APIStudent.DAO.Interfaces;
using APIStudent.Model;
using Microsoft.AspNetCore.Mvc;

namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormationModuleController : ControllerBase
    {
        private readonly ILogger<FormationModuleController> _logger;

        private readonly IFormationModuleService _formationModuleService;

        public FormationModuleController(IFormationModuleService formationModuleService, ILogger<FormationModuleController> logger)
        {
            _formationModuleService = formationModuleService;
            _logger = logger;
        }

        [Route("add")]
        [HttpPost]
        [ProducesResponseType(typeof(FormationModuleForAdd), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FormationModuleForAdd), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(FormationModuleForAdd), StatusCodes.Status500InternalServerError)]
        public IActionResult AjouterLienFormationModule([FromBody] FormationModuleForAdd formationModule)
        {
            try
            {
                _logger.LogInformation("Création d'un rattachement Formation >> Module");

                _formationModuleService.add(formationModule);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError("Erreur lors de la création d'un rattachement Formation >> Module" + e.Message);
            }

            return BadRequest();
        }


        [Route("update/{id}")]
        [HttpPut]
        [ProducesResponseType(typeof(FormationModuleForAdd), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FormationModuleForAdd), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(FormationModuleForAdd), StatusCodes.Status500InternalServerError)]
        public IActionResult ModifierLienFormationModule(int id,[FromBody] FormationModuleForAdd formationModule)
        {
            try
            {
                _logger.LogInformation("Modification du rattachement Formation >> Module");

                _formationModuleService.update(id,formationModule);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError("Erreur lors de la odification du rattachement Formation >> Module" + e.Message);
            }

            return BadRequest();
        }

        [Route("Formation/{formationId}/modules")]
        [HttpGet]
        [ProducesResponseType(typeof(ListeModuleFormation), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ListeModuleFormation), StatusCodes.Status404NotFound)]
        public IActionResult GetModulesByFormationId(int formationId)
        {
            try
            {
                _logger.LogInformation("Liste des modules d'une formation");
                var modules = _formationModuleService.getModulesByFormationId(formationId);
                return modules == null ? NotFound() : Ok(modules);
            }
            catch (Exception)
            {

            }

            return NotFound();
        }


        [Route("all")]
        [HttpGet]
        [ProducesResponseType(typeof(FormationModule), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FormationModule), StatusCodes.Status404NotFound)]
        public IActionResult GetAll()
        {
            try
            {
                _logger.LogInformation("Liste des module>>formation>>formateur");
                var moduleFormationFormateur = _formationModuleService.get();
                return moduleFormationFormateur == null ? NotFound() : Ok(moduleFormationFormateur);
            }
            catch (Exception)
            {

            }

            return NotFound();
        }

        [Route("planningdelasemaine")]
        [HttpGet]
        [ProducesResponseType(typeof(FormationModule), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FormationModule), StatusCodes.Status404NotFound)]
        public IActionResult GetPlanningSemaine()
        {
            try
            {
                _logger.LogInformation("Liste des module>>formation>>formateur : planning de la semaine");
                var moduleFormationFormateur = _formationModuleService.getPlanningDelaSemaine();
                return moduleFormationFormateur == null ? NotFound() : Ok(moduleFormationFormateur);
            }
            catch (Exception)
            {

            }

            return NotFound();
        }

        [Route("planingpardate")]
        [HttpGet]
        [ProducesResponseType(typeof(FormationModule), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FormationModule), StatusCodes.Status404NotFound)]
        public IActionResult GetFormationModuleByDate(DateTime dateDebut,DateTime dateFin)
        {
            try
            {
                _logger.LogInformation("Liste des module>>formation>>formateur sur l'intervalle "+ dateDebut +" "+ dateFin);
                var moduleFormationFormateur = _formationModuleService.getByDate(dateDebut, dateFin);
                return moduleFormationFormateur == null ? NotFound() : Ok(moduleFormationFormateur);
            }
            catch (Exception)
            {

            }

            return NotFound();
        }

        [Route("find/{id}")]
        [HttpGet]
        [ProducesResponseType(typeof(FormationModuleForAdd), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FormationModuleForAdd), StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            try
            {
                _logger.LogInformation("Récupère un model formule <-> module à partir d'un id");
                var formationModule = _formationModuleService.getById(id);
                return formationModule == null ? NotFound() : Ok(formationModule);
            }
            catch (Exception)
            {

            }

            return NotFound();
        }

        [Route("delete/{id}")]
        [HttpDelete]
        [ProducesResponseType(typeof(FormationModuleForAdd), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FormationModuleForAdd), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(FormationModuleForAdd), StatusCodes.Status500InternalServerError)]
        public IActionResult SuppressionFormationModule(int id)
        {
            try
            {
                _logger.LogInformation("suppression lien formule <-> module à partir d'un id");
                _formationModuleService.remove(id);
                return Ok();
            }
            catch (Exception)
            {
               
            }

            return NotFound();
        }
    }
}
