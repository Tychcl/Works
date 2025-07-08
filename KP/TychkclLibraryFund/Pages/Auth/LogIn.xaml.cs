using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
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
using DBC;

namespace TychkclLibraryFund.Pages.Auth
{
    /// <summary>
    /// Логика взаимодействия для RegIn.xaml
    /// </summary>
    public partial class LogIn : Page
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void ready(object sender, RoutedEventArgs e)
        {
            if (!DBC.Check.Phone(phone.Text) || string.IsNullOrEmpty(pass.Password))
            {
                MainWindow.init.Notification.Children.Add(new Items.Notification("Что то не так заполнено"));
                return;
            }
            using(var con = new DBC.Context())
            {
                var user = con.User.AsNoTracking().ToList().FirstOrDefault(x => x.Phone == phone.Text && x.Password == pass.Password);
                if (user is not null)
                {
                    MainWindow.init.CUser = user;
                    if(user.RoleId == 1)
                    {
                        MainWindow.init.ReFill.Visibility = Visibility.Collapsed;
                    }
                    MainWindow.init.OpenPage(MainWindow.init.CP);
                }
                else
                {
                    MainWindow.init.Notification.Children.Add(new Items.Notification("Не найден или не верный пароль"));
                    return;
                }
                
            }
        }

        private void gologin(object sender, RoutedEventArgs e)
        {
            MainWindow.init.frame.Navigate(new Pages.Auth.RegIn());
        }
    }
}
