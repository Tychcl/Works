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

namespace TychkclLibraryFund.Pages.Literature
{
    /// <summary>
    /// Логика взаимодействия для Item.xaml
    /// </summary>
    public partial class Item : UserControl
    {
        DBC.Classes.Literature Literature;
        public Item(DBC.Classes.Literature l)
        {
            InitializeComponent();
            Literature = l;
            this.DataContext = Literature;
            if(MainWindow.init.CUser is not null)
            {
                addcart.Visibility = Visibility.Visible;
                if (Literature.Image is not null && Literature.Image.Length > 0)
                {
                    image.Source = Byte2Image(Literature.Image);
                }
            }
            if (MainWindow.init.CUser is not null && MainWindow.init.CUser.RoleId >= 2)
            {
                redact.Visibility = Visibility.Visible;
                delete.Visibility = Visibility.Visible;
            }
        }

        private void red(object sender, RoutedEventArgs e)
        {
            MainWindow.init.frame.Navigate(new Pages.Literature.Redact(Literature));
        }

        private void del(object sender, RoutedEventArgs e)
        {
            using(var context = new DBC.Context())
            {
                context.Literature.Remove(Literature);
                context.SaveChanges();
            }
            ((WrapPanel)Parent).Children.Remove(this);
        }

        private void addtocart(object sender, RoutedEventArgs e)
        {
            MainWindow.init.frame.Navigate(new Pages.Literature.Order(litid: Literature.Id));
        }
        private BitmapImage Byte2Image(byte[] photo)
        {
            BitmapImage image = new BitmapImage();
            using (var Stream = new MemoryStream(photo))
            {
                Stream.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = Stream;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }
    }
}
