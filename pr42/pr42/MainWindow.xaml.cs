using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pr42
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow init;
        public View.Main Main = new View.Main();
        public MainWindow()
        {
            InitializeComponent();
            init = this;
            OpenPage(new View.Main());
        }

        public void OpenPage(Page page)
        {
            frame.Navigate(page);
        }

        private void OpenIndex(object sender, MouseButtonEventArgs e)
        {
            OpenPage(new View.Main());
        }
    }
}