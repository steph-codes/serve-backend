using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serve.Domain.DataTransferObjects
{
    public class CustomerDto
    {
        public int Id { get; set;}
        [Required(ErrorMessage = "Name is required")]
        public string CustomerName { get; set;}
        [Required(ErrorMessage = "Customers Name is required")]
        public string CustomerEmail { get; set;}
        [Required(ErrorMessage = "Customer's Email is required")]
        public string? PhoneNumber { get; set;}
        [Required(ErrorMessage = "Phone number is required")]
        public short? Gender { get; set; }
    }
}
