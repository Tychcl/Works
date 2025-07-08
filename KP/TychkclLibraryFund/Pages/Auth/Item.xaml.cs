using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
using Microsoft.Office.Interop.Excel;

namespace TychkclLibraryFund.Pages.Auth
{
    /// <summary>
    /// Логика взаимодействия для Item.xaml
    /// </summary>
    public partial class Item : UserControl
    {
        DBC.Classes.User User;
        public Item(DBC.Classes.User l)
        {
            InitializeComponent();
            User = l;
            name.Text = User.FIO;
            using (var con = new Context())
                lab.Content = $"{User.Phone} {con.UserRoles.FirstOrDefault(x => x.Id == User.RoleId).Role}";
        }

        private void del(object sender, RoutedEventArgs e)
        {
            using(var context = new DBC.Context())
            {
                context.User.Remove(User);
                context.SaveChanges();
            }
            ((StackPanel)Parent).Children.Remove(this);
        }
    }
}
