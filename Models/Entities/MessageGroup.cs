using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class MessageGroup
    {
        public MessageGroup()
        {
            TextMessages = new HashSet<TextMessage>();
        }

        public int Id { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }

        public ICollection<TextMessage> TextMessages { get; set; }
        //public Person Name { get; set; }
    }
}
