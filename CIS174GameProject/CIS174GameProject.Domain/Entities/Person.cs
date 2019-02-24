using System;
using System.ComponentModel.DataAnnotations;

namespace CIS174GameProject.Domain.Entities
{
    public class Person
    {
        public Guid PersonId { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        public int Gender { get; set; }

        public DateTime? DateCreated { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(16)]
        public string PhoneNumber { get; set; }
    }
}
