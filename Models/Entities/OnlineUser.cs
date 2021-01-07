using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Entities
{
    public class OnlineUser
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ConnectionId { get; set; }
    }
}
