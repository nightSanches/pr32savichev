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

namespace savichev32pr.Pages.Manufacturer
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public IEnumerable<pr32savichev.Classes.Manufacturer> AllManufacturers = pr32savichev.Classes.Manufacturer.AllManufacturers();
        public Main()
        {
            InitializeComponent();
            foreach (pr32savichev.Classes.Manufacturer manufacturer in AllManufacturers)
            {
                manufacturerParent.Children.Add(new Manufacturer.Elements.Manufacturer(manufacturer, this));
            }
        }
    }
}
