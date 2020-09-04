using StrongGrid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmailService.API.Models
{
    public class SendEmailDescriptor
    {
        public MailAddress to { get; set; }
        public MailAddress from { get; set; }
        public string subject { get; set; }
        public string htmlContent { get; set; }
        public string textContent { get; set; }
    }
}
