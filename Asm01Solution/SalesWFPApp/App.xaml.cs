using BusinessLayer.Services;
using BusinessObject.Configuration;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using CommunityToolkit.Mvvm.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using SalesWFPApp.ViewModel;
using DataAccess;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace SalesWFPApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider _serviceProvider;
        public ServiceProvider ServiceProvider { get { return _serviceProvider; } }

        public App()
        {
            var services = new ServiceCollection();
            ConfigurationServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigurationServices(ServiceCollection services)
        {
            // Register the DbContext as a singleton service
            services.AddDbContext<PRN221_SalesApplicationContext>(ServiceLifetime.Singleton);

            // Register AutoMapper
            services.AddAutoMapper(typeof(AutoMapperProfile)); //register with IoC & singleton service

            // Register other services (Interface..) here
            services.AddSingleton<IProductRepository, ProductRepository>();

            services.AddSingleton<IOrderRepository, OrderRepository>();
            services.AddSingleton<IOrderDetailRepository, OrderDetailRepository>();
            services.AddSingleton<IProductRepository, ProductRepository>();
            services.AddSingleton<IProductService, ProductService>();
            services.AddSingleton<IProductService, ProductService>();
            services.AddSingleton<IProductService, ProductService>();
            services.AddSingleton<IProductService, ProductService>();



            services.AddSingleton<ProductViewModel>();

        }
    }
}
