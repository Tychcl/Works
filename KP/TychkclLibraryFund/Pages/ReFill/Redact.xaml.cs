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
using Microsoft.Office.Interop.Excel;
using Microsoft.Win32;

namespace TychkclLibraryFund.Pages.ReFill
{
    /// <summary>
    /// Логика взаимодействия для Redact.xaml
    /// </summary>
    public partial class Redact : System.Windows.Controls.Page
    {
        private DBC.Classes.Refill ReFill= new DBC.Classes.Refill();
        public Redact(DBC.Classes.Refill l = null, int? library = null)
        {
            InitializeComponent();
            if (l != null)
            {
                ReFill = l;
                this.DataContext = ReFill;
            }
            staff.Text = MainWindow.init.CUser.FIO;
            date.Text = DateTime.Now.Date.ToString();
            using(var con = new DBC.Context())
            {
                var libs = con.Library.ToList();
                foreach (var item in libs)
                {
                    ComboBoxItem i = new ComboBoxItem();
                    i.Content = item.Name;
                    i.Tag = item.Id;
                    lib.Items.Add(i);
                    if(l is not null && l.LibraryId == item.Id || library is not null && library == item.Id)
                    {
                        lib.SelectedItem = i;
                    }
                }
                var lits = con.Literature.ToList();
                foreach (var item in lits)
                {
                    ComboBoxItem i = new ComboBoxItem();
                    i.Content = item.Name;
                    i.Tag = item.Id;
                    lit.Items.Add(i);
                    if (l is not null && l.LiteratureId == item.Id)
                    {
                        lit.SelectedItem = i;
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
            if (lit.SelectedIndex == -1 || lib.SelectedIndex == -1 
                || (string.IsNullOrEmpty(date.Text) && !DateOnly.TryParse(date.Text, out DateOnly d)) 
                || !int.TryParse(count.Text,out int i))
            {
                MainWindow.init.Notification.Children.Add(new Items.Notification("Что то не так заполнено"));
                return;
            }
            ReFill.Date = DateOnly.Parse(date.Text);
            ReFill.StaffId = MainWindow.init.CUser.Id;
            ReFill.LibraryId = (int)((ComboBoxItem)lib.SelectedItem).Tag;
            ReFill.LiteratureId = (int)((ComboBoxItem)lit.SelectedItem).Tag;
            ReFill.Count = int.Parse(count.Text);
            SaveDataAsync();
        }

        private void Save()
        {
            using (var context = new DBC.Context())
            {
                if (ReFill.Id != null)
                {
                    context.Refill.Update(ReFill);
                    context.SaveChanges();
                    Dispatcher.Invoke(() =>
                    {
                        MainWindow.init.Notification.Children.Add(new Items.Notification("Успешно"));
                    }, DispatcherPriority.Background);
                }
                else
                {
                    ReFill.Id = context.Refill.Max(x => x.Id) + 1;
                    context.Refill.Add(ReFill);
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
    }
}
