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
    /// Lógica interna para ShopCreate.xaml
    /// </summary>
    public partial class ShopCreate : Window
    {
        public ShopCreate()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void LoadDatabase()
        {
            Config.database = "mu_game";
            Query query = new();
            DatagridMonsterModels.ItemsSource = Connect.LoadData(query.loadMonsterTemplate).DefaultView;
            DatagridShop.ItemsSource = Connect.LoadData(query.loadShopTemplate).DefaultView;
            DatagridMonsterModels.Columns[0].Visibility = Visibility.Hidden;
            DatagridShop.Columns[0].Visibility = Visibility.Hidden;
            ComboWorld.ItemsSource = Connect.LoadData(query.loadWorldName).DefaultView;
            ComboWorld.DisplayMemberPath = "name";

            Query query1 = new();
            Config.database = "mu_online_login";
            Favorite.AccountGUID = int.Parse(Connect.LoadData(query1.selectAccountAuth).Rows[0].ItemArray[0].ToString());
            ComboServer.ItemsSource = Connect.LoadData(query.loadServerCodeList).DefaultView;
            ComboServer.DisplayMemberPath = "server";
            ComboServer.SelectedIndex = 0;

            Config.database = "mu_editor_config";
            Query query2 = new();
            DatagridFavorite.ItemsSource = Connect.LoadData(query2.loadFavorite).DefaultView;
            DatagridFavorite.Columns[1].Visibility = Visibility.Hidden;

            //DatagridMonsterModels.ItemsSource = Connect.LoadData(query.loadMonsterTemplate).DefaultView.ToTable(true, "name").DefaultView;
            //DatagridShop.ItemsSource = Connect.LoadData(query.loadShopTemplate).DefaultView.ToTable(true, "name").DefaultView;
        }

        private void LoadShop()
        {
            Query query = new();
            if (Connect.LoadData(query.loadShopName).Rows.Count == 0)
            {
                /*  MessageBoxCustomError box = new();
                 box.CustomMessage.Text = "NPC Corrupted !";
                 box.ShowDialog();
                 SHOPName.Text = "";*/
                return;
            }
            DisableShop.IsChecked = false;
            SpawnDelay.Text = Connect.LoadData(query.loadShopName).Rows[0].ItemArray[1].ToString();
            SpawnDistance.Text = Connect.LoadData(query.loadShopName).Rows[0].ItemArray[2].ToString();
            SpawnTimeMin.Text = Connect.LoadData(query.loadShopName).Rows[0].ItemArray[3].ToString();
            SpawnTimeMax.Text = Connect.LoadData(query.loadShopName).Rows[0].ItemArray[4].ToString();
            SpawnID.Text = Connect.LoadData(query.loadShopName).Rows[0].ItemArray[5].ToString();
            MoveDistance.Text = Connect.LoadData(query.loadShopName).Rows[0].ItemArray[6].ToString();
            x1.Text = Connect.LoadData(query.loadShopName).Rows[0].ItemArray[7].ToString();
            y1.Text = Connect.LoadData(query.loadShopName).Rows[0].ItemArray[8].ToString();
            x2.Text = Connect.LoadData(query.loadShopName).Rows[0].ItemArray[9].ToString();
            y2.Text = Connect.LoadData(query.loadShopName).Rows[0].ItemArray[10].ToString();
            ElementalAtribute.Text = Connect.LoadData(query.loadShopName).Rows[0].ItemArray[11].ToString();
            Direction.Text = Connect.LoadData(query.loadShopName).Rows[0].ItemArray[12].ToString();
            PKText.Text = Connect.LoadData(query.loadShopName).Rows[0].ItemArray[13].ToString();
            ComboWorld.Text = Connect.LoadData(query.loadShopName).Rows[0].ItemArray[15].ToString();
            FindModels.Text = Connect.LoadData(query.loadShopName).Rows[0].ItemArray[16].ToString();
            PKLevel.Text = Connect.LoadData(query.loadShopName).Rows[0].ItemArray[17].ToString();
            ComboServer.Text = Connect.LoadData(query.loadShopName).Rows[0].ItemArray[18].ToString();

            Shop.monsterID = int.Parse(Connect.LoadData(query.getMonsterID).Rows[0].ItemArray[0].ToString());
            Shop.shopID = int.Parse(Connect.LoadData(query.getShopID).Rows[0].ItemArray[0].ToString());
            Shop.guid = int.Parse(Connect.LoadData(query.loadShopName).Rows[0].ItemArray[0].ToString());



            if (int.Parse(Connect.LoadData(query.loadShopName).Rows[0].ItemArray[14].ToString()) == 1)
                DisableShop.IsChecked = true;


        }

        private void LoadInputs()
        {
            Shop.pkLevel = int.Parse(PKLevel.Text);
            Shop.pkText = PKText.Text;
            Shop.worldName = ComboWorld.Text;
            Shop.disable = 0;
            Shop.spawnDelay = SpawnDelay.Text;
            Shop.spawnDistance = SpawnDistance.Text;
            Shop.spawnTimeMin = SpawnTimeMin.Text;
            Shop.spawnTimeMax = SpawnTimeMax.Text;
            Shop.spawnId = SpawnID.Text;
            Shop.moveDistance = MoveDistance.Text;
            Shop.x1 = int.Parse(x1.Text);
            Shop.y1 = int.Parse(y1.Text);
            Shop.x2 = int.Parse(x2.Text);
            Shop.y2 = int.Parse(y2.Text);
            Shop.elementalAtt = int.Parse(ElementalAtribute.Text);
            Shop.direction = int.Parse(Direction.Text);
            Shop.pkText = PKText.Text;
            Shop.pkLevel = int.Parse(PKLevel.Text);
            Shop.server = int.Parse(ComboServer.Text);
            Shop.shopName = SHOPName.Text;
            Shop.server = int.Parse(ComboServer.Text);





            Query query2 = new Query();
            if (Connect.LoadData(query2.getWorldEntry).Rows.Count == -1)
                return;

            if (ComboWorld.Text == "")
                return;

            Shop.worldID = int.Parse(Connect.LoadData(query2.getWorldEntry).Rows[0].ItemArray[0].ToString());

            if (DisableShop.IsChecked == true)
                Shop.disable = 1;
        }

        private void SaveNPC()
        {
            MessageBoxCustomError boxError = new();
            MessageBoxCustomCheck boxCheck = new();
            Config.database = "mu_game";

            if (SHOPName.Text == "")
            {
                boxError.CustomMessage.Text = "Enter NPC Name";
                boxError.ShowDialog();
                return;
            }

            LoadInputs();
            Query query1 = new Query();
            Shop.shopID = int.Parse(Connect.LoadData(query1.getLastGuidShop).Rows[0].ItemArray[0].ToString()) + 1;
            Shop.monsterID = int.Parse(Connect.LoadData(query1.getLastGuidMonster).Rows[0].ItemArray[0].ToString()) + 1;

            Query query = new Query();
            if (ComboWorld.Text == "")
            {
                boxError.CustomMessage.Text = "Select World Map";
                boxError.ShowDialog();
                return;
            }
            Connect.Update(query.saveShop);
            boxCheck.CustomMessage.Text = "SHOP [" + SHOPName.Text + "] Saved!";
            boxCheck.ShowDialog();
            LoadDatabase();

        }
        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            SaveNPC();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDatabase();
        }

        private void DatagridShop_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Config.database = "mu_game";
            DataGrid dg = (DataGrid)sender;
            if (dg.SelectedItem is DataRowView row)
            {
                Shop.shopName = row["Shop Name"].ToString();
                SHOPName.Text = row["Shop Name"].ToString();
            }
            LoadShop();
        }

        private void DatagridMonsterModels_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            if (dg.SelectedItem is DataRowView row)
            {
                Favorite.Models = int.Parse(row["model"].ToString());
                Shop.modelsID = int.Parse(row["model"].ToString());
                Shop.modelsName = row["Models Name"].ToString();
            }
        }

        private void DatagridFavorite_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            DataGrid dg = (DataGrid)sender;
            if (dg.SelectedItem is DataRowView row)
            {
                Favorite.Models = int.Parse(row["models"].ToString());
                Shop.modelsID = int.Parse(row["models"].ToString());
                Shop.modelsName = row["Favorite"].ToString();
            }
        }

        private void Window_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void FindCharacters_TextChanged(object sender, TextChangedEventArgs e)
        {
            Query query = new();
            DataView dv = Connect.LoadData(query.loadShopTemplate).DefaultView;
            dv.RowFilter = "`Shop Name` LIKE '" + FindShop.Text + "%'";
            DatagridShop.ItemsSource = dv;
            DatagridShop.Columns[0].Visibility = Visibility.Hidden;
        }

        private void FindCharacters_Copy12_TextChanged(object sender, TextChangedEventArgs e)
        {
            Config.database = "mu_game";
            Query query = new();
            DataView dv = Connect.LoadData(query.loadMonsterTemplate).DefaultView;
            dv.RowFilter = "`Models Name` LIKE '" + FindModels.Text + "%'";
            DatagridMonsterModels.ItemsSource = dv;
            DatagridMonsterModels.Columns[0].Visibility = Visibility.Hidden;
        }

        private void SaveFavorite()
        {
            Query query1 = new();
            Config.database = "mu_online_login";
            Favorite.AccountGUID = int.Parse(Connect.LoadData(query1.selectAccountAuth).Rows[0].ItemArray[0].ToString());
            Config.database = "mu_editor_config";

            Query query2 = new();
            if (Connect.LoadData(query2.duplicateFavorite).Rows.Count > 0)
            {
                if (int.Parse(Connect.LoadData(query2.duplicateFavorite).Rows[0].ItemArray[0].ToString()) == Favorite.Models)
                {
                    MessageBoxCustomError box = new();
                    box.CustomMessage.Text = "" + Shop.modelsName + " already existing Favorite";
                    box.ShowDialog();
                    return;
                }
            }

            Query query = new();
            Connect.Update(query.saveModelsFavorite);
            DatagridFavorite.ItemsSource = Connect.LoadData(query.loadFavorite).DefaultView;
        }

        private void Button_Click_Favorite(object sender, RoutedEventArgs e)
        {
            SaveFavorite();
        }

        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Config.applicationAlert = true;
            MessageBoxCustomAlert customAlert = new();
            MessageBoxCustomError customError = new();
            MessageBoxCustomCheck customCheck = new();

            if (Shop.monsterID == null && Shop.monsterID == null)
            {
                customError.CustomMessage.Text = "Select Shop";
                customError.ShowDialog();
                return;
            }

            customAlert.CustomMessage.Text = "Are you sure to delete the [" + Shop.shopName + "]";
            customAlert.ShowDialog();

            if (Config.applicationAlert == false)
                return;

            Query query = new();
            Connect.Update(query.deleteShop);

            customCheck.CustomMessage.Text = "SHOP " + Shop.shopName + " Deleted";
            customCheck.ShowDialog();
            Shop.monsterID = null;
            Shop.guid = null;
            Shop.shopName = "";
            LoadDatabase();

        }

        private void update(object sender, RoutedEventArgs e)
        {

            MessageBoxCustomError customError = new();
            if (SHOPName.Text == "")
            {
                customError.CustomMessage.Text = "Enter NPC Name";
                customError.ShowDialog();
                return;
            }

            Config.applicationAlert = true;

            LoadInputs();
            Query query = new();
            Connect.Update(query.updateShop);
            LoadDatabase();
        }

        private void DatagridShop_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ShopItemEditor shop = new();
            shop.ComboNPC.Text = Shop.shopName;
            shop.ShowDialog();
        }
    }
}
