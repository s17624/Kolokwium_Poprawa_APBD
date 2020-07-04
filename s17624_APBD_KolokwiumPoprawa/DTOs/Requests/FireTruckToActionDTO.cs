using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace s17624_APBD_KolokwiumPoprawa.DTOs.Requests
{
    public class FireTruckToActionDTO
    {
        [Required] 
        public int IdAction { get; set; }
        [Required]
        public int IdFireTruck { get; set; }

    }
}
