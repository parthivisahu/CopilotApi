using CopilotApi.Interfaces;
using CopilotApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CopilotApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        // GET: api/Doctor
        [HttpGet]
        public ActionResult<List<Doctor>> GetAllDoctors()
        {
            return _doctorService.GetAllDoctors();
        }

        // GET api/Doctor/5
        [HttpGet("{id}")]
        public ActionResult<Doctor> GetDoctorById(string id)
        {
            var doctor = _doctorService.GetDoctor(id);

            if (doctor == null)
            {
                return NotFound();
            }

            return doctor;
        }

        // POST api/Doctor
        [HttpPost]
        public ActionResult<Doctor> CreateDoctor(Doctor doctor)
        {
            _doctorService.CreateDoctor(doctor);

            return CreatedAtAction(nameof(GetDoctorById), new { id = doctor.Id }, doctor);
        }

        // PUT api/Doctor/5
        [HttpPut("{id}")]
        public IActionResult UpdateDoctor(string id, Doctor doctorIn)
        {
            var doctor = _doctorService.GetDoctor(id);

            if (doctor == null)
            {
                return NotFound();
            }

            _doctorService.UpdateDoctor(id, doctorIn);

            return NoContent();
        }

        // DELETE api/Doctor/5
        [HttpDelete("{id}")]
        public IActionResult DeleteDoctor(string id)
        {
            var doctor = _doctorService.GetDoctor(id);

            if (doctor == null)
            {
                return NotFound();
            }

            _doctorService.DeleteDoctor(id);

            return NoContent();
        }
    }
}
