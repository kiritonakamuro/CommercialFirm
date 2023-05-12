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
using CommercialFirm.Views;

namespace CommercialFirm
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            NavigationClass.frmNav = FrmMain;
        }

        private void BtnClients_Click(object sender, RoutedEventArgs e)
        {
            NavigationClass.frmNav.Navigate(new ClientsPage());
        }

        private void BtnSuppliers_Click(object sender, RoutedEventArgs e)
        {
            NavigationClass.frmNav.Navigate(new SuppliersPage());
        }

        private void BtnModels_Click(object sender, RoutedEventArgs e)
        {
            NavigationClass.frmNav.Navigate(new ModelsPage());
        }
    }
}
