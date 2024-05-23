using Microsoft.Win32;
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

namespace pr32savichev
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow mainWindow;
        public Pages.Records.Main mainRecords = new Pages.Records.Main();
        public MainWindow()
        {
            InitializeComponent();
            MainWindow.mainWindow = this;
            OpenPage(mainRecords);
        }
        public void OpenPage(Page pages)
        {
            frame.Navigate(pages);
        }

        private void OpenRecordList(object sender, RoutedEventArgs e)
        {
            OpenPage(mainRecords);
            mainRecords.LoadRecord();
        }

        private void OpenRecordAdd(object sender, RoutedEventArgs e)
        {
            OpenPage(new Pages.Records.Add());
        }

        private void OpenManufacturersList(object sender, RoutedEventArgs e)
        {
            OpenPage(new savichev32pr.Pages.Manufacturer.Main());
        }

        private void OpenManufacturersAdd(object sender, RoutedEventArgs e)
        {
            OpenPage(new Pages.Manufacturer.Add());
        }

        private void OpenSupplyList(object sender, RoutedEventArgs e)
        {
            OpenPage(new Pages.Supply.Main());
        }

        private void OpenSupplyAdd(object sender, RoutedEventArgs e)
        {
            OpenPage(new Pages.Supply.Add());
        }

        private void OpenStateList(object sender, RoutedEventArgs e)
        {
            OpenPage(new savichev32pr.Pages.State.Main());
        }

        private void OpenStateAdd(object sender, RoutedEventArgs e)
        {
            OpenPage(new savichev32pr.Pages.State.Add());
        }
    }
}

