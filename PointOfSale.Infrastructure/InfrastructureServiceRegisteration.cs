using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentFTP;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PointOfSale.Application.Contracts.Infrastructure.Files;
using PointOfSale.Application.Models.Files;
using PointOfSale.Infrastructure.Files;

namespace PointOfSale.Infrastructure
{
    public static class InfrastructureServiceRegisteration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            StorageClientSettings formatSettings = configuration.GetSection("AppFileStorageSettings").Get<StorageClientSettings>();
            services.AddSingleton(formatSettings);
            services.AddScoped<IFtpClient, FtpClient>(op =>
            {
                var remoteServer = StoragesSettings.GetInstance().ClientsSettings.First();
                var client = new FtpClient(remoteServer.StorageUrl, remoteServer.UserName, remoteServer.Password);
                client.Connect();
                return client;
            });
            services.AddScoped<IAsyncFtpClient, AsyncFtpClient>(op =>
            {
                var remoteServer = StoragesSettings.GetInstance().ClientsSettings.First();
                var client = new AsyncFtpClient(remoteServer.StorageUrl, remoteServer.UserName, remoteServer.Password);
                client.Connect();
                return client;
            });
            services.AddTransient<IRemoteStorageClient, RemoteStorageClient>();
            services.AddTransient<ILocalStorageClient, LocalStorageClient>();




            return services;
        }
    }
}
