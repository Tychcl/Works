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
using DBC;
using DBC.Classes;

namespace TychkclLibraryFund.Pages.Literature
{
    /// <summary>
    /// Логика взаимодействия для Order.xaml
    /// </summary>
    public partial class Order : Page
    {
        public Order(int? litid = null)
        {
            InitializeComponent();
            using (var con = new Context())
            {
                foreach (var item in con.Literature.ToList())
                {
                    ComboBoxItem i = new();
                    i.Tag = item.Id;
                    i.Content = item.Name;
                    Lits.Items.Add(i);
                    if (litid is not null && litid == item.Id)
                    {
                       Lits.SelectedItem = i;
                    }
                }
            }
        }

        private void add(object sender, RoutedEventArgs e)
        {
            if(Lits.SelectedIndex == -1 || lib.SelectedIndex == -1)
            {
                MainWindow.init.Notification.Children.Add(new Items.Notification("Что то не так заполнено"));
                return;
            }
            using (var con = new Context())
            {
                con.Add(new UserOrder() { Id = con.UserOrder.Max(x => x.Id) + 1,
                User = MainWindow.init.CUser.Id,
                Library = (int)((ComboBoxItem)lib.SelectedItem).Tag,
                Literature = (int)((ComboBoxItem)Lits.SelectedItem).Tag
                });
                con.SaveChanges();
            }
            MainWindow.init.OpenPage(MainWindow.init.CP);
        }

        private void litselect(object sender, SelectionChangedEventArgs e)
        {
            lib.SelectedIndex = -1;
                lib.Items.Clear();
                using (var con = new Context())
                {
                    int key = (int)((ComboBoxItem)Lits.SelectedItem).Tag;
                try
                {
                    var refill = con.Refill.GroupBy(x => x.LibraryId).ToList()[key];
                    var lits = con.Library.ToList();
                    foreach (var it in refill)
                    {
                        if (lits.FirstOrDefault(x => x.Id == it.LiteratureId) is DBC.Classes.Library item)
                        {
                            ComboBoxItem i = new();
                            i.Tag = item.Id;
                            i.Content = $"{item.Name}\n{item.Address}";
                            lib.Items.Add(i);
                        }
                    }
                }
                catch
                {
                    return;
                }
                }
            lib.IsEnabled = lib.Items.Count > 0;

        }
    }
}
