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

namespace SalesWFPApp.View
{
    /// <summary>
    /// Interaction logic for MenuBar.xaml
    /// </summary>
    public partial class MenuBar : UserControl
    {
        public MenuBar()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var productWindow = new ProductWindow();
            productWindow.Show();
            var mainWindow = Window.GetWindow(this);
            if (mainWindow != null)
            {
                mainWindow.Close();
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            var memberWindow = new MemberWindow();
            memberWindow.Show();
            var mainWindow = Window.GetWindow(this);
            if (mainWindow != null)
            {
                mainWindow.Close();
            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            var orderWindow = new OrderManagementWindow();
            orderWindow.Show();
            var mainWindow = Window.GetWindow(this);
            if (mainWindow != null)
            {
                mainWindow.Close();
            }
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            //var orderDetailWindow = new OrderDetailWindow();
            //orderDetailWindow.Show();
            //var mainWindow = Window.GetWindow(this);
            //if (mainWindow != null)
            //{
            //    mainWindow.Close();
            //}
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            var loginWindow = new LoginWindow();
            loginWindow.Show();
            var mainWindow = Window.GetWindow(this);
            if (mainWindow != null)
            {
                mainWindow.Close();
            }
        }
    }
}
