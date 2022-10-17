using APIStudent.DAO.Interfaces;
using APIStudent.Model;
using Microsoft.AspNetCore.Mvc;

namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EtudiantController : ControllerBase
    {
        private readonly ILogger<EtudiantController> _logger;

        private readonly IStudentService _studentService;

        private readonly IFormationService _formationService;

        public EtudiantController(IStudentService studentService, IFormationService formationService, ILogger<EtudiantController> logger)
        {
            _studentService = studentService;
            _formationService = formationService;
            _logger = logger;
        }

        [Route("add")]
        [HttpPost]
        [ProducesResponseType(typeof(Etudiant), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Etudiant), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Etudiant), StatusCodes.Status500InternalServerError)]
        public IActionResult AjouterEtudiant([FromBody]Etudiant etudiant)
        {
            try
            {
                _logger.LogInformation("appel méthode");

                _formationService.Add(etudiant.Formation);
                _studentService.Add(etudiant);
                return Ok();
            }
            catch (Exception)
            {

            }

            return BadRequest();
        }

        [Route("find/{matricule}")]
        [HttpGet]
        [ProducesResponseType(typeof(Etudiant),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Etudiant), StatusCodes.Status404NotFound)]
        public IActionResult GetEtudiant(string matricule)
        {
            try
            {
                _logger.LogInformation("appel méthode");
                var etudiant =   _studentService.Find(matricule);
                return etudiant == null ? NotFound() : Ok(etudiant) ;
            }
            catch (Exception)
            {

            }
            return NotFound();
        }


        [Route("all")]
        [HttpGet]
        [ProducesResponseType(typeof(Etudiant), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Etudiant), StatusCodes.Status404NotFound)]
        public IActionResult Get()
        {
            try
            {
                _logger.LogInformation("appel méthode");
                var etudiants = _studentService.GetList();
                return etudiants == null ? NotFound() : Ok(etudiants);
            }
            catch (Exception)
            {

            }

            return NotFound();
        }
    }
}
