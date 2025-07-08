using System;
using System.Collections.Generic;
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

namespace TychkclLibraryFund.Pages.ReFill
{
    /// <summary>
    /// Логика взаимодействия для Item.xaml
    /// </summary>
    public partial class Item : UserControl
    {
        DBC.Classes.Refill ReFill;
        public Item(DBC.Classes.Refill l)
        {
            InitializeComponent();
            ReFill = l;
            using(var con = new Context())
            {
                lit.Text = con.Literature.FirstOrDefault(x => x.Id == ReFill.LiteratureId).Name;
            }
            countdate.Content = $"Дата: {ReFill.Date} Количество: {ReFill.Count}";
            if (MainWindow.init.CUser is not null && MainWindow.init.CUser.RoleId >= 2)
            {
                redact.Visibility = Visibility.Visible;
                delete.Visibility = Visibility.Visible;
            }
        }

        private void red(object sender, RoutedEventArgs e)
        {
            MainWindow.init.frame.Navigate(new Pages.ReFill.Redact(ReFill));
        }

        private void del(object sender, RoutedEventArgs e)
        {
            using(var context = new DBC.Context())
            {
                context.Refill.Remove(ReFill);
                context.SaveChanges();
            }
            ((StackPanel)Parent).Children.Remove(this);
        }
    }
}
