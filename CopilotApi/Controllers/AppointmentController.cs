using CopilotApi.Interfaces;
using CopilotApi.Models;
using CopilotApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CopilotApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentServices _appointmentService;

        public AppointmentController(IAppointmentServices appointmentService)
        {
            _appointmentService = appointmentService;
        }

        // GET: api/Appointment
        [HttpGet]
        public ActionResult<List<Appointment>> GetAllAppointments()
        {
            return _appointmentService.GetAllAppointments();
        }

        // GET api/Appointment/5
        [HttpGet("{id}")]
        public ActionResult<Appointment> GetAppointmentById(string id)
        {
            var appointment = _appointmentService.GetAppointment(id);

            if (appointment == null)
            {
                return NotFound();
            }

            return appointment;
        }

        // POST api/Appointment
        [HttpPost]
        public ActionResult<Appointment> CreateAppointment(Appointment appointment)
        {
            _appointmentService.CreateAppointment(appointment);

            return CreatedAtAction(nameof(GetAppointmentById), new { id = appointment.Id }, appointment);
        }

        // PUT api/Appointment/5
        [HttpPut("{id}")]
        public IActionResult UpdateAppointment(string id, Appointment appointmentIn)
        {
            var appointment = _appointmentService.GetAppointment(id);

            if (appointment == null)
            {
                return NotFound();
            }

            _appointmentService.UpdateAppointment(id, appointmentIn);

            return NoContent();
        }

        // DELETE api/Appointment/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAppointment(string id)
        {
            var appointment = _appointmentService.GetAppointment(id);

            if (appointment == null)
            {
                return NotFound();
            }

            _appointmentService.DeleteAppointment(id);

            return NoContent();
        }
    }
}
