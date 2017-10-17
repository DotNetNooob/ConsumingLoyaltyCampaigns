using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsumeAPIFromMVC.Helpers
{
    public class EmailConfiguration
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SmtpClient { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsSslEnabled { get; set; }
        public bool IsDefault { get; set; }
    }
}