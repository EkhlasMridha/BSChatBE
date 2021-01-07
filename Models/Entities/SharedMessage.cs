using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Entities
{
    public class SharedMessage
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public int GroupId { get; set; }
        public string SentMessage { get; set; }
        public DateTime SentTime { get; set; }
    }
}
