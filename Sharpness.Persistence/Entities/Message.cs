using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpness.Persistence.Entities
{
    public class Message
    {
        public Message()
        {
            MessageId = System.Guid.NewGuid();
            Creation = DateTime.Now;
        }

        [Key]
        public Guid MessageId { get; set; }
        public string From { get; set; }
        public string To { get; set; }

        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime Creation { get; set; }
    }
}
