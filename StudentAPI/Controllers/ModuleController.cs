using APIStudent.DAO.Interfaces;
using APIStudent.Model;
using Microsoft.AspNetCore.Mvc;

namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        private readonly ILogger<ModuleController> _logger;

        private readonly IModuleService _moduleService;

        private readonly IFormateurService _formateurService;

        public ModuleController(IModuleService service, IFormateurService formateurService, ILogger<ModuleController> logger)
        {
            _moduleService = service;
            _formateurService = formateurService;
            _logger = logger;
        }

        [Route("add")]
        [HttpPost]
        [ProducesResponseType(typeof(Module), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Module), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Module), StatusCodes.Status500InternalServerError)]
        public IActionResult AjouterModule([FromBody] Module module)
        {
            try
            {
                _logger.LogInformation("Création d'un module");

                if (module.FormateurId.HasValue && module.FormateurId.Value > 0)
                {
                    var formateur = _formateurService.getFormateurById(module.FormateurId.Value);

                    if (formateur != null)
                        module.Formateur = formateur;
                    else
                        _formateurService.add(module.Formateur);
                }

                _moduleService.add(module);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError("Erreur lors de la création du nouveau module" + e.Message);
            }

            return BadRequest();
        }


        [Route("all")]
        [HttpGet]
        [ProducesResponseType(typeof(Module), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Module), StatusCodes.Status404NotFound)]
        public IActionResult Get()
        {
            try
            {
                _logger.LogInformation("appel méthode");
                var modules = _moduleService.getAll();
                return modules == null ? NotFound() : Ok(modules);
            }
            catch (Exception)
            {

            }

            return NotFound();
        }
    }
}
