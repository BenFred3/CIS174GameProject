using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS174GameProject.Shared.ViewModels
{
    public class HighScoreViewModel
    {
        public Guid PersonId { get; set; }
        public decimal Score { get; set; }
        public DateTime? DateAttained { get; set; }
    }
}
