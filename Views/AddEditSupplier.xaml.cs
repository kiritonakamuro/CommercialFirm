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
    /// Логика взаимодействия для AddEditSupplier.xaml
    /// </summary>
    public partial class AddEditSupplier : Page
    {
        private Supplier _currentSupplier = new Supplier();
        public AddEditSupplier(Supplier selectedSupplier)
        {
            InitializeComponent();
            if (selectedSupplier != null)
                _currentSupplier = selectedSupplier;
            DataContext = _currentSupplier;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentSupplier.Name))
                errors.AppendLine("Укажите фирму");
            if (string.IsNullOrWhiteSpace(_currentSupplier.NumberPhone))
                errors.AppendLine("Укажите номер телефона");
            if (string.IsNullOrWhiteSpace(_currentSupplier.Email))
                errors.AppendLine("Укажите e-mail");
            if (string.IsNullOrWhiteSpace(_currentSupplier.Website))
                errors.AppendLine("Укажите сайт");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentSupplier.id == 0)
                Commercial_FirmEntities.GetContext().Supplier.Add(_currentSupplier);

            try
            {
                Commercial_FirmEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
                NavigationClass.frmNav.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
