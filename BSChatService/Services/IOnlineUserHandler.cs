using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace BSChatService.Services
{
    public interface IOnlineUserHandler
    {
        public Task CreateOnlineUserAsync(HubCallerContext context);
        public Task RemoveOnlineUser(HubCallerContext context);
    }
}
