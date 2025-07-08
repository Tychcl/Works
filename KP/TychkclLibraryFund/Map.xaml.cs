using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CustomWindow.Controls;
using DBC.Classes;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using Newtonsoft.Json;
using TychkclLibraryFund.Pages.Library;

namespace TychkclLibraryFund
{
    public class NominatimResult
    {
        public string display_name { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }
    }
    public partial class Map : CWWindow
    {
        private Redact red;
        private Library library;
        private PointLatLng point;
        public Map(Redact o)
        {
            InitializeComponent();
            red = o;
            library = red.Library;
            if(library.Lat != 0 && library.Lon != 0)
            { 
                point = new PointLatLng(library.Lat, library.Lon); 
            }
            else
            {
                point = new PointLatLng(55.7558, 37.6173);
            }
        }

        private void mapView_Loaded(object sender, RoutedEventArgs e)
        {
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            gmapControl.MapProvider = OpenStreetMapProvider.Instance;
            gmapControl.MouseWheelZoomType = MouseWheelZoomType.MousePositionWithoutCenter;
            gmapControl.DragButton = MouseButton.Left;
            gmapControl.Position = point;
            AddMarker(point, library.Address);
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string query = searchTextBox.Text;
            if (string.IsNullOrWhiteSpace(query))
            {
                return;
            }
            try
            {
                string url = $"https://nominatim.openstreetmap.org/search?format=json&q={WebUtility.UrlEncode(query)}";

                using (WebClient client = new WebClient())
                {
                    client.Headers.Add("User-Agent", "TychkclLibraryFundApp/1.0");

                    string json = client.DownloadString(url);
                    var results = JsonConvert.DeserializeObject<List<NominatimResult>>(json);

                    if (results != null && results.Count > 0)
                    {
                        var firstResult = results[0];
                        double.TryParse(firstResult.lat.Replace('.', ','), out double lat);
                        double.TryParse(firstResult.lon.Replace('.',','), out double lon);

                        gmapControl.Position = new PointLatLng(lat, lon);
                        gmapControl.Zoom = 15;

                        AddMarker(new PointLatLng(lat, lon), firstResult.display_name);
                    }
                    else
                    {
                        MessageBox.Show("Место не найдено", "Результат поиска",
                                        MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка поиска: {ex.Message}", "Ошибка",
                                MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddMarker(PointLatLng position, string tooltip = "")
        {
            gmapControl.Markers.Clear();
            if (string.IsNullOrEmpty(tooltip))
            {
                using (WebClient c = new WebClient())
                {
                    string url = $"https://nominatim.openstreetmap.org/reverse?lat={position.Lat.ToString().Replace(',', '.')}&lon={position.Lng.ToString().Replace(',', '.')}&format=json";
                    c.Headers.Add("User-Agent", "TychkclLibraryFundApp/1.0");

                    string json = c.DownloadString(url);
                    var results = JsonConvert.DeserializeObject<NominatimResult>(json);
                    tooltip = results.display_name;
                }
            }
            var marker = new GMapMarker(position);
            var markerShape = new Ellipse
            {
                Width = 16,
                Height = 16,
                Fill = Brushes.Red,
                Stroke = Brushes.White,
                StrokeThickness = 2,
                ToolTip = tooltip
            };
            marker.Shape = markerShape;
            marker.Offset = new Point(-8, -8);
            library.Lat = position.Lat;
            library.Lon = position.Lng;
            library.Address = tooltip;
            gmapControl.Markers.Add(marker);
        }

        private void GMapControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var mousePos = e.GetPosition(gmapControl);
            var point = gmapControl.FromLocalToLatLng((int)mousePos.X, (int)mousePos.Y);
            AddMarker(point);
        }

        private void ready(object sender, RoutedEventArgs e)
        {
            red.adres.Text = library.Address;
            this.Close();
        }
    }
}
