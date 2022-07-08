using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Cwiczenia6.DataAccessLayer;
using System.Threading.Tasks;
using System;

namespace Cwiczenia6.Controllers
{
    [Route("api/PrescriptionsController")]
    [ApiController]
    public class PrescriptionsController : ControllerBase
    {

        private readonly IPrescriptionDataAccess _prescriptionsDataAccess;
        public PrescriptionsController(IPrescriptionDataAccess prescriptionsDataAccess)
        {
            _prescriptionsDataAccess = prescriptionsDataAccess;

        }

        [HttpGet("IdDoctor")]
        public async Task<IActionResult> GetPrescriptionDTO(int IdPrescription)
        {
            try
            {
                return Ok(await _prescriptionsDataAccess.GetPrescriptionDTO(IdPrescription));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
