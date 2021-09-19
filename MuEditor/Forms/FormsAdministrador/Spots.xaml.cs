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
    /// Lógica interna para Spots.xaml
    /// </summary>
    public partial class Spots : Window
    {
        public Spots()
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

        private void LoadDatabase()
        {
            Config.database = "mu_online_login";
            Query query = new();
            ComboServer.ItemsSource = Connect.LoadData(query.loadServerCodeList).DefaultView;
            ComboServer.DisplayMemberPath = "server";
            Config.database = "mu_game";
            Query query1 = new();
            ComboWorld.ItemsSource = Connect.LoadData(query1.loadWorldName).DefaultView;
            ComboWorld.DisplayMemberPath = "name";
            Query query2 = new();
            filterMonsterWorld.ItemsSource = Connect.LoadData(query2.loadWorldName).DefaultView;
            filterMonsterWorld.DisplayMemberPath = "name";
            Query query3 = new();
            ComboMonster.ItemsSource = Connect.LoadData(query3.loadMonsterTemplate).DefaultView;
            ComboMonster.DisplayMemberPath = "Models Name";
            ComboMonster.SelectedValuePath = "model";
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDatabase();
        }

        private void ComboBox_DropDownClosed(object sender, EventArgs e)
        {
            if (ComboWorld.SelectedIndex == -1)
                return;
            Shop.worldName = ComboWorld.Text;
            Query query = new();
            MonsterSpot.worldEntry = int.Parse(Connect.LoadData(query.getWorldEntry).Rows[0].ItemArray[0].ToString()); //re-using class Shop
        }

        private void ComboMonster_DropDownClosed(object sender, EventArgs e)
        {
            if (ComboMonster.SelectedIndex == -1)
                return;
            MonsterSpot.id = int.Parse(ComboMonster.SelectedValue.ToString());
        }


        private void AddMonsterSpot()
        {
            MessageBoxCustomError boxError = new();
            if (x1.Text == "" || y1.Text == "" || x2.Text == "" || y2.Text == "" ||
                direciton.Text == "" || spawnDelay.Text == "" || distance.Text == "" ||
                timeMin.Text == "" || timeMax.Text == "" || respawnID.Text == "" || moveDistance.Text == "" || elementalAtt.Text == "")
            {
                boxError.CustomMessage.Text = "insert valor";
                boxError.ShowDialog();
                return;
            }

            Query query1 = new();
            MonsterSpot.guid = int.Parse(Connect.LoadData(query1.getLastGuidMonster).Rows[0].ItemArray[0].ToString()) + 1;
            MonsterSpot.x1 = int.Parse(x1.Text);
            MonsterSpot.y1 = int.Parse(y1.Text);
            MonsterSpot.x2 = int.Parse(x2.Text);
            MonsterSpot.y2 = int.Parse(y2.Text);
            MonsterSpot.direction = int.Parse(direciton.Text);
            MonsterSpot.spawnDelay = int.Parse(spawnDelay.Text);
            MonsterSpot.spawnDistance = int.Parse(distance.Text);
            MonsterSpot.respawnTimeMin = int.Parse(timeMin.Text);
            MonsterSpot.respawnTimeMax = int.Parse(timeMax.Text);
            MonsterSpot.respawnid = int.Parse(respawnID.Text);
            MonsterSpot.moveDistance = int.Parse(moveDistance.Text);
            MonsterSpot.itemBag = itemBag.Text;
            MonsterSpot.elementalAtt = int.Parse(elementalAtt.Text);
            MonsterSpot.disable = 0;  //int.Parse(disable.Text);
            Query query = new();
            Connect.Update(query.addMonsterSpot);


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddMonsterSpot();
        }

        private void ComboServer_DropDownClosed(object sender, EventArgs e)
        {
            if (ComboServer.SelectedIndex == -1)
                return;
            MonsterSpot.server = int.Parse(ComboServer.Text);

            Query query2 = new();
            DatagridMonster.ItemsSource = Connect.LoadData(query2.filterMonsterWorld).DefaultView;
            DatagridMonster.Columns[4].Visibility = Visibility.Hidden;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MessageBoxCustomError customError = new();
            if (MonsterSpot.guid == null)
            {
                customError.CustomMessage.Text = "Select Monster";
                customError.ShowDialog();
                return;
            }

            Query query = new Query();
            Connect.Update(query.DeleteMonsterSpot);


            Query query2 = new();
            DatagridMonster.ItemsSource = Connect.LoadData(query2.filterMonsterWorld).DefaultView;
            DatagridMonster.Columns[4].Visibility = Visibility.Hidden;
        }

        private void filterMonsterWorld_DropDownClosed(object sender, EventArgs e)
        {
            MonsterSpot.worldName = filterMonsterWorld.Text;
            Query query2 = new();
            DatagridMonster.ItemsSource = Connect.LoadData(query2.filterMonsterWorld).DefaultView;
            DatagridMonster.Columns[4].Visibility = Visibility.Hidden;
        }

        private void DatagridMonster_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            if (dg.SelectedItem is DataRowView row)
                MonsterSpot.guid = int.Parse(row["guid"].ToString());

            delete.Text = MonsterSpot.guid.ToString();
        }
    }
}
