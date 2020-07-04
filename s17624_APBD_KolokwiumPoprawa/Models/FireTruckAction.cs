using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace s17624_APBD_KolokwiumPoprawa.Models
{
    public class FireTruckAction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdFireTruckAction { get; set; }
        [ForeignKey("FireTruck")]
        public int IdFireTruck { get; set; }
        public virtual FireTruck FireTruck { get; set; }
        [ForeignKey("Action")]
        public int IdAction { get; set; }
        public virtual Action Action { get; set; }
        public DateTime AssigmentDate { get; set; }

    }
}
