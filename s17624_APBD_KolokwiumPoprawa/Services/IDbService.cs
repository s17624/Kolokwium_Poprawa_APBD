using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using s17624_APBD_KolokwiumPoprawa.DTOs.Requests;
using s17624_APBD_KolokwiumPoprawa.DTOs.Responses;

namespace s17624_APBD_KolokwiumPoprawa.Services
{
    public interface IDbService
    {
        public ICollection<FirefighterActionsDTO> GetFirefighterActions(int id);

        public void AssignFireTruckToAction(FireTruckToActionDTO request);
    }
}
