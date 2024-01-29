using CopilotApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CopilotApi.Models;

namespace CopilotApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        // GET: api/Patients
        [HttpGet]
        public ActionResult<List<Patient>> GetAllPatients()
        {
            return _patientService.GetAllPatients();
        }

        // GET api/Patients/5
        [HttpGet("{id}")]
        public ActionResult<Patient> GetPatientById(string id)
        {
            var patient = _patientService.GetPatient(id);

            if (patient == null)
            {
                return NotFound();
            }

            return patient;
        }

        // POST api/Patients
        [HttpPost]
        public ActionResult<Patient> CreatePatient(Patient patient)
        {
            _patientService.CreatePatient(patient);

            return CreatedAtAction(nameof(GetPatientById), new { id = patient.Id }, patient);
        }

        // PUT api/Patients/5
        [HttpPut("{id}")]
        public IActionResult UpdatePatient(string id, Patient patientIn)
        {
            var patient = _patientService.GetPatient(id);

            if (patient == null)
            {
                return NotFound();
            }

            _patientService.UpdatePatient(id, patientIn);

            return NoContent();
        }

        // DELETE api/Patients/5
        [HttpDelete("{id}")]
        public IActionResult DeletePatient(string id)
        {
            var patient = _patientService.GetPatient(id);

            if (patient == null)
            {
                return NotFound();
            }

            _patientService.DeletePatient(id);

            return NoContent();
        }
    }
}
