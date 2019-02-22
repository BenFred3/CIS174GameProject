using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS174GameProject.Domain.Entities
{
    public class Error
    {
        public Guid ErrorId { get; set; }

        public DateTime? ErrorDate { get; set; }

        public string ErrorMessage { get; set; }

        public string StackTrace { get; set; }

        public string InnerExceptions { get; set; }
    }
}
