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
    /// Логика взаимодействия для AddMasterPage.xaml
    /// </summary>
    public partial class AddMasterPage : Page
    {
        Model1 context;
        Worker master;
        public AddMasterPage(Model1 c)
        {
            InitializeComponent();
            context = c;
        }
        public AddMasterPage(Model1 c, Worker mast)
        {
            InitializeComponent();
            context = c;
            master = mast;
            //меняем надпись на кнопке
            buttonAU.Content = "Редактировать";
            //привязываем к кнопке другой обработчик нажатия
            buttonAU.Click += UpdateClick;
            //заполняем поля на форме
            TabBox.Text = master.tabNum.ToString();
            NameBox.Text = master.FIO.ToString();
            PositionBox.Text = master.position.ToString();
            OkladBox.Text = master.oklad.ToString();
            PercentBox.Text = master.percentToRepair.ToString();
            WorkStat.Text = master.status.ToString();
        }
        private void UpdateClick(object sender, RoutedEventArgs e)
        {
            try
            {
                master.tabNum = Convert.ToInt32(TabBox.Text);
                master.FIO = NameBox.Text;
                master.position = Convert.ToInt32(PositionBox.Text);
                master.oklad = Convert.ToDecimal(OkladBox.Text);
                master.percentToRepair = Convert.ToDecimal(PercentBox.Text);
                master.status = WorkStat.Text;
                //сохраняем изенения БД
                context.SaveChanges();
                //переход к странице Ингрединты
                NavigationService.Navigate(new MasterPage(context));
            }
            catch
            {
                MessageBox.Show("Ошибка!");
            }

        }
        private void CanselCkick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Worker mast = new Worker()
                {
                    tabNum = Convert.ToInt32(TabBox.Text),
                    FIO = NameBox.Text,
                    position = Convert.ToInt32(PositionBox.Text),
                    oklad = Convert.ToDecimal(OkladBox.Text),
                    percentToRepair = Convert.ToDecimal(PercentBox.Text),
                    status = WorkStat.Text,
                };
                //добавляем ингредиент в БД
                context.Worker.Add(mast);
                //созранение изменений
                context.SaveChanges();
                //переход на страницу Ингредиенты
                NavigationService.Navigate(new MasterPage(context));
            }
            catch (FormatException) //перейдет сюда, если исключение возникло на Convert.To...
            {
                MessageBox.Show("Ошибка вводимых данных!");
            }
            catch //перейдет сюда во всех остальных случаях
            {
                MessageBox.Show("Ошибка!");
            }
        }
    }
}
