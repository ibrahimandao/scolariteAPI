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
        [ProducesResponseType(typeof(FormationModule), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FormationModule), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(FormationModule), StatusCodes.Status500InternalServerError)]
        public IActionResult AjouterModule([FromBody] FormationModule formationModule)
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


        [Route("Formation/{formationId}/modules")]
        [HttpGet]
        [ProducesResponseType(typeof(Module), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Module), StatusCodes.Status404NotFound)]
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
    }
}
