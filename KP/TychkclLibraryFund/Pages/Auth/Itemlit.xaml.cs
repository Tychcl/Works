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
    public partial class Itemlit : UserControl
    {
        DBC.Classes.UserOrder order;
        public Itemlit(DBC.Classes.UserOrder l)
        {
            InitializeComponent();
            order = l;
            using (var con = new Context())
            {
                name.Text = con.Literature.FirstOrDefault(x=>x.Id == order.Literature).Name;
                lab.Content = con.Library.FirstOrDefault(x=>x.Id == order.Library).Name;
            }
        }

        private void del(object sender, RoutedEventArgs e)
        {
            using(var context = new DBC.Context())
            {
                context.UserOrder.Remove(order);
                context.SaveChanges();
            }
            ((StackPanel)Parent).Children.Remove(this);
        }
    }
}
