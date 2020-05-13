using CryptSharp;
using MegaHack.Context;
using MegaHack.Entity.User;
using MegaHack.Models;
using MegaHack.Models.FlyWeight;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaHack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        [HttpPost("auth")]
        public async Task<ActionResult> Auth([FromBody]LoginModel model)
        {
            using (var context = new MegaHackContext())
            {
                try
                {

                    return Ok(await context.User.AnyAsync(p => p.UserName.ToLower() == model.userName.ToLower() && Crypter.CheckPassword(p.Password, model.password)));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                    return Ok(false);
                }
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult> Create(UserModel userModel)
        {
            using (var context = new MegaHackContext())
            {
                try
                {

                    if ((Models.FlyWeight.Type)userModel.Type == Models.FlyWeight.Type.Professional)
                    {
                        var user = new Professional(userModel.UserName, userModel.Password, userModel.Email);
                        user.Name = userModel.Name;
                        user.Gender = (Gender)userModel.Gender;
                        user.Type = (Models.FlyWeight.Type)userModel.Type;
                        user.Phone = userModel.Phone;
                        user.DateBirth = userModel.DateBirth;

                        user.CRP = userModel.CRP;
                        user.Specialty = (Specialty)userModel.Specialty;
                        user.CareerTime = userModel.CareerTime;
                        
                        await context.Professional.AddAsync(user);

                    }
                    else if((Models.FlyWeight.Type)userModel.Type == Models.FlyWeight.Type.Patient)
                    {
                        var user = new Patient(userModel.UserName, userModel.Password, userModel.Email);
                        user.Name = userModel.Name;
                        user.Gender = (Gender)userModel.Gender;
                        user.Type = (Models.FlyWeight.Type)userModel.Type;
                        user.Phone = userModel.Phone;
                        user.DateBirth = userModel.DateBirth;

                        await context.Patient.AddAsync(user);
                    }
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
        public async Task<ActionResult> Delete(UserModel userModel)
        {
            using (var context = new MegaHackContext())
            {
                try
                {
                    var user = context.User.Where(u => u.Id == userModel.Id).First();

                    context.User.Remove(user);

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

        [HttpGet()]
        public async Task<ActionResult> Get()
        {
            using (var context = new MegaHackContext())
            {
                try
                {
                    var users = context.User.Select(u => u);


                    return Ok(users.ToArray());

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                    return Ok(false);
                }
            }
        }

        [HttpPost("setPatient")]
        public async Task<ActionResult> SetPatient(ProfessionalModel professionalModel)
        {
            using (var context = new MegaHackContext())
            {
                try
                {
                    var patient = context.Patient.Where(u => u.Id == professionalModel.IdPatient).First();
                    var professional = context.Professional.Where(u => u.Id == professionalModel.IdProfessional).First();

                    professional.Patients.Add(patient);

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

        [HttpGet("getListPatient")]
        public async Task<ActionResult> GetListPatient(ProfessionalModel professionalModel)
        {
            using (var context = new MegaHackContext())
            {
                try
                {
                    var professionalPatiens = context.Professional.Where(u => u.Id == professionalModel.IdProfessional).Select(p => p.Patients).ToList().FirstOrDefault();
                    var patients = professionalPatiens.Select(p => p);


                    return Ok(patients.ToArray());
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
