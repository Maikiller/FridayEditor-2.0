using MuEditor.Database;
using MuEditor.Forms.Utils;
using MuEditor.Models;
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
    /// Lógica interna para SubServerCreate.xaml
    /// </summary>
    public partial class SubServerCreate : Window
    {
        public SubServerCreate()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void LoadServerLists()
        {
            Config.database = "mu_online_login";
            Query query = new();
            DatagridServerList.ItemsSource = Connect.LoadData(query.laodServerLists).DefaultView;
            Config.database = "mu_game";
            Query query1 = new();
            World.ItemsSource = Connect.LoadData(query1.world).DefaultView;
            World.DisplayMemberPath = "name";
            World.SelectedValuePath = "entry";
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadServerLists();
        }

        private void World_DropDownClosed(object sender, EventArgs e)
        {
            ServeLists.WorldEntry = int.Parse(World.SelectedValue.ToString());
        }

        private void DatagridServerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            if (dg.SelectedItem is DataRowView row)
                ServeLists.server = int.Parse(row["server"].ToString());
        }

        private void RefreshList()
        {
            Config.database = "mu_online_login";
            Query query = new();
            DatagridServerList.ItemsSource = Connect.LoadData(query.laodServerLists).DefaultView;
        }
        private void Inputs()
        {
            ServeLists.server = int.Parse(Server.Text);
            ServeLists.serverName = ServerName.Text;
            ServeLists.port = Port.Text;
            ServeLists.ip = IP.Text;
            ServeLists.x = int.Parse(x.Text);
            ServeLists.y = int.Parse(y.Text);
        }
        private void AddServerLists()
        {
            Config.database = "mu_online_login";
            Inputs();
            Query query = new();
            Connect.Update(query.addServerLists);
            RefreshList();
        }

        private void Type_DropDownClosed(object sender, EventArgs e)
        {
            ServeLists.type = Type.SelectedIndex;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Server.Text == "" || ServerName.Text == "" || Port.Text == "" || IP.Text == "" || x.Text == "" || y.Text == "")
            {
                MessageBoxCustomError customError = new();
                customError.CustomMessage.Text = "Invalid Values";
                customError.ShowDialog();
                return;
            }

            AddServerLists();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Config.database = "mu_online_login";
            Query query = new();
            Connect.Update(query.DeleteServerLists);
            RefreshList();
        }
    }
}
