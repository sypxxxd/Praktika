using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Логика взаимодействия для ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        Model1 context;
        public ClientPage(Model1 cont)
        {
            InitializeComponent();
            context = cont;
            listClient.ItemsSource = cont.Client.ToList();
        }
        void FilterData()
        {
            var list = context.Client.ToList();
            if (!string.IsNullOrWhiteSpace(searchBox.Text))
            {
                list = list.Where(x => x.name.Contains(searchBox.Text)).ToList();
            }

            listClient.ItemsSource = list;

        }
        private void SearchChange(object sender, TextChangedEventArgs e)
        {
            FilterData();
        }
    }
}
