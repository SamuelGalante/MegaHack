using MegaHack.Context;
using MegaHack.Entity.Appointment;
using MegaHack.Entity.User;
using MegaHack.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaHack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class AppointmentController : ControllerBase
    {
        [HttpPost("create")]
        public async Task<ActionResult> Create(AppointmentModel appointmentModel)
        {
            using (var context = new MegaHackContext())
            {
                try
                {
                    var appointment = new Appointment();
                    var patient = context.User.Where(u => u.Id == appointmentModel.IdPatient).First();
                    var professional = context.User.Where(u => u.Id == appointmentModel.IdProfessional).First();

                    appointment.Patient = (Patient)patient;
                    appointment.Professional = (Professional)professional;

                    appointment.Date = appointmentModel.Date;

                    await context.Appointment.AddAsync(appointment);
                    await context.SaveChangesAsync();

                    return Ok(true);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return Ok(false);

                }
            }
        }

        [HttpPost("delete")]
        public async Task<ActionResult> Delete(AppointmentModel appointmentModel)
        {
            using (var context = new MegaHackContext())
            {
                try
                {
                    var appointment = context.Appointment.Where(u => u.Id == appointmentModel.Id).First();

                    context.Appointment.Remove(appointment);

                    await context.SaveChangesAsync();

                    return Ok(true);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                    return Ok(false);
                }
            }
        }

        [HttpGet("getListAppointment")]
        public async Task<ActionResult> GetListAppointment(AppointmentModel appointmentModel)
        {
            using (var context = new MegaHackContext())
            {
                try
                {


                    var appointment = context.Appointment.ToList();
                    if(appointmentModel.IdPatient > 0)
                    {
                        appointment = appointment.Where(a => a.Patient.Id == appointmentModel.IdPatient).ToList();
                    }

                    if (appointmentModel.IdProfessional > 0)
                    {
                        appointment = appointment.Where(a => a.Professional.Id == appointmentModel.IdProfessional).ToList();
                    }

                    return Ok(appointment.ToArray());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                    return Ok(false);
                }
            }
        }
    }
}
