﻿using System;
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

namespace pr41.Views
{
    /// <summary>
    /// Логика взаимодействия для TimerPage.xaml
    /// </summary>
    public partial class TimerPage : Page
    {
        public TimerPage()
        {
            InitializeComponent();
            DataContext = new ViewModel.VMTimer();
        }

        private void GoToStopwatch(object sender, RoutedEventArgs e)=>
            MainWindow.mainWindow.OpenPage(new Views.Main());
    }
}
