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
using System.Windows.Shapes;

namespace practice.Forms
{
    /// <summary>
    /// Логика взаимодействия для Organizator.xaml
    /// </summary>
    public partial class Organizator : Window
    {
        public Organizator()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            JuryModeratorRegistration registration = new JuryModeratorRegistration();
            registration.ShowDialog();
        }
    }
}
