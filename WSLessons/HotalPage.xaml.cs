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
    /// Логика взаимодействия для HotalPage.xaml
    /// </summary>
    public partial class HotalPage : Page
    {
        public HotalPage()
        {
            InitializeComponent();
            DGridHotel.ItemsSource = PataoDodikEntities1.GetContext().Contract.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage(null));
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage((sender as Button).DataContext as Contract));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var contractForRemoving = DGridHotel.SelectedItems.Cast<Contract>().ToList();

            if (MessageBox.Show($"Вы точно хоите удалить следущие {contractForRemoving.Count()} элементов?", "Внимание!"
                , MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    PataoDodikEntities1.GetContext().Contract.RemoveRange(contractForRemoving);
                    PataoDodikEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DGridHotel.ItemsSource = PataoDodikEntities1.GetContext().Contract.ToList();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void DGridHotel_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                PataoDodikEntities1.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridHotel.ItemsSource = PataoDodikEntities1.GetContext().Contract.ToList();
            }
        }
    }
}
