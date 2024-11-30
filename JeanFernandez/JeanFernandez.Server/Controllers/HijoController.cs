using Business.Interface;
using Entity.DTO.Request;
using Microsoft.AspNetCore.Mvc;

namespace JeanFernandez.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HijoController : Controller
    {
        private readonly IHijoApplication _hijoApplication;
        public HijoController(IHijoApplication hijoApplication)
        {
            _hijoApplication = hijoApplication;
        }
        [HttpGet()]
        [Route("GetHijosByIdPersonal")]
        public async Task<ActionResult> GetHijosByIdPersonal(int IdPersonal)
        {
            return Ok(await _hijoApplication.GetHijosByIdPersonal(IdPersonal));
        }
        [HttpGet()]
        [Route("GetHijoById")]
        public async Task<ActionResult> GetHijoById(int IdHijo)
        {
            return Ok(await _hijoApplication.GetHijoById(IdHijo));
        }
        [HttpPost()]
        [Route("AddOrUpdateHijo")]
        public async Task<ActionResult> AddOrUpdateHijo(AddOrUpdateHijoRequestDto hijo)
        {
            return Ok(await _hijoApplication.AddOrUpdateHijo(hijo));
        }
        [HttpDelete()]
        [Route("DeleteHijo")]
        public async Task<ActionResult> DeleteHijo(int IdHijo)
        {
            return Ok(await _hijoApplication.DeleteHijo(IdHijo));
        }
    }
}
