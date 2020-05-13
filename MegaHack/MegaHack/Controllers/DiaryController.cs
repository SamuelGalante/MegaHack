using MegaHack.Context;
using MegaHack.Entity;
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
    public class DiaryController : ControllerBase
    {
        [HttpPost("create")]
        public async Task<ActionResult> Create(DiaryModel diaryModel)
        {
            using (var context = new MegaHackContext())
            {
                try
                {
                    var diary = new Diary();

                    diary.Date = diaryModel.Date;
                    diary.Description = diaryModel.Description;

                    await context.Diary.AddAsync(diary);
                    await context.SaveChangesAsync();

                    return Ok(diary.Id);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return Ok(false);

                }
            }
        }

        [HttpGet()]
        public async Task<ActionResult> Get(DiaryModel diaryModel)
        {
            using (var context = new MegaHackContext())
            {
                try
                {
                    var diary = context.Diary.Where(d => d.Id == diaryModel.Id).FirstOrDefault();
                   
                    return Ok(diary);
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
