using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using s17624_APBD_KolokwiumPoprawa.Models;

namespace s17624_APBD_KolokwiumPoprawa.Services
{
    public class EfDbService : IDbService
    {
        private readonly ProjectDbContext dbContext;

        public EfDbService(ProjectDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
