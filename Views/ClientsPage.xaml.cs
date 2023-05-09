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
            GridListClients.ItemsSource = DBConnect.connectDB.Client.ToList();
        }

        private void AddClient_Click(object sender, RoutedEventArgs e)
        {
            NavigationClass.frmNav.Navigate(new AddEditClient());
        }
    }
}
