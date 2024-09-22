using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.SendGridEmail
{
    public class SendGridEmailRequestModel
    {
        public ContentEmail From { get; set; }
        public List<personalization> Personalizations { get; set; }
        public string Subject { get; set; }
        public List<ContentBody> Content { get; set; }
    }
    public class personalization   {
        
        public List<ContentEmail> To { get; set; }
    }
    public class ContentEmail
    {
        public string Email { get; set; }
        public string Name { get; set; }
    }
    public class ContentBody
    {
        public string Type { get; set; }
        public string Value { get; set; }
    }
}
