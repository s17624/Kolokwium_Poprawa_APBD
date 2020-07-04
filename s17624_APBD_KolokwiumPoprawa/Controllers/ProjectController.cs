using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using s17624_APBD_KolokwiumPoprawa.Services;

namespace s17624_APBD_KolokwiumPoprawa.Controllers
{
    [Route("api/firefighters")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IDbService dbService;

        public ProjectController(IDbService dbService)
        {
            this.dbService = dbService;
        }

        [HttpGet]
        [Route("/{id:int}/actions")]
        public IActionResult GetActions(int id)
        {
            var response = dbService.GetFirefighterActions(id);
            if (response == null)
            {
                return BadRequest("Action does not exists!");
            }
            return Ok();
        }
    }
}