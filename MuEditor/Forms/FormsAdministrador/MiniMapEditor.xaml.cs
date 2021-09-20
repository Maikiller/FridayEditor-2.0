using MuEditor.Database;
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
    /// Lógica interna para MiniMapEditor.xaml
    /// </summary>
    public partial class MiniMapEditor : Window
    {
        public MiniMapEditor()
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
            AddMiniMap();
        }

        private void Race_DropDownClosed(object sender, EventArgs e)
        {
            MiniMap.worldEntry = int.Parse(ComboWorld.SelectedValue.ToString());
            if (MiniMap.server == null || MiniMap.worldEntry == null)
                return;

            Config.database = "mu_game";
            Query query = new();
            DatagridMiniMap.ItemsSource = Connect.LoadData(query.loadMiniMapSelected).DefaultView;
            DatagridMiniMap.Columns[2].Visibility = Visibility.Hidden;
        }

        private void ComboServer_DropDownClosed(object sender, EventArgs e)
        {
            MiniMap.server = int.Parse(ComboServer.Text);
            if (MiniMap.server == null || MiniMap.worldEntry == null)
                return;

            Config.database = "mu_game";
            Query query = new();
            DatagridMiniMap.ItemsSource = Connect.LoadData(query.loadMiniMapSelected).DefaultView;
            DatagridMiniMap.Columns[2].Visibility = Visibility.Hidden;
        }

        private void OnLoad()
        {
            Config.database = "mu_editor_config";
            Query query3 = new();
            ComboType.ItemsSource = Connect.LoadData(query3.loadIcons).DefaultView;
            ComboType.DisplayMemberPath = "name";
            ComboType.SelectedValuePath = "type";

            Config.database = "mu_game";
            Query query1 = new();
            ComboWorld.ItemsSource = Connect.LoadData(query1.world).DefaultView;
            ComboWorld.DisplayMemberPath = "name";
            ComboWorld.SelectedValuePath = "entry";
            Config.database = "mu_online_login";
            Query query2 = new();
            ComboServer.ItemsSource = Connect.LoadData(query2.loadServerCodeList).DefaultView;
            ComboServer.DisplayMemberPath = "server";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            OnLoad();
        }

        private void ComboType_DropDownClosed(object sender, EventArgs e)
        {
            MiniMap.type = int.Parse(ComboType.SelectedValue.ToString());
            MessageBox.Show(MiniMap.type.ToString());
        }

        private void Inputs()
        {
            MiniMap.x = int.Parse(x.Text);
            MiniMap.y = int.Parse(y.Text);
            MiniMap.text = text.Text;
        }

        private void AddMiniMap()
        {
            Inputs();
            Query query = new();
            MiniMap.id = int.Parse(Connect.LoadData(query.countMaxMinimap).Rows[0].ItemArray[0].ToString()) + 1;

            Query query1 = new();
            Connect.Update(query1.saveIcons);

            Config.database = "mu_game";
            Query query2 = new();
            DatagridMiniMap.ItemsSource = Connect.LoadData(query2.loadMiniMapSelected).DefaultView;
        }

        private void DatagridMiniMap_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            if (dg.SelectedItem is DataRowView row)
                MiniMap.id = int.Parse(row["index"].ToString());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void UpdateMiniMap()
        {
            Inputs();
            Query query = new();
            Connect.Update(query.updateIcons);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            UpdateMiniMap();
        }
    }
}
