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

namespace TychkclLibraryFund.Items
{
    /// <summary>
    /// Логика взаимодействия для Back.xaml
    /// </summary>
    public partial class Back : UserControl
    {
        public Back()
        {
            InitializeComponent();
        }

        private void back(object sender, RoutedEventArgs e)
        {
            MainWindow.init.OpenPage(MainWindow.init.CP);
        }
    }
}
