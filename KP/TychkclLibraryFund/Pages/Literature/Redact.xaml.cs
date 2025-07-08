using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Printing;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Windows.Threading;
using DBC;
using DBC.Classes;
using Microsoft.Win32;

namespace TychkclLibraryFund.Pages.Literature
{
    /// <summary>
    /// Логика взаимодействия для Redact.xaml
    /// </summary>
    public partial class Redact : Page
    {
        private DBC.Classes.Literature Literature= new DBC.Classes.Literature();
        public Redact(DBC.Classes.Literature l = null)
        {
            InitializeComponent();
            if (l != null)
            {
                Literature = l;
                this.DataContext = Literature;
                redate.Text = l.ReleaseDate.ToString();
                if(l.Image is not null && l.Image.Length > 0)
                { 
                    imgs.Source = Byte2Image(Literature.Image); 
                }
            }
            using (var con = new DBC.Context())
            {
                var list = con.LiteratureType.ToList();
                foreach (var t in list)
                {
                    ComboBoxItem i = new ComboBoxItem();
                    i.Tag = t.Id;
                    i.Content = t.Type;
                    type.Items.Add(i);
                    if(l != null && l.TypeId == t.Id)
                    {
                        type.SelectedItem = i;
                    }
                }
            }
        }

        private async void SaveDataAsync()
        {
            try
            {
                await Task.Run(Save);
            }
            catch (OperationCanceledException)
            {
                return;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Ошибка загрузки: {ex.Message}");
            }
        }

        private void add(object sender, RoutedEventArgs e)
        {
            MainWindow.init.Notification.Children.Clear();
            if (string.IsNullOrEmpty(name.Text) || string.IsNullOrEmpty(des.Text) 
                || string.IsNullOrEmpty(author.Text) || string.IsNullOrEmpty(pub.Text) 
                || type.SelectedIndex == -1 || !DateOnly.TryParse(redate.Text, out DateOnly date) 
                || !double.TryParse(price.Text, out double d))
            {
                MainWindow.init.Notification.Children.Add(new Items.Notification("Что то не так заполнено"));
                return;
            }
            Literature.Name = name.Text;
            Literature.Description = des.Text;
            Literature.Author = author.Text;
            Literature.Publisher = pub.Text;
            Literature.ReleaseDate = DateOnly.Parse(redate.Text);
            Literature.TypeId = (int)((ComboBoxItem)type.SelectedItem).Tag;
            Literature.Price = int.Parse(price.Text);
            SaveDataAsync();
        }

        private void Save()
        {
            using (var context = new DBC.Context())
            {
                if (Literature.Id != null)
                {
                    context.Literature.Update(Literature);
                    context.SaveChanges();
                    Dispatcher.Invoke(() =>
                    {
                        MainWindow.init.Notification.Children.Add(new Items.Notification("Успешно"));
                    }, DispatcherPriority.Background);
                }
                else
                {
                    Literature.Id = context.Literature.Max(x => x.Id) + 1;
                    context.Literature.Add(Literature);
                    context.SaveChanges();
                    Dispatcher.Invoke(() =>
                    {
                        MainWindow.init.Notification.Children.Add(new Items.Notification("Успешно"));
                    }, DispatcherPriority.Background);
                }
            }
            Dispatcher.Invoke(() =>
            {
                MainWindow.init.OpenPage(MainWindow.init.CP);
            }, DispatcherPriority.Background);

        }

        private void SelectImage(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Картинки|*.png;*.jpeg;*.jpg";
            if(ofd.ShowDialog() == true)
            {
                imgs.Source = new BitmapImage(new Uri(ofd.FileName));
                Literature.Image = File.ReadAllBytes(ofd.FileName);
            }
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
