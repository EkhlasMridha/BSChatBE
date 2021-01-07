using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using BSChatService.Services;
using Microsoft.AspNetCore.Authorization;

namespace BSChatService.Hubs
{
    [Authorize]
    public class BSChatBaseHub:Hub<IMessageHandler>
    {
        /*private IOnlineUserHandler _onlineUserHandler;
        public BSChatBaseHub(IOnlineUserHandler onlineUserHandler)
        {
            _onlineUserHandler = onlineUserHandler;
        }*/

        /*public async override Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();

            //await _onlineUserHandler.CreateOnlineUserAsync(Context);
        }

        public async override Task OnDisconnectedAsync(Exception exception)
        {
            await base.OnDisconnectedAsync(exception);

           // await _onlineUserHandler.RemoveOnlineUser(Context);
        }*/
    }
}
