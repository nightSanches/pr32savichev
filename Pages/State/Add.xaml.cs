﻿using pr32savichev;
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

namespace savichev32pr.Pages.State
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Page
    {
        pr32savichev.Classes.State changeState;
        public Add(pr32savichev.Classes.State state = null)
        {
            InitializeComponent();
            if (state != null)
            {
                this.changeState = state;
                this.tbName.Text = state.Name;
                this.tbSubname.Text = state.Description;
                addBth.Content = "Изменить";
            }
        }

        private void AddState(object sender, RoutedEventArgs e)
        {
            if(!String.IsNullOrEmpty(tbName.Text))
            {
                if(!String.IsNullOrEmpty(tbSubname.Text))
                {
                    if(this.changeState == null)
                    {
                        pr32savichev.Classes.State newState = new pr32savichev.Classes.State()
                        {
                            Name = tbName.Text,
                            Subname = tbSubname.Text,
                            Description = tbDescription.Text
                        };
                        newState.Save();
                        MessageBox.Show($"Состояние {newState.Name} успешно добавлено", "Уведомление");
                        MainWindow.mainWindow.OpenPage(new Pages.State.Add(newState));
                    }
                    else
                    {
                        changeState.Name = tbName.Text;
                        changeState.Subname = tbSubname.Text;
                        changeState.Description = tbDescription.Text;
                        changeState.Save(true);
                    }
                }
                else
                {
                    MessageBox.Show("Пожалуйста укажите сокращенное наименование состояния.", "Предупреждение");
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста укажите наименование состояния.", "Предупреждение");
            }
        }
    }
}
