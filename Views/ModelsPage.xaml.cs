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
    /// Логика взаимодействия для ModelsPage.xaml
    /// </summary>
    public partial class ModelsPage : Page
    {
        private ObservableCollection<Model> filteredModels;
        private ObservableCollection<Model> models;
        public ModelsPage()
        {
            InitializeComponent();

        }

        private void AddModel_Click(object sender, RoutedEventArgs e)
        {
            NavigationClass.frmNav.Navigate(new AddEditModel());

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Commercial_FirmEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                GridListModels.ItemsSource = Commercial_FirmEntities.GetContext().Model.ToList();
            }
        }

        private void TxbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
