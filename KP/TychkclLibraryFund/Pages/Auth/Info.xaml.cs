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
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DBC;

namespace TychkclLibraryFund.Pages.Auth
{
    /// <summary>
    /// Логика взаимодействия для Info.xaml
    /// </summary>
    public partial class Info : Page
    {
        public Info()
        {
            InitializeComponent();
            this.DataContext = MainWindow.init.CUser;
            using (var con = new Context())
            {
                role.Text = con.UserRoles.FirstOrDefault(x => x.Id == MainWindow.init.CUser.RoleId).Role;
                foreach(var item in con.UserOrder.ToList())
                {
                    lits.Children.Add(new Itemlit(item));
                }
            }
                
            if (MainWindow.init.CUser.RoleId == 3)
            {
                nsbtn.Visibility = Visibility.Visible;
                ul.Visibility = Visibility.Visible;
                using (var con = new DBC.Context())
                {
                    var list = con.User.AsNoTracking().Where(x => x != MainWindow.init.CUser).ToList();
                    foreach (var item in list)
                    {
                        users.Children.Add(new Pages.Auth.Item(item));
                    }
                }
            }
        }

        private void click(object sender, RoutedEventArgs e)
        {
            MainWindow.init.frame.Navigate(new Pages.Auth.Redact());
        }

        private void newstaff(object sender, RoutedEventArgs e)
        {
            MainWindow.init.frame.Navigate(new Pages.Auth.RegIn(2));
        }

        private void logout(object sender, RoutedEventArgs e)
        {
            MainWindow.init.CUser = null;
            MainWindow.init.frame.Navigate(new Pages.Auth.LogIn());
        }
    }
}
