using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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

namespace TychkclLibraryFund.Items
{
    /// <summary>
    /// Логика взаимодействия для Notification.xaml
    /// </summary>
    public partial class Notification : UserControl
    {
        private DispatcherTimer timer = new DispatcherTimer();

        public Notification(string Message = "Empty", int Dur = 1000)
        {
            click(null, null);
            InitializeComponent();
            msg.Content = Message;
        }

        private void click(object sender, MouseButtonEventArgs e)
        {
            MainWindow.init.Notification.Children.Clear();
        }
    }
}
