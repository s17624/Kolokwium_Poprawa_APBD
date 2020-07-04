using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using s17624_APBD_KolokwiumPoprawa.DTOs.Requests;
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
                .OrderByDescending(a => a.Action.EndTime)
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

        public void AssignFireTruckToAction(FireTruckToActionDTO request)
        {
            var eq = dbContext.Actions.Where(a => a.IdAction == request.IdAction && a.EndTime == null).FirstOrDefault();

            if (eq == null)
            {
                throw new Exception("Action doesn't exists or is closed");
            }
            int ifNeededSpecialEq = eq.NeedSpecialEquipment;





            var truck = dbContext.FireTrucks
                .Include(fa => fa.FireTruckActions)
                .ThenInclude(a => a.Action)
                .Where(ft => ft.IdFireTruck == request.IdFireTruck && ft.SpecialEquipment == ifNeededSpecialEq)
                .FirstOrDefault();

            if (truck == null)
            {
                throw new Exception("Truck doesn't have special equipment or doesn't exists!");
            }

            foreach (var rec in truck.FireTruckActions)
            {
                if (rec.Action.EndTime == null)
                {
                    throw new Exception("Truck already assigned to action!");
                }
            }



            dbContext.Attach(new FireTruckAction()
            {
                IdFireTruck = request.IdFireTruck,
                IdAction = request.IdAction,
                AssigmentDate = DateTime.Now
            });
            dbContext.SaveChanges();
        }
    }
}
