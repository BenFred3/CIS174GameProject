using CIS174GameProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIS174GameProject.Models
{
    public class UpdatePersonModel
    {
        public Guid PersonId { get; set; }
        
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public GenderEnum Gender { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}