using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace s17624_APBD_KolokwiumPoprawa.Models
{
    public class FirefighterAction
    {
        [ForeignKey("FireFighter")]
        public int IdFirefighter { get; set; }

        public virtual Firefighter Firefighter { get; set; }

        [ForeignKey("Action")]
        public int IdAction { get; set; }

        public virtual Action Action { get; set; }
    }
}
