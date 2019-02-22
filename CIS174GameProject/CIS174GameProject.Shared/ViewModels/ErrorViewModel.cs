using System;

namespace CIS174GameProject.Shared.ViewModels
{
    public class ErrorViewModel
    {
        public Guid ErrorId { get; set; }
        public DateTime? ErrorDate { get; set; }
        public string ErrorMessage { get; set; }
        public string StackTrace { get; set; }
        public string InnerExceptions { get; set; }
    }
}
