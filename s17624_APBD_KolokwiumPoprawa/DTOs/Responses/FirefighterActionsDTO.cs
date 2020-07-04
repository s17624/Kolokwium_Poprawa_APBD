using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace s17624_APBD_KolokwiumPoprawa.DTOs.Responses
{
    public class FirefighterActionsDTO
    {
        public int IdAction { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
