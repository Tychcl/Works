using DBC.Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace TychkclLibraryFund.Pages.Literature
{
    /// <summary>
    /// Логика взаимодействия для View.xaml
    /// </summary>
    public partial class View : Page
    {
        private CancellationTokenSource _localCts;

        public View()
        {
            InitializeComponent();

            parent.Children.Clear();

            VirtualizingPanel.SetCacheLength(parent, new VirtualizationCacheLength(5));

            _localCts?.Cancel();
            _localCts?.Dispose();
            _localCts = new CancellationTokenSource();
            MainWindow.init.Notification.Children.Clear();
            LoadDataAsync(_localCts.Token);
        }

        private async void LoadDataAsync(CancellationToken token)
        {
            try
            {
                await Task.Run(() => LoadItems(token), token);
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

        private void LoadItems(CancellationToken token)
        {
            using (var context = new DBC.Context())
            {
                var list = context.Literature.AsNoTracking().ToListAsync();
                foreach (var item in list.Result)
                {
                    try
                    {
                        token.ThrowIfCancellationRequested();
                    }
                    catch
                    {
                        return;
                    }
                    Dispatcher.Invoke(() =>
                    {
                        if (!token.IsCancellationRequested)
                        {
                            parent.Children.Add(new Pages.Literature.Item(item));
                        }
                        else
                        {
                            return;
                        }
                    }, DispatcherPriority.Background);

                    Thread.Sleep(10);
                }
            }
        }


        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            _localCts?.Cancel();
            _localCts?.Dispose();
            _localCts = null;
        }
    }
}
