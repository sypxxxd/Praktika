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
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Page
    {
        Model1 context;
        Window window;
        public Autorization(Model1 cont, Window win)
        {
            InitializeComponent();
            Remind.Visibility = Visibility.Hidden;
            context = cont;
            window = win;
        }
        int countClick = 0;
        private void EnterClick(object sender, RoutedEventArgs e)
        {
            countClick++;
            string log = loginBox.Text;
            string pass = passwordBox.Password;
            Users users = context.Users.ToList().Find(x => x.Login.Equals(log));

            if (users != null)
            {

                if (users.Pass.Equals(pass))
                {
                    context.SaveChanges();
                    NavigationService.Navigate(new MainPage(context, window));
                    countClick = 0;
                }
                else
                {
                    MessageBox.Show("Вы ввели неверный пароль ");
                    if (countClick >= 3)
                    {
                        Remind.Visibility = Visibility.Visible;
                    }
                }
            }
            else
            {
                MessageBox.Show("Такого пользователя не существует ");
            }
        }

        private void Remind_Click(object sender, RoutedEventArgs e)
        {
            RemaindPass passRemaindWindow = new RemaindPass(context);
            passRemaindWindow.Show();
        }
    }
}
