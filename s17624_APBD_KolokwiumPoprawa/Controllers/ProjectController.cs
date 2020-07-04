using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using s17624_APBD_KolokwiumPoprawa.Services;

namespace s17624_APBD_KolokwiumPoprawa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IDbService dbService;

        public ProjectController(IDbService dbService)
        {
            this.dbService = dbService;
        }
    }
}