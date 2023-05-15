using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private ObservableCollection<Client> filteredClients;
        private ObservableCollection<Client> clients;
        public ClientsPage()
        {
            InitializeComponent();
            clients = new ObservableCollection<Client>(DBConnect.connectDB.Client.ToList());
            filteredClients = clients;
            GridListClients.ItemsSource = filteredClients;
            GridListClients.CanUserAddRows = false;

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

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var clientsForRemoving = GridListClients.SelectedItems.Cast<Client>().ToList();

            if(MessageBox.Show($"Вы точно хотите удалить следующие {clientsForRemoving.Count()} элементов?" , "Внимание" , 
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Commercial_FirmEntities.GetContext().Client.RemoveRange(clientsForRemoving);
                    Commercial_FirmEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    GridListClients.ItemsSource = Commercial_FirmEntities.GetContext().Client.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void TxbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                string searchText = TxbSearch.Text.ToLower();

                if (string.IsNullOrEmpty(searchText))
                {

                    filteredClients = clients;
                }
                else
                {

                    filteredClients = new ObservableCollection<Client>(
                        clients.Where(x =>
                            x.Surname.ToLower().Contains(searchText) ||
                            x.Name.ToLower().Contains(searchText) ||
                            x.Patronymic.ToLower().Contains(searchText) ||
                            x.Address.ToLower().Contains(searchText) ||
                            x.NumberPhone.ToLower().Contains(searchText) ||
                            x.Model.Name.ToString().ToLower().Contains(searchText)
                        )
                    );
                }

                GridListClients.ItemsSource = filteredClients;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(),
                    "Критическая ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GridListClients.ItemsSource = new ObservableCollection<Client>(DBConnect.connectDB.Client.ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(),
                    "Критическая ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }

    }
}
