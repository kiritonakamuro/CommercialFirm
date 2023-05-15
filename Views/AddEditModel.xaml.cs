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
    /// Логика взаимодействия для AddEditModel.xaml
    /// </summary>
    public partial class AddEditModel : Page
    {
        private Model _currentModel = new Model();
        public AddEditModel()
        {
            InitializeComponent();
            DataContext = _currentModel;


            ComboSupplier.DisplayMemberPath = "Name";
            ComboSupplier.SelectedValuePath = "id";
            ComboSupplier.ItemsSource = DBConnect.connectDB.Supplier.ToList();

            ComboUpholstery.DisplayMemberPath = "Type";
            ComboUpholstery.SelectedValuePath = "Id";
            ComboUpholstery.ItemsSource = DBConnect.connectDB.Upholstery.ToList();

            ComboFuel.DisplayMemberPath = "Type";
            ComboFuel.SelectedValuePath = "Id";
            ComboFuel.ItemsSource = DBConnect.connectDB.Fuel.ToList();

            ComboTransmission.DisplayMemberPath = "Type";
            ComboTransmission.SelectedValuePath = "Id";
            ComboTransmission.ItemsSource = DBConnect.connectDB.Transmission.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Model model = new Model()
                {
                    Supplier = ComboSupplier.SelectedItem as Supplier,
                    Name = TxbNameModel.Text,
                    Color = TxbColor.Text,
                    EnginePower = TxbEP.Text,
                    Upholstery = ComboUpholstery.SelectedItem as Upholstery,
                    Transmission = ComboTransmission.SelectedItem as Transmission,
                    Fuel = ComboFuel.SelectedItem as Fuel
                };

                DBConnect.connectDB.Model.Add(model);
                DBConnect.connectDB.SaveChanges();
                MessageBox.Show("Данные успешно добавлены!",
                "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.InnerException.Message.ToString(),
                    "Критическая ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }
    }
}
