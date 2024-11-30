using Business.Interface;
using Entity.DTO.Request;
using Microsoft.AspNetCore.Mvc;

namespace JeanFernandez.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonalController : Controller
    {
        private readonly IPersonalApplication _personalApplication;
        public PersonalController(IPersonalApplication personalApplication)
        {
            _personalApplication = personalApplication;
        }
        [HttpGet()]
        [Route("GetPersonal")]
        public async Task<ActionResult> GetPersonal()
        {
            return Ok(await _personalApplication.GetPersonal());
        }
        [HttpGet()]
        [Route("GetPersonalById")]
        public async Task<ActionResult> GetPersonalById(int IdPersonal)
        {
            return Ok(await _personalApplication.GetPersonalById(IdPersonal));
        }
        [HttpPost()]
        [Route("AddOrUpdatePersonal")]
        public async Task<ActionResult> AddOrUpdatePersonal(AddOrUpdatePersonalRequestDto personal)
        {
            return Ok(await _personalApplication.AddOrUpdatePersonal(personal));
        }
        [HttpDelete()]
        [Route("DeletePersonal")]
        public async Task<ActionResult> DeletePersonal(int IdPersonal)
        {
            return Ok(await _personalApplication.DeletePersonal(IdPersonal));
        }
    }
}
