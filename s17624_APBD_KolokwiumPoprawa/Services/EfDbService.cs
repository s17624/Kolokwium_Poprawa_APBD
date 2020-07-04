using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using s17624_APBD_KolokwiumPoprawa.DTOs.Responses;
using s17624_APBD_KolokwiumPoprawa.Migrations;
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

        public ICollection<FirefighterActionsDTO> GetFirefighterActions(int id)

        {
            var check = dbContext.Actions.Where(a => a.IdAction == id).FirstOrDefault();

            if (check == null)
            {
                return null;
            }


            var query = dbContext.FirefighterActions
                .Include(a => a.Action)
                .Where(fa => fa.IdFirefighter == id)
                .ToList();


            ICollection<FirefighterActionsDTO> result = new List<FirefighterActionsDTO>();
            foreach (var record in query)
            {
                result.Add(new FirefighterActionsDTO()
                {
                    IdAction = record.IdAction,
                    StartTime = record.Action.StartTime,
                    EndTime = record.Action.EndTime
                });
            }

            return(result);
        }

        public void AssignFireTruckToAction()
        {
            throw new NotImplementedException();
        }
    }
}
