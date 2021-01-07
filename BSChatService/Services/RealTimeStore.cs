using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManager.Contracts;

namespace BSChatService.Services
{
    class RealTimeStore : IRealTimeStore
    {
        private IOnlineUserManager _onlineUserManager;

        public RealTimeStore(IOnlineUserManager onlineUserManager)
        {
            _onlineUserManager = onlineUserManager;
        }
        public async Task CreateUser(OnlineUser onlineUser)
        {
           await _onlineUserManager.CreateOnlineUser(onlineUser);
        }

        public async Task<OnlineUser> GetOnlineUserAsync(int id)
        {
            var result = await _onlineUserManager.GetOnlineUserById(id);
            return result;
        }

        public async Task SetUserToOffLine(OnlineUser onlineUser)
        {
            await _onlineUserManager.DeleteOnlineUser(onlineUser);
        }

        public async Task UpdateOnlineUser(OnlineUser onlineUser)
        {
            await _onlineUserManager.UpdateOnlineUser(onlineUser);
        }
    }
}
