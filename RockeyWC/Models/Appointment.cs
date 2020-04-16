using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace RockeyWC.Models
{
    public class Appointment
    {
        public int AppointmentID { get; set; }
        public int AccountID { get; set; }
        public System.DateTime AppointmentTime { get; set; }
    }
}
