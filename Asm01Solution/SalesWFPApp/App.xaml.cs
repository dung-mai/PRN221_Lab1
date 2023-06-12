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
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SalesWFPApp.View;

namespace SalesWFPApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;
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
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<IMemberRepository, MemberRepository>();

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IMemberService, MemberService>();
            services.AddScoped<IOrderDetailService, OrderDetailService>();
            services.AddScoped<IOrderService, OrderService>();

            services.AddSingleton<EventAggregator>();
            services.AddSingleton<ProductViewModel>();
            services.AddSingleton<MemberViewModel>();
            services.AddSingleton<OrderViewModel>();
            services.AddSingleton<LoginViewModel>();
            services.AddSingleton<ViewOrderDetailViewModel>();
            services.AddScoped<AddOrderItemViewModel>();
            services.AddScoped<ProgressOrderViewModel>();

        }

        //protected override void OnStartup(StartupEventArgs e)
        //{

        //    // Create and show the main window
        //    //var memberWindow = _serviceProvider.GetService<MemberWindow>();
        //    MemberWindow memberWindow = new MemberWindow();
        //    memberWindow.Show();
        //}
    }
}
