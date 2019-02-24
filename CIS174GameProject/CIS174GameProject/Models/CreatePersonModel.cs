using CIS174GameProject.Shared.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace CIS174GameProject.Models
{
    public class CreatePersonModel
    {
        public Guid PersonId { get; set; }
        [Display(Name = "First Name: ")]
        [Required]
        public string FirstName { get; set; }
        [Display(Name = "Last Name: ")]
        [Required]
        public string LastName { get; set; }
        [Display(Name = "Gender: (0 - Male, 1 - Female, 2 - Other)")]
        [Range(0,2, ErrorMessage ="Invalid Gender Number")]
        public GenderEnum Gender { get; set; }
        public DateTime? DateCreated { get; set; }
        [Display(Name = "Email: ")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name = "Phone Number: ")]
        [RegularExpression(@"/^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$/", ErrorMessage = "Invalid Phone Number")]
        public string PhoneNumber { get; set; }
    }
 }