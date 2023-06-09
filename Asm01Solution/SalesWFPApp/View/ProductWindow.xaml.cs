using AutoMapper;
using BusinessLayer.BusinessObject;
using BusinessLayer.Services;
using BusinessObject.Configuration;
using DataAccess.Models;
using DataAccess.Repository;
using Microsoft.Extensions.DependencyInjection;
using SalesWFPApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SalesWFPApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ProductWindow : Window
    {
        public ProductWindow()
        {
            InitializeComponent();
            var productViewModel = ((App)Application.Current).ServiceProvider.GetRequiredService<ProductViewModel>();
            DataContext = productViewModel;
        }
    }
}
