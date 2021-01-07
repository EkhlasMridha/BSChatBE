using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManager.Contracts;
using Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataManager.Managers
{
    class OnlineUserManager : IOnlineUserManager
    {
        private BSChatDBContext _bSChatDBContext;

        public OnlineUserManager(BSChatDBContext bSChatDBContext)
        {
            _bSChatDBContext = bSChatDBContext;
        }
        public async Task<OnlineUser> CreateOnlineUser(OnlineUser onlineUser)
        {
            await _bSChatDBContext.OnlineUser.AddAsync(onlineUser);
            await _bSChatDBContext.SaveChangesAsync();
            return onlineUser;
        }

        public async Task DeleteOnlineUser(OnlineUser onlineUser)
        {
            _bSChatDBContext.OnlineUser.Remove(onlineUser);
            await _bSChatDBContext.SaveChangesAsync();
        }

        public async Task<OnlineUser> GetOnlineUserById(int id)
        {
            var result = await _bSChatDBContext.OnlineUser.FirstOrDefaultAsync(on => on.UserId == id);
            return result;
        }

        public async Task<ICollection<OnlineUser>> GetOnlineUserList()
        {
            var result = await _bSChatDBContext.OnlineUser.ToListAsync();
            return result;
        }

        public async Task<OnlineUser> UpdateOnlineUser(OnlineUser onlineUser)
        {
            var online = await _bSChatDBContext.OnlineUser.FirstOrDefaultAsync(on => on.Id == onlineUser.Id);
            online.ConnectionId = onlineUser.ConnectionId;
            _bSChatDBContext.Update(online);
            await _bSChatDBContext.SaveChangesAsync();
            return online;
        }
    }
}
