using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Entities;

namespace DataManager.Contracts
{
    public interface IOnlineUserManager
    {
        public Task<OnlineUser> CreateOnlineUser(OnlineUser onlineUser);
        public Task<OnlineUser> UpdateOnlineUser(OnlineUser onlineUser);
        public Task DeleteOnlineUser(OnlineUser onlineUser);
        public Task<ICollection<OnlineUser>> GetOnlineUserList();
        public Task<OnlineUser> GetOnlineUserById(int id);
    }
}
