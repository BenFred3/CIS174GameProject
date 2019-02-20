using CIS174GameProject.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace CIS174GameProject.Models
{
    public class CreatePersonModel
    {
        public Guid PersonId { get; set; }
        [Required]
        [Display(Name = "First Name: ")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name: ")]
        public string LastName { get; set; }
        [Range(0,2, ErrorMessage ="Invalid Gender Number")]
        [Display(Name = "Gender: (0 - Male, 1 - Female, 2 - Other)")]
        public GenderEnum Gender { get; set; }
        public DateTime? DateCreated { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email: ")]
        public string Email { get; set; }
        [RegularExpression(@"/^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$/", ErrorMessage = "Invalid Phone Number")]
        [Display(Name = "Phone Number: ")]
        public string PhoneNumber { get; set; }
    }
 }