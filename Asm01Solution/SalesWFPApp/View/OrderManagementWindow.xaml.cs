﻿using Microsoft.Extensions.DependencyInjection;
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
using System.Windows.Shapes;

namespace SalesWFPApp.View
{
    /// <summary>
    /// Interaction logic for OrderManagementWindow.xaml
    /// </summary>
    public partial class OrderManagementWindow : Window
    {
        public OrderManagementWindow()
        {
            InitializeComponent();
            var orderViewModel = ((App)Application.Current).ServiceProvider.GetRequiredService<OrderViewModel>();
            DataContext = orderViewModel;
            EventAggregator.Instance.Subscribe("CloseOrderMgmtWindow", p => { Close(); });
        }
    }
}
