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
    /// Логика взаимодействия для SuppliersPage.xaml
    /// </summary>
    public partial class SuppliersPage : Page
    {
        public SuppliersPage()
        {
            InitializeComponent();
        }

        private void BtnAddSupplier_Click(object sender, RoutedEventArgs e)
        {
            NavigationClass.frmNav.Navigate(new AddEditSupplier(null));
        }

        private void BtnDeleteSupplier_Click(object sender, RoutedEventArgs e)
        {
            var suppliersForRemoving = GridListSuppliers.SelectedItems.Cast<Supplier>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {suppliersForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Commercial_FirmEntities.GetContext().Supplier.RemoveRange(suppliersForRemoving);
                    Commercial_FirmEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    GridListSuppliers.ItemsSource = Commercial_FirmEntities.GetContext().Supplier.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnEditSupplier_Click(object sender, RoutedEventArgs e)
        {
            NavigationClass.frmNav.Navigate(new AddEditSupplier((sender as Button).DataContext as Supplier));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Commercial_FirmEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                GridListSuppliers.ItemsSource = Commercial_FirmEntities.GetContext().Supplier.ToList();
            }
        }
    }
}
