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
                _logger.LogInformation("Ajout d'un étudiant");
                
                if (etudiant.FormationId.HasValue && etudiant.FormationId.Value>0)
                {
                    var formation = _formationService.GetFormationById(etudiant.FormationId.Value);
                    if (formation == null)
                        _formationService.Add(etudiant.Formation);
                    else
                        etudiant.Formation = formation;
                }
                else
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

        [Route("findbyid/{id}")]
        [HttpGet]
        [ProducesResponseType(typeof(Etudiant), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Etudiant), StatusCodes.Status404NotFound)]
        public IActionResult GetEtudiantById(int id)
        {
            try
            {
                _logger.LogInformation("Récupération d'un étudiant de par son id");
                var etudiant = _studentService.FindById(id);
                return etudiant == null ? NotFound() : Ok(etudiant);
            }
            catch (Exception)
            {

            }

            _logger.LogInformation("Etudiant non trouvé");
            return NotFound();
        }


        [Route("update/{id}")]
        [HttpPut]
        [ProducesResponseType(typeof(Formation), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Formation), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Formation), StatusCodes.Status500InternalServerError)]
        public IActionResult ModifierEtudiant(int id, [FromBody] Etudiant etudiant)
        {
            try
            {
                _logger.LogInformation("Modification d'un étudiant");

                _studentService.Update(id, etudiant);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError("Erreur lors de la modification d'un étudiant" + e.Message);
            }

            return BadRequest();
        }


        [Route("Formation/{formationId}/list")]
        [HttpGet]
        [ProducesResponseType(typeof(ListeEtudiantFormation), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ListeEtudiantFormation), StatusCodes.Status404NotFound)]
        public IActionResult GetEtudiantByFormationId(int formationId)
        {
            try
            {
                _logger.LogInformation("appel méthode");
                var etudiants = _studentService.GetEtudiantByFormationId(formationId);
                return etudiants == null ? NotFound() : Ok(etudiants);
            }
            catch (Exception)
            {

            }
            return NotFound();
        }
    }
}
