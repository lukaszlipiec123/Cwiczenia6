using System;
using System.Threading.Tasks;
using Cwiczenia6.DataAccessLayer;
using Cwiczenia6.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cwiczenia6.Controllers
{
    [Route("api/DoctorsController")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {


        private readonly IDoctorsDataAccess _doctorsDataAccess;
        public DoctorsController(IDoctorsDataAccess tripsDataAccess)
        {
            _doctorsDataAccess = tripsDataAccess;

        }

        [HttpGet("IdDoctor")]
        public async Task<IActionResult> GetDoctorDetails(int IdDoctor)
        {
            try
            {
                return Ok(await _doctorsDataAccess.GetDoctorDetails(IdDoctor));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> PostDoctor(Doctor doctor)
        {

            try
            {
                return Ok(await _doctorsDataAccess.CreateDoctor(doctor));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("IdDoctor")]
        public async Task<IActionResult> DeleteDoctor(int IdDoctor)
        {
            try
            {
                return Ok(await _doctorsDataAccess.DeleteDoctor(IdDoctor));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("IdDoctor")]
        public async Task<IActionResult> ModifyDoctor(int IdDoctor, Doctor doctor)
        {
            try
            {
                return Ok(await _doctorsDataAccess.ModifyDoctor(IdDoctor, doctor));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
