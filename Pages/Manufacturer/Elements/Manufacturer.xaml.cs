﻿using pr32savichev;
using savichev32pr.Classes;
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

namespace savichev32pr.Pages.Manufacturer.Elements
{
    /// <summary>
    /// Логика взаимодействия для Manufacturer.xaml
    /// </summary>
    public partial class Manufacturer : UserControl
    {
        IEnumerable<Classes.Country> Countries = Country.AllCountries();
        Pages.Manufacturer.Main main;
        Classes.Manufacturer manufacturer;
        public Manufacturer(Classes.Manufacturer manufacturer, Pages.Manufacturer.Main main)
        {
            InitializeComponent();
            tbName.Text = manufacturer.Name;
            tbCountry.Text = Countries.Where(x => x.Id == manufacturer.CountryCode).First().Name;
            tbPhone.Text = manufacturer.Phone.ToString();
            tbEmail.Text = manufacturer.Mail;
            this.manufacturer = manufacturer;
            this.main = main;
        }

        private void EditManufacturer(object sender, RoutedEventArgs e) => MainWindow.mainWindow.OpenPage(new Pages.Manufacturer.Add(this.manufacturer));

        private void DeleteManufacturer(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Удалить поставщика: {this.manufacturer.Name}?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                if (pr32savichev.Classes.Record.AllRecords().Count(x => x.IdManufacturer == manufacturer.Id) > 0)
                {
                    MessageBox.Show($"Поставщика {this.manufacturer.Name} невозможно удалить. Для начала удалите зависимости.", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    this.manufacturer.Delete();
                    main.manufacturerParent.Children.Remove(this);
                    MessageBox.Show($"Поставщик {this.manufacturer.Name} успешно удалена.", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
    }
}
