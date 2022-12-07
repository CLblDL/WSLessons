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

namespace WSLessons
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private Contract _curentContract = new Contract();
        public AddEditPage(Contract selectedContract)
        {
            InitializeComponent();
            if (selectedContract != null)
            {
                _curentContract = selectedContract;
            }
            DataContext = _curentContract;
            ComboRaw.ItemsSource = PataoDodikEntities1.GetContext().Raw.ToList();
            ComboCountry.ItemsSource = PataoDodikEntities1.GetContext().Country.ToList();
        }

        private void ButnSaveBd_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_curentContract.ContractNumber))
            {
                errors.AppendLine("Введите номер договора");
            }
            if (string.IsNullOrWhiteSpace(_curentContract.RecipientCoumpany))
            {
                errors.AppendLine("Введите имя получателя");
            }
            if (string.IsNullOrWhiteSpace(_curentContract.SupplierCompany))
            {
                errors.AppendLine("Введите имя поставщика");
            }
            if (string.IsNullOrWhiteSpace(_curentContract.Sum.ToString()))
            {
                errors.AppendLine("Введите сумму");
            }
            if (string.IsNullOrWhiteSpace(_curentContract.Country.ToString()))
            {
                errors.AppendLine("Выберите страну");
            }
            if (string.IsNullOrWhiteSpace(_curentContract.Raw.ToString()))
            {
                errors.AppendLine("Выберите материал");
            }

            if(errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if(_curentContract.Id == 0)
            {
                PataoDodikEntities1.GetContext().Contract.Add(_curentContract);
            }

            try
            {
                PataoDodikEntities1.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
