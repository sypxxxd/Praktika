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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        Window Window;
        Model1 _context;
        public MainPage(Model1 cont, Window win)
        {
            InitializeComponent();
            Window = win;
            _context = cont;
        }
       // private void Show_Devices(object sender, RoutedEventArgs e)
       // {
       //     frameToBasePages.Navigate(new RepairPage(_context));
       // }
        private void Show_Master(object sender, RoutedEventArgs e)
        {
            frameToBasePages.Navigate(new MasterPage(_context));
        }
        private void ExitClick(object sender, RoutedEventArgs e)
        {
            Window.Close();
        }

        private void ClientPage(object sender, RoutedEventArgs e)
        {
            frameToBasePages.Navigate(new ClientPage(_context));
        }
    }
}
