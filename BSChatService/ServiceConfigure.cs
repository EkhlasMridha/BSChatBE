using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using BSChatService.Services;
using Microsoft.AspNetCore.SignalR;
using BSChatService.Configs;

namespace BSChatService
{
    public static class ServiceConfigure
    {
        public static void AddBSChatService(this IServiceCollection services)
        {
            services.AddScoped<IRealTimeStore, RealTimeStore>();
            services.AddScoped<IOnlineUserHandler, OnlineUserHandler>();

            services.AddSignalR();
            services.AddSingleton<IUserIdProvider, UserIdProvider>();
        }
    }
}
