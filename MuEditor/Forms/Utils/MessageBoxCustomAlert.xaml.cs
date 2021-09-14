﻿using MuEditor.Database;
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
using System.Windows.Shapes;

namespace MuEditor.Forms.Utils
{
    /// <summary>
    /// Lógica interna para MessageBoxCustomAlert.xaml
    /// </summary>
    public partial class MessageBoxCustomAlert : Window
    {
        public MessageBoxCustomAlert()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Config.applicationAlert = true;
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Config.applicationAlert = false;
            Close();
        }
    }
}
