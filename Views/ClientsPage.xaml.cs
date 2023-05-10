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
using CommercialFirm.Classes;
using CommercialFirm.Models;

namespace CommercialFirm.Views
{
    /// <summary>
    /// Логика взаимодействия для ClientsPage.xaml
    /// </summary>
    public partial class ClientsPage : Page
    {
        public ClientsPage()
        {
            InitializeComponent();
            
        }

        private void AddClient_Click(object sender, RoutedEventArgs e)
        {
            NavigationClass.frmNav.Navigate(new AddEditClient(null));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Commercial_FirmEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                GridListClients.ItemsSource = Commercial_FirmEntities.GetContext().Client.ToList();
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            NavigationClass.frmNav.Navigate(new AddEditClient((sender as Button).DataContext as Client));
        }
    }
}
