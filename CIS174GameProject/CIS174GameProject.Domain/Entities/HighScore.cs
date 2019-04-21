using System;
using System.ComponentModel.DataAnnotations;

namespace CIS174GameProject.Domain.Entities
{
    public class HighScore
    {
        [Key]
        public Guid HighscoreId { get; set; }

        public Guid PersonId { get; set; }

        public string Email { get; set; }

        public decimal Score { get; set; }

        public DateTime? DateAttained { get; set; }
    }
}
