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
using DBC;

namespace TychkclLibraryFund.Pages.ReFill
{
    /// <summary>
    /// Логика взаимодействия для Group.xaml
    /// </summary>
    public partial class Group : UserControl
    {
        private CancellationTokenSource _localCts;
        List<DBC.Classes.Refill> list;
        public Group(int? key,List<DBC.Classes.Refill> group)
        {
            InitializeComponent();
            using (var con = new Context())
            {
                text.Content = con.Library.FirstOrDefault(x=>x.Id == key).Name;
            }
            list = group;

            _localCts?.Cancel();
            _localCts?.Dispose();
            _localCts = new CancellationTokenSource();

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
                foreach (var item in list)
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
                            parent.Children.Add(new Pages.ReFill.Item(item));
                        }
                    }, DispatcherPriority.Background);

                    Thread.Sleep(10);
                }
        }


        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            _localCts?.Cancel();
            _localCts?.Dispose();
            _localCts = null;
        }

        private void click(object sender, RoutedEventArgs e)
        {
            if(parent.Visibility == Visibility.Collapsed)
            {
                parent.Visibility = Visibility.Visible;
            }
            else
            {
                parent.Visibility = Visibility.Collapsed;
            }
        }
    }
}
