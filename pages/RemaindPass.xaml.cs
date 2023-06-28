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
using System.Windows.Shapes;

namespace Vova.pages
{
    /// <summary>
    /// Логика взаимодействия для RemaindPass.xaml
    /// </summary>
    public partial class RemaindPass : Window
    {
        Model1 context;
        public RemaindPass(Model1 cont)
        {
            InitializeComponent();
            context = cont;
        }

        private void Show_Click(object sender, RoutedEventArgs e)
        {
            var a = Convert.ToString(name.Text);
            var b = Convert.ToInt32(TabNum.Text);
            var c = Convert.ToString(Position.Text);
            var res = context.Users.Where(x => x.Dolzhnost == c && x.TabID == b && x.Login == a).ToString();
            if (res.Count() > 0)
            {
                Users author = context.Users.ToList().Find(x => x.TabID.Equals(b));
                string shw = author.Pass.ToString();
                MessageBox.Show(shw);
                this.Close();
            }
            else
            {
                MessageBox.Show("Ошибка! Пользователь не найден.");
                this.Close();
            }
        }
    }
}
