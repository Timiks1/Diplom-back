using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityACS.Core.Entities
{
    public class ChatMessage
    {
        public Guid Id { get; set; }
        public string Message { get; set; } = string.Empty;
        public Guid SenderId { get; set; }
        public ApplicationUser Sender { get; set; }
        public Guid ReceiverId { get; set; }
        public ApplicationUser Receiver { get; set; }
        public DateTime TimeCreation { get; set; } = DateTime.Now;
    }
}
