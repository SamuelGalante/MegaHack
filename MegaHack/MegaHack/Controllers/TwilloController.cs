
using MegaHack.Context;
using MegaHack.Entity.User;
using MegaHack.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Twilio;
using Twilio.AspNet.Common;
using Twilio.AspNet.Mvc;
using Twilio.Rest.Api.V2010.Account;
using Twilio.TwiML;

namespace MegaHack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class TwilloController : ControllerBase
    {
        [HttpPost("sendEmergencyMessage")]
        public async Task<ActionResult> SendMessage(UserModel userModel)
        {
            using (var context = new MegaHackContext())
            {
                try
                {
                    var patient = context.Patient.Where(p => p.Id == userModel.Id).FirstOrDefault();

                var professionals = context.Professional.Where(p => p.Patients.Contains(patient)).ToList();

                TwilioClient.Init("AC0dbc1caba6d2ff26d915796a0ae581c0", "b717f4c11dc57234ff4671fefbf2e54a");

                foreach (var prof in professionals)
                {
                    MessageResource.Create(
                       body: "Seu paciente "+patient.Name+" esta com uma emergêcia. Por favor entre em contato no número: "+patient.Phone,
                       from: new Twilio.Types.PhoneNumber("+12057548800"),
                       to: new Twilio.Types.PhoneNumber(prof.Phone));

                }
                    return Ok(true);
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
