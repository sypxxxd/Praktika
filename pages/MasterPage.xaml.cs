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

namespace Vova.pages
{
    /// <summary>
    /// Логика взаимодействия для MasterPage.xaml
    /// </summary>
    public partial class MasterPage : Page
    {
        Model1 context;
        public MasterPage(Model1 _cont)
        {
            InitializeComponent();
            context = _cont;
            masterData.ItemsSource = context.Worker.ToList();
            StatusMasterBox.ItemsSource = context.Worker.ToList();
            var statusList = _cont.Status.ToList();
            statusList.Insert(0, new Status() { Title = "Все" });
            StatusMasterBox.ItemsSource = statusList;
            StatusMasterBox.SelectedIndex = 0;
        }
        void FilterData()
        {
            var list = context.Worker.ToList();
            if (StatusMasterBox.SelectedIndex != 0)
            {
                Status status = StatusMasterBox.SelectedItem as Status;
                list = list.Where(x => x.status == status.Title).ToList();
            }
            if (!string.IsNullOrWhiteSpace(EnterFIO.Text))
            {
                list = list.Where(x => x.FIO.Contains(EnterFIO.Text)).ToList();
            }

            masterData.ItemsSource = list;

        }
        private void AddMasterClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddMasterPage(context));
        }
        private void UpdateClick(object sender, RoutedEventArgs e)
        {
            Worker mast = (sender as Hyperlink).DataContext as Worker;
            NavigationService.Navigate(new AddMasterPage(context, mast));
        }
        private void RemoveClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы уточно хотите удалить мастера?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    Worker ing = (sender as Hyperlink).DataContext as Worker;
                    context.Worker.Remove(ing);
                    context.SaveChanges();
                    masterData.ItemsSource = context.Worker.ToList();
                }
                catch
                {
                    MessageBox.Show("Ошибка!");
                }
            }
        }
        private void SearchChanged(object sender, RoutedEventArgs e)
        {
            FilterData();
        }
        private void StatusChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterData();
        }
    }
}
