using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace TychkclLibraryFund.Pages.Auth
{
    /// <summary>
    /// Логика взаимодействия для RegIn.xaml
    /// </summary>
    public partial class RegIn : Page
    {
        private int userrole;
        public RegIn(int ur = 1)
        {
            InitializeComponent();
            userrole = ur;
            if (userrole == 2)
            {
                logbtn.Visibility = Visibility.Collapsed;
            }
        }

        private void ready(object sender, RoutedEventArgs e)
        {
            if(!DBC.Check.FIO(fio.Text) || !DBC.Check.Phone(phone.Text) || string.IsNullOrEmpty(pass.Password) || string.IsNullOrEmpty(dpass.Password) || dpass.Password != pass.Password)
            {
                MainWindow.init.Notification.Children.Add(new Items.Notification("Что то не так заполнено"));
                return;
            }
            using(var con = new DBC.Context())
            {
                if(con.User.FirstOrDefault(x=> x.Phone == phone.Text) is not null)
                {
                    MainWindow.init.Notification.Children.Add(new Items.Notification("Номер уже зарегистрирован"));
                    return;
                }
                int? id = con.User.AsNoTracking().ToList().Max(x => x.Id) + 1;
                con.Add(new DBC.Classes.User() { Id = id, FIO = fio.Text, Phone = phone.Text, Password = pass.Password, RoleId = userrole });
                con.SaveChanges();
                MainWindow.init.OpenPage(MainWindow.init.CP);
            }
        }

        private void gologin(object sender, RoutedEventArgs e)
        {
            MainWindow.init.frame.Navigate(new Pages.Auth.LogIn());
        }
    }
}
