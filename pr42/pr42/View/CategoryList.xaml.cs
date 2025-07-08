using pr42.ViewModell;
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

namespace pr42.View
{
    /// <summary>
    /// Логика взаимодействия для CategoryList.xaml
    /// </summary>
    public partial class CategoryList : Page
    {
        public CategoryList()
        {
            InitializeComponent();
            DataContext = new VMCategorys();
        }

        private void ListItem(object sender, RoutedEventArgs e)=>
            MainWindow.init.frame.Navigate(new View.Main());
    }
}
