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

namespace TychkclLibraryFund.Items
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : UserControl
    {
        public MainWindow.Page? CP = null;
        public Add()
        {
            InitializeComponent();
        }

        private void add(object sender, RoutedEventArgs e)
        {
            if(CP != null)
            {
                MainWindow.init.OpenPage((MainWindow.Page)CP);
            }
        }
    }
}
