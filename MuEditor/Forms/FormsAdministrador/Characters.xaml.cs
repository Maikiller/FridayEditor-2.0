using MuEditor.Database;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Lógica interna para Characters.xaml
    /// </summary>
    public partial class Characters : Window
    {
        public Characters()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Config.database = "mu_online_characters";
            Query query = new();
            DatagridCharacters.ItemsSource = Connect.LoadData(query.LoadAllCharacter).DefaultView;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Query query = new();
            DataView dv = Connect.LoadData(query.LoadAllCharacter).DefaultView;
            dv.RowFilter = "name LIKE '" + FindCharacters.Text + "%'";
            DatagridCharacters.ItemsSource = dv;
        }

        private void DatagridAccounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
