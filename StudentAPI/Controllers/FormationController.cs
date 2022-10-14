using APIStudent.DAO.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormationController : ControllerBase
    {
        private readonly IFormationService _formationService;

        public FormationController(IFormationService formationService) =>  this._formationService = formationService;

        [Route("All")]
        [HttpGet]
        public IActionResult Get()
        {
            var formations = _formationService.GetFormations();

            return formations == null ? NotFound() : Ok(formations);
        }

        [Route("Find/{id}")]
        [HttpGet]
        public IActionResult GetFormationByid(int id)
        {
            var formation = _formationService.GetFormationById(id);

            return formation == null ? NotFound() : Ok(formation);
        }
    }
}
