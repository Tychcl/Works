using CustomWindow.Controls;
using DBC;
using DBC.Classes;
using GMap.NET.MapProviders;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Threading;

namespace TychkclLibraryFund.Pages.Library
{
    /// <summary>
    /// Логика взаимодействия для Redact.xaml
    /// </summary>
    public partial class Redact : Page
    {
        public DBC.Classes.Library Library = new DBC.Classes.Library();
        public Redact(DBC.Classes.Library l = null)
        {
            if (l != null)
            {
                Library = l;
                this.DataContext = Library;
            }
            InitializeComponent();
            
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
            if (string.IsNullOrEmpty(name.Text) | string.IsNullOrEmpty(adres.Text) | !Check.Mail(mail.Text) | !Check.Phone(phone.Text))
            {
                MainWindow.init.Notification.Children.Add(new Items.Notification("Что то не так заполнено"));
                return;
            }
            Library.Name = name.Text;
            Library.Address = adres.Text;
            Library.Phone = phone.Text;
            Library.Mail = mail.Text;
            SaveDataAsync();
        }

        private void Save()
        {
            using (var context = new DBC.Context())
            {
                if (Library.Id != null)
                {
                    context.Library.Update(Library);
                    context.SaveChanges();
                    Dispatcher.Invoke(() =>
                    {
                        MainWindow.init.Notification.Children.Add(new Items.Notification("Успешно"));
                    }, DispatcherPriority.Background);
                    
                }
                else
                {
                    Library.Id = context.Library.Max(x => x.Id) + 1;
                    context.Library.Add(Library);
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

        private void OpenMap(object sender, RoutedEventArgs e)
        {
            var map = new Map(this);
            map.Show();
        }
    }
}
