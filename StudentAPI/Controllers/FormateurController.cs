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

        //[Route("find/{matricule}")]
        //[HttpGet]
        //[ProducesResponseType(typeof(Etudiant), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(Etudiant), StatusCodes.Status404NotFound)]
        //public IActionResult GetEtudiant(string matricule)
        //{
        //    try
        //    {
        //        _logger.LogInformation("appel méthode");
        //        var etudiant = _studentService.Find(matricule);
        //        return etudiant == null ? NotFound() : Ok(etudiant);
        //    }
        //    catch (Exception)
        //    {

        //    }
        //    return NotFound();
        //}


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

        //[Route("findbyid/{id}")]
        //[HttpGet]
        //[ProducesResponseType(typeof(Etudiant), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(Etudiant), StatusCodes.Status404NotFound)]
        //public IActionResult GetEtudiantById(int id)
        //{
        //    try
        //    {
        //        _logger.LogInformation("Récupération d'un étudiant de par son id");
        //        var etudiant = _studentService.FindById(id);
        //        return etudiant == null ? NotFound() : Ok(etudiant);
        //    }
        //    catch (Exception)
        //    {

        //    }

        //    _logger.LogInformation("Etudiant non trouvé");
        //    return NotFound();
        //}


        //[Route("update/{id}")]
        //[HttpPut]
        //[ProducesResponseType(typeof(Formation), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(Formation), StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(typeof(Formation), StatusCodes.Status500InternalServerError)]
        //public IActionResult ModifierEtudiant(int id, [FromBody] Etudiant etudiant)
        //{
        //    try
        //    {
        //        _logger.LogInformation("Modification d'un étudiant");

        //        _studentService.Update(id, etudiant);
        //        return Ok();
        //    }
        //    catch (Exception e)
        //    {
        //        _logger.LogError("Erreur lors de la modification d'un étudiant" + e.Message);
        //    }

        //    return BadRequest();
        //}
    }
}
