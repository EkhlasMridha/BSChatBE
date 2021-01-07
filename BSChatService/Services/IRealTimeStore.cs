using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Entities;

namespace BSChatService.Services
{
    public interface IRealTimeStore
    {
        public Task<OnlineUser> GetOnlineUserAsync(int id);
        public Task CreateUser(OnlineUser onlineUser);
        public Task UpdateOnlineUser(OnlineUser onlineUser);
        public Task SetUserToOffLine(OnlineUser onlineUser);
    }
}
