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

namespace TychkclLibraryFund.Pages.Auth
{
    /// <summary>
    /// Логика взаимодействия для Redact.xaml
    /// </summary>
    public partial class Redact : Page
    {
        private DBC.Classes.User user;  
        public Redact()
        {
            InitializeComponent();
            user = MainWindow.init.CUser;
            this.DataContext = user;
        }

        private void ready(object sender, RoutedEventArgs e)
        {
            if (!DBC.Check.FIO(fio.Text) || !DBC.Check.Phone(phone.Text) || string.IsNullOrEmpty(newpass.Text) || user.Password != pass.Text)
            {
                MainWindow.init.Notification.Children.Add(new Items.Notification("Что то не так заполнено"));
                return;
            }
            using (var con = new DBC.Context())
            {
                user.FIO = fio.Text;
                user.Phone = phone.Text;
                user.Password = newpass.Text;
                con.Update(user);
                con.SaveChanges();
            }
            MainWindow.init.OpenPage(MainWindow.init.CP);
        }
    }
}
