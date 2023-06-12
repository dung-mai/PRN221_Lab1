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
using System.Windows.Shapes;

namespace SalesWFPApp.View
{
    /// <summary>
    /// Interaction logic for AddOrderItemWindow.xaml
    /// </summary>
    public partial class AddOrderItemWindow : Window
    {
        public AddOrderItemWindow()
        {
            InitializeComponent();
            var addOrderItemViewModel = ((App)Application.Current).ServiceProvider.GetRequiredService<AddOrderItemViewModel>();
            DataContext = addOrderItemViewModel;
            EventAggregator.Instance.Subscribe("CloseAddCartWindow", p => { Close(); });
        }
    }
}
