using CIS174GameProject.Shared.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace CIS174GameProject.Models
{
    public class UpdatePersonModel
    {
        public Guid PersonId { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }

        public GenderEnum Gender { get; set; }
        [StringLength(100)]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}