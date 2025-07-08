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
using DBC.Classes;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using static System.Net.Mime.MediaTypeNames;

namespace TychkclLibraryFund.Pages.Library
{
    /// <summary>
    /// Логика взаимодействия для Item.xaml
    /// </summary>
    public partial class Item : UserControl
    {
        DBC.Classes.Library Library;
        public Item(DBC.Classes.Library l)
        {
            InitializeComponent();
            Library = l;
            this.DataContext = Library;
            if (MainWindow.init.CUser is not null && MainWindow.init.CUser.RoleId >= 2)
            {
                redact.Visibility = Visibility.Visible;
                refill.Visibility = Visibility.Visible;
                delete.Visibility = Visibility.Visible;
            }
        }

        private void red(object sender, RoutedEventArgs e)
        {
            MainWindow.init.frame.Navigate(new Pages.Library.Redact(Library));
        }

        private void del(object sender, RoutedEventArgs e)
        {
            using (var context = new DBC.Context())
            {
                context.Library.Remove(Library);
                context.SaveChanges();
            }
            ((WrapPanel)Parent).Children.Remove(this);
        }

        private void fill(object sender, RoutedEventArgs e)
        {
            MainWindow.init.frame.Navigate(new Pages.ReFill.Redact(library: Library.Id));
        }

        private void mapView_Loaded(object sender, RoutedEventArgs e)
        {
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            gmapControl.MapProvider = OpenStreetMapProvider.Instance;
            gmapControl.MouseWheelZoomType = MouseWheelZoomType.MousePositionAndCenter;
            gmapControl.CanDragMap = false;
            gmapControl.MouseWheelZoomEnabled = false;
            PointLatLng position = new PointLatLng(Library.Lat, Library.Lon);
            gmapControl.Position = position;
            var marker = new GMapMarker(position);
            var markerShape = new Ellipse
            {
                Width = 12,
                Height = 12,
                Fill = Brushes.Red,
                Stroke = Brushes.White,
                StrokeThickness = 2,
                ToolTip = Library.Address
            };
            marker.Shape = markerShape;
            marker.Offset = new Point(-6, -6);
            marker.Offset = new Point(-6, -6);
            gmapControl.Markers.Add(marker);
        }
    }
}
