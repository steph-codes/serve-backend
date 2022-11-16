using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serve.Domain.DataTransferObjects
{
    public class AppointmentDto
    {
            public int Id { get; set; }
            [Required(ErrorMessage = "Appointment Title is required")]
            public string AppointmentTitle { get; set; }
            [Required(ErrorMessage = "Unique Url is required")]
            public string Url { get; set; }
            [Required(ErrorMessage = "Address is required")]
            public string Address { get; set; }
            [Required(ErrorMessage = "State is required")]
            public string State { get; set; }   
            

    }

   
}
