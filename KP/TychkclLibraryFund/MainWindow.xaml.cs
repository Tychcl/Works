using System.Text;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CustomWindow.Controls;
using DBC;
using Microsoft.Win32;
using Microsoft.Office.Interop.Excel;
using System.IO;

namespace TychkclLibraryFund
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : CWWindow
    {
        public static MainWindow init;
        public MainWindow.Page CP;
        public DBC.Classes.User CUser;
        public enum Page
        {
            user, library, literature, refill,
            ruser, rlibrary, rliterature, rrefill
        }
        public MainWindow()
        {
            InitializeComponent();
            //statistic(null, null);
            init = this;
            //CUser = new DBC.Classes.User();
            //CUser.Role = new DBC.Classes.UserRole() { Id = 3, Role = "" };
            //OpenPage(Page.library);
        }

        public void OpenPage(Page p)
        {
            frame.NavigationService.StopLoading();
            if(Page.user == p)
            {
                if(CUser == null)
                {
                    frame.Navigate(new Pages.Auth.RegIn());
                }
                else
                {
                    frame.Navigate(new Pages.Auth.Info());
                }
            }
            if (Page.library == p)
            {
                
                frame.Navigate(new Pages.Library.View());
            }
            if (Page.literature == p)
            {
                frame.Navigate(new Pages.Literature.View());
            }
            if (Page.refill == p)
            {
                frame.Navigate(new Pages.ReFill.View());
            }
            if (Page.ruser == p)
            {
                frame.Navigate(new Pages.Auth.Redact());
            }
            if (Page.rlibrary == p)
            {
                frame.Navigate(new Pages.Library.Redact());
            }
            if (Page.rliterature == p)
            {
                frame.Navigate(new Pages.Literature.Redact());
            }
            if (Page.rrefill == p)
            {
                frame.Navigate(new Pages.ReFill.Redact());
            }
        }

        public MainWindow.Page GetPage(string str)
        {
            return (MainWindow.Page)Enum.Parse(typeof(MainWindow.Page), str);
        }

        private void CheckMain(object sender, RoutedEventArgs e)
        {
            string cp = (sender as RadioButton).Name.ToLower();
            CP = GetPage(cp);
            OpenPage(CP);
            if (CUser is not null && CUser.RoleId != 1)
            {
                BtnAdd.CP = GetPage("r" + cp);
                BtnAdd.IsEnabled = true;
            }
        }

        private void statistic(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var con = new DBC.Context())
                {
                    var libs = con.Refill.AsNoTracking().ToList().GroupBy(x => x.LibraryId);
                    string[][] data = new string[libs.Count() + 1][];
                    data[0] = new string[14] { "Библиотека", "Январь", "Февраль", "Март",
                        "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь",
                        "Ноябрь", "Декабрь", "Всего" };
                    int n = 1;
                    foreach (var lib in libs)
                    {
                        data[n] = new string[14];
                        data[n][0] = con.Library.FirstOrDefault( x => x.Id == lib.Key).Name;
                        data[n][13] = $"=СУММ(B{n + 1}:M{n + 1})";
                        foreach (var b in lib.ToList().OrderBy(x => x.Date.Month).GroupBy(x => x.Date.Month))
                        {
                            data[n][b.Key] = b.ToList().Sum(x => x.Count).ToString();
                        }
                        n++;
                    }
                    OpenFolderDialog ofd = new();
                    ofd.Title = "Папка сохранения";
                    if (ofd.ShowDialog() == true)
                    {
                        using (StreamWriter wr = new(ofd.FolderName + "\\Отчет.csv", false, Encoding.UTF8))
                        {
                            foreach (string[] str in data)
                            {
                                wr.WriteLine(string.Join(';', str));
                            }
                        }
                        Notification.Children.Add(new Items.Notification("Отчет создан"));
                    }
                }
                
            }
            catch
            {
                Notification.Children.Add(new Items.Notification("Что то пошло не так"));
            }
        }
    }
}