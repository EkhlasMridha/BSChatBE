using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Entities;

namespace BSChatService.Services
{
    class OnlineUserHandler : IOnlineUserHandler
    {
        private IRealTimeStore _realTimeStore;
        public OnlineUserHandler(IRealTimeStore realTimeStore)
        {
            _realTimeStore = realTimeStore;
        }
        public async Task CreateOnlineUserAsync(HubCallerContext context)
        {
            var userID = context.User.Claims.FirstOrDefault(c => c.Type == "userid")?.Value;
            int id = Int32.Parse(userID);
            var connectionId = context.ConnectionId;

            var onlineUser = await _realTimeStore.GetOnlineUserAsync(id);

            bool online = await IsOnline(onlineUser);

            if (!online)
            {
                onlineUser = new OnlineUser
                {
                    UserId = id,
                    ConnectionId = connectionId
                };
                await _realTimeStore.CreateUser(onlineUser);
            }
            else
            {
                onlineUser.ConnectionId = connectionId;
                await _realTimeStore.UpdateOnlineUser(onlineUser);
            }
        }

        public async Task RemoveOnlineUser(HubCallerContext context)
        {
            var userID = context.User.Claims.FirstOrDefault(c => c.Type == "userid")?.Value;
            int id = Int32.Parse(userID);

            var onlineUser = await _realTimeStore.GetOnlineUserAsync(id);

            if (onlineUser != null)
            {
               await _realTimeStore.SetUserToOffLine(onlineUser);

            }
        }

        private async Task<bool> IsOnline(OnlineUser onlineUserModel)
        {
            if (onlineUserModel != null)
            {
                return await Task.FromResult(true);
            }

            return await Task.FromResult(false);
        }
    }
}
