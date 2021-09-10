using MuEditor.Forms.FormsUsers;
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

namespace MuEditor.Forms.FormsAdministrador
{
    /// <summary>
    /// Lógica interna para Main.xaml
    /// </summary>
    public partial class MainAdmin : Window
    {
        public MainAdmin()
        {
            InitializeComponent();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Main main = new();
            main.Visibility = Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Accounts accounts = new();
            accounts.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Characters characters = new();
            characters.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Guild guild = new();
            guild.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Events events = new();
            events.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Spots spots = new();
            spots.Show();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            ShopCreate shopCreate = new();
            shopCreate.Show();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            ShopEditor shopEditor = new();
            shopEditor.Show();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            TeleportCreate teleportCreate = new();
            teleportCreate.Show();
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            MiniMapEditor miniMapEditor = new MiniMapEditor();
            miniMapEditor.Show();
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            ServerSettings serverSettings = new();
            serverSettings.Show();
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            SubServerCreate subServerCreate = new();
            subServerCreate.Show();
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Working");
        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Working");
        }
    }
}
