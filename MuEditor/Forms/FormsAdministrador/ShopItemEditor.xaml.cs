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
    /// Lógica interna para ShopEditor.xaml
    /// </summary>
    public partial class ShopItemEditor : Window
    {
        public ShopItemEditor()
        {
            InitializeComponent();
        }

        [Flags]
        public enum MyChechboxes
        {
            option1 = 1,
            option2 = 2,
            option3 = 4,
            option4 = 8,
            option5 = 16,
            option6 = 32,
        }

        private void LoadDataBase()
        {
            Config.database = "mu_game";
            Query query = new();
            ComboNPC.ItemsSource = Connect.LoadData(query.loadShopTemplate).DefaultView;
            ComboNPC.DisplayMemberPath = "Shop Name";
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
            LoadDataBase();
        }


        private void LoadShopItems()
        {

            Shop.shopName = ComboNPC.Text;
            Query query = new();
            if (Connect.LoadData(query.getShopID).Rows.Count > 0)
                Shop.guid = int.Parse(Connect.LoadData(query.getShopID).Rows[0].ItemArray[0].ToString());

            Query query1 = new();
            DatagridShop.ItemsSource = Connect.LoadData(query1.loadItemsShop).DefaultView;
            DatagridShop.Columns[0].Visibility = Visibility.Hidden;
            DatagridShop.Columns[1].Visibility = Visibility.Hidden;
        }

        private void ComboNPC_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //LoadShopItems();
        }

        private void ComboNPC_DropDownClosed(object sender, EventArgs e)
        {
            LoadShopItems();
        }

        private void LoadItemType()
        {
            Item.typeItemCombo = ComboTypeItem.SelectedIndex;
            Query query = new();
            DatagridItems.ItemsSource = Connect.LoadData(query.loadItemCategory).DefaultView;
            //DatagridItems.Columns[0].Visibility = Visibility.Hidden;

        }
        private void ComboTypeItem_DropDownClosed(object sender, EventArgs e)
        {
            LoadItemType();
        }

        private void ComboTypeItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadItemType();
        }

        private void LoadTypeItem()
        {
            switch (Item.typeItemSelect)
            {
                case 4:
                    Ancient.Visibility = Visibility.Hidden;
                    Luck.Visibility = Visibility.Hidden;
                    Skill.Visibility = Visibility.Hidden;
                    option1.Visibility = Visibility.Hidden;
                    option2.Visibility = Visibility.Hidden;
                    option3.Visibility = Visibility.Hidden;
                    option4.Visibility = Visibility.Hidden;
                    option5.Visibility = Visibility.Hidden;
                    option6.Visibility = Visibility.Hidden;
                    ExeText.Visibility = Visibility.Hidden;
                    break;
                case 0:
                case 1:
                case 2:
                case 3:
                case 5:
                    option1.Content = "Mob Kill +mana/8";
                    option2.Content = "Mob Kill +life/8";
                    option3.Content = "Attack(Wizaedy) Speed +7";
                    option4.Content = "Damage +2%";
                    option5.Content = "Damage +level/20";
                    option6.Content = "Exc Damage Rate +10%";
                    Luck.Content = "Luck";
                    Skill.Content = "Skill";
                    Ancient.Content = "Ancient";
                    Luck.Visibility = Visibility.Visible;
                    Ancient.Visibility = Visibility.Visible;
                    Skill.Visibility = Visibility.Visible;
                    option1.Visibility = Visibility.Visible;
                    option2.Visibility = Visibility.Visible;
                    option3.Visibility = Visibility.Visible;
                    option4.Visibility = Visibility.Visible;
                    option5.Visibility = Visibility.Visible;
                    option6.Visibility = Visibility.Visible;
                    ExeText.Visibility = Visibility.Visible;
                    break;

                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                case 11:
                    option1.Content = "Zen Drop +30%";
                    option2.Content = "Def Sucess Rate +10%";
                    option3.Content = "Reflect +5%";
                    option4.Content = "Damage Decrease +4%";
                    option5.Content = "Mana +4%";
                    option6.Content = "HP +4%";
                    Luck.Content = "Luck";
                    Skill.Content = "Skill";
                    Ancient.Content = "Ancient";
                    Luck.Visibility = Visibility.Visible;
                    Ancient.Visibility = Visibility.Visible;
                    Skill.Visibility = Visibility.Visible;
                    option1.Visibility = Visibility.Visible;
                    option2.Visibility = Visibility.Visible;
                    option3.Visibility = Visibility.Visible;
                    option4.Visibility = Visibility.Visible;
                    option5.Visibility = Visibility.Visible;
                    option6.Visibility = Visibility.Visible;
                    ExeText.Visibility = Visibility.Visible;
                    break;
                case 12:
                    option1.Content = "Increase 5 Atacck(Wizard)Speed";
                    option2.Content = "Increase Max AG by 50";
                    option3.Content = "Increase chance true Damage 3%";
                    option4.Content = "Inceases Mana by 125";
                    option5.Content = "Inceases Life by 125";
                    option1.Visibility = Visibility.Visible;
                    option2.Visibility = Visibility.Visible;
                    option3.Visibility = Visibility.Visible;
                    option4.Visibility = Visibility.Visible;
                    option5.Visibility = Visibility.Visible;
                    option6.Visibility = Visibility.Visible;
                    Luck.Visibility = Visibility.Hidden;
                    Ancient.Visibility = Visibility.Hidden;
                    Skill.Visibility = Visibility.Hidden;
                    ExeText.Visibility = Visibility.Visible;
                    break;

                case 13:
                case 14:
                case 15:
                case 16:
                case 17:
                case 18:
                case 19:
                case 20:
                    Ancient.Visibility = Visibility.Hidden;
                    Luck.Visibility = Visibility.Hidden;
                    Skill.Visibility = Visibility.Hidden;
                    option1.Visibility = Visibility.Hidden;
                    option2.Visibility = Visibility.Hidden;
                    option3.Visibility = Visibility.Hidden;
                    option4.Visibility = Visibility.Hidden;
                    option5.Visibility = Visibility.Hidden;
                    option6.Visibility = Visibility.Hidden;
                    ExeText.Visibility = Visibility.Hidden;
                    break;

            }
        }
        private void LoadInputs()
        {
            Query query = new();
            option1.IsChecked = false;
            Skill.IsChecked = false;
            Luck.IsChecked = false;
            Ancient.IsChecked = false;
            if (Connect.LoadData(query.loadItem).Rows.Count > 0)
            {
                Level.Text = Connect.LoadData(query.loadItem).Rows[0].ItemArray[1].ToString();
                Quant.Text = Connect.LoadData(query.loadItem).Rows[0].ItemArray[2].ToString();
                Option.Text = Connect.LoadData(query.loadItem).Rows[0].ItemArray[5].ToString();
                int sum = int.Parse(Connect.LoadData(query.loadItem).Rows[0].ItemArray[6].ToString());
                Slot1.Text = Connect.LoadData(query.loadItem).Rows[0].ItemArray[8].ToString();
                Slot2.Text = Connect.LoadData(query.loadItem).Rows[0].ItemArray[9].ToString();
                Slot3.Text = Connect.LoadData(query.loadItem).Rows[0].ItemArray[10].ToString();
                Slot4.Text = Connect.LoadData(query.loadItem).Rows[0].ItemArray[11].ToString();
                Slot5.Text = Connect.LoadData(query.loadItem).Rows[0].ItemArray[12].ToString();
                Price.Text = Connect.LoadData(query.loadItem).Rows[0].ItemArray[13].ToString();
                Positon.Text = Connect.LoadData(query.loadItem).Rows[0].ItemArray[14].ToString();

                if (int.Parse(Connect.LoadData(query.loadItem).Rows[0].ItemArray[3].ToString()) == 1)
                    Skill.IsChecked = true;

                if (int.Parse(Connect.LoadData(query.loadItem).Rows[0].ItemArray[4].ToString()) == 1)
                {
                    Luck.IsChecked = true;
                }


                if (int.Parse(Connect.LoadData(query.loadItem).Rows[0].ItemArray[7].ToString()) == 1)
                    Ancient.IsChecked = true;

                MyChechboxes checkeds = (MyChechboxes)sum;

                bool option1IsChecked = checkeds.HasFlag(MyChechboxes.option1);
                bool option2IsChecked = checkeds.HasFlag(MyChechboxes.option2);
                bool option3IsChecked = checkeds.HasFlag(MyChechboxes.option3);
                bool option4IsChecked = checkeds.HasFlag(MyChechboxes.option4);
                bool option5IsChecked = checkeds.HasFlag(MyChechboxes.option5);
                bool option6IsChecked = checkeds.HasFlag(MyChechboxes.option6);

                option1.IsChecked = option1IsChecked;
                option2.IsChecked = option2IsChecked;
                option3.IsChecked = option3IsChecked;
                option4.IsChecked = option4IsChecked;
                option5.IsChecked = option5IsChecked;
                option6.IsChecked = option6IsChecked;

                string level = Connect.LoadData(query.loadItem).Rows[0].ItemArray[1].ToString();
                string exeText = null;
                dynamic color = Brushes.White;

                switch (int.Parse(level))
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                        color = Brushes.White;
                        break;
                    case 7:
                    case 8:
                    case 9:
                    case 10:
                    case 11:
                    case 12:
                    case 13:
                    case 14:
                    case 15:
                        color = Brushes.Yellow;
                        break;
                }

                if (sum > 0)
                {
                    exeText = "Excellent ";
                    color = Brushes.LightGreen;
                }


                Statics.Document.Blocks.Clear();
                Statics.Document.Blocks.Add(new Paragraph(new Run(exeText + Connect.LoadData(query.loadItem).Rows[0].ItemArray[0].ToString() + " +" + level) { Foreground = color }));
                if (int.Parse(Connect.LoadData(query.loadItem).Rows[0].ItemArray[4].ToString()) == 1)
                {
                    Statics.Document.Blocks.Add(new Paragraph(new Run("Luck (success rate of jewel of Soul +25%)")));
                    Statics.Document.Blocks.Add(new Paragraph(new Run("Luck (critical damage Dmg +5%)")));
                }

                if (option6.IsChecked == true && Item.typeItemSelect >= 6 && Item.typeItemSelect <= 11)
                {
                    Statics.Document.Blocks.Add(new Paragraph(new Run("Increases Life Mana by 4%")));
                }
                if (option5.IsChecked == true && Item.typeItemSelect >= 6 && Item.typeItemSelect <= 11)
                {
                    Statics.Document.Blocks.Add(new Paragraph(new Run("Increases Maximum Mana by 4%")));
                }
                if (option4.IsChecked == true && Item.typeItemSelect >= 6 && Item.typeItemSelect <= 11)
                {
                    Statics.Document.Blocks.Add(new Paragraph(new Run("Decreases Damage by 4%")));
                }
                if (option3.IsChecked == true && Item.typeItemSelect >= 6 && Item.typeItemSelect <= 11)
                {
                    Statics.Document.Blocks.Add(new Paragraph(new Run("Reflect Damage by 5%")));
                }
                if (option2.IsChecked == true && Item.typeItemSelect >= 6 && Item.typeItemSelect <= 11)
                {
                    Statics.Document.Blocks.Add(new Paragraph(new Run("Increases Defense Sucess Rate by 10%")));
                }
                if (option1.IsChecked == true && Item.typeItemSelect >= 6 && Item.typeItemSelect <= 11)
                {
                    Statics.Document.Blocks.Add(new Paragraph(new Run("Increases the amount of Zen acquired for hunting monster by 30%")));
                }

                if (option6.IsChecked == true && Item.typeItemSelect >= 0 && Item.typeItemSelect <= 5)
                {
                    Statics.Document.Blocks.Add(new Paragraph(new Run("Increases Excellent Damage Chance by 10%")));
                }

                if (option5.IsChecked == true && Item.typeItemSelect >= 0 && Item.typeItemSelect <= 4)
                {
                    Statics.Document.Blocks.Add(new Paragraph(new Run("ATK Dmg Increases by 1 Every 20Lvd")));
                }
                if (option4.IsChecked == true && Item.typeItemSelect >= 0 && Item.typeItemSelect <= 4)
                {
                    Statics.Document.Blocks.Add(new Paragraph(new Run("ATK Dmg Increases by 2%")));
                }

                if (option5.IsChecked == true && Item.typeItemSelect >= 0 && Item.typeItemSelect == 5)
                {
                    Statics.Document.Blocks.Add(new Paragraph(new Run("WIZ Dmg Increases by 1 Every 20Lv")));
                }
                if (option4.IsChecked == true && Item.typeItemSelect >= 0 && Item.typeItemSelect == 5)
                {
                    Statics.Document.Blocks.Add(new Paragraph(new Run("WIZ Dmg Increases by 2%")));
                }

                if (option3.IsChecked == true && Item.typeItemSelect >= 0 && Item.typeItemSelect <= 5)
                {
                    Statics.Document.Blocks.Add(new Paragraph(new Run("Inceases 7 Attack(Wizardry) speed")));
                }
                if (option2.IsChecked == true && Item.typeItemSelect >= 0 && Item.typeItemSelect <= 5)
                {
                    Statics.Document.Blocks.Add(new Paragraph(new Run("obtains(Life/8) when monster is killed")));
                }
                if (option1.IsChecked == true && Item.typeItemSelect >= 0 && Item.typeItemSelect <= 5)
                {
                    Statics.Document.Blocks.Add(new Paragraph(new Run("obtains(Mana/8) when monster is killed")));
                }

                if (option5.IsChecked == true && Item.typeItemSelect == 12)
                {
                    Statics.Document.Blocks.Add(new Paragraph(new Run("Inceases Life by 125")));
                }
                if (option4.IsChecked == true && Item.typeItemSelect == 12)
                {
                    Statics.Document.Blocks.Add(new Paragraph(new Run("Inceases Mana by 125")));
                }
                if (option3.IsChecked == true && Item.typeItemSelect == 12)
                {
                    Statics.Document.Blocks.Add(new Paragraph(new Run("Increase chance true Damage 3%")));
                }
                if (option2.IsChecked == true && Item.typeItemSelect == 12)
                {
                    Statics.Document.Blocks.Add(new Paragraph(new Run("Increase Max AG by 50")));
                }
                if (option1.IsChecked == true && Item.typeItemSelect == 12)
                {
                    Statics.Document.Blocks.Add(new Paragraph(new Run("Increase 5 Atacck(Wizard)Speed")));
                }
            }
           

           
            //Statics.Document.PageWidth = 1000;
            LoadTypeItem();
        }
        private void DatagridShop_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            if (dg.SelectedItem is DataRowView row)
            {
                Item.itemGUID = int.Parse(row["guid"].ToString());
                Item.typeItemSelect = int.Parse(row["type"].ToString());
            }
            LoadInputs();
        }

        private void DatagridItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            if (dg.SelectedItem is DataRowView row)
            {
                Item.typeItemSelect = int.Parse(row["i_type"].ToString());
                Item.indexItemSelect = int.Parse(row["i_index"].ToString());
            }
            Ancient.IsChecked = false;
            Luck.IsChecked = false;
            Skill.IsChecked = false;
            option1.IsChecked = false;
            option2.IsChecked = false;
            option3.IsChecked = false;
            option4.IsChecked = false;
            option5.IsChecked = false;
            option6.IsChecked = false;
            LoadTypeItem();
        }

        private void InputsPopulate()
        {
            int Check1 = option1.IsChecked == true ? 1 : 0;
            int Check2 = option2.IsChecked == true ? 2 : 0;
            int Check3 = option3.IsChecked == true ? 4 : 0;
            int Check4 = option4.IsChecked == true ? 8 : 0;
            int Check5 = option5.IsChecked == true ? 16 : 0;
            int Check6 = option6.IsChecked == true ? 32 : 0;
            int result = Check1 + Check2 + Check3 + Check4 + Check5 + Check6;

            Item.skill = 0;
            Item.luck = 0;
            Item.excellent = 0;
            Item.ancient = 0;
            Item.option = 0;

            Item.level = int.Parse(Level.Text);
            Item.durability = int.Parse(Quant.Text);
            Item.socket_1 = int.Parse(Slot1.Text);
            Item.socket_2 = int.Parse(Slot2.Text);
            Item.socket_3 = int.Parse(Slot3.Text);
            Item.socket_4 = int.Parse(Slot4.Text);
            Item.socket_5 = int.Parse(Slot5.Text);
            Item.price = int.Parse(Price.Text);
            Item.id = int.Parse(Positon.Text);
            Item.option = int.Parse(Option.Text);
            Item.excellent = result;

            if (Skill.IsChecked == true)
                Item.skill = 1;
            if (Luck.IsChecked == true)
                Item.luck = 1;
            if (Ancient.IsChecked == true)
                Item.ancient = 1;
        }

        private void AddItemToNPC()
        {
            InputsPopulate();

            Query query = new();
            Connect.Update(query.additemToNPC);
            LoadShopItems();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddItemToNPC();
        }

        private void UpdateItemToNPC()
        {
            InputsPopulate();

            Query query = new();
            Connect.Update(query.updateItemToNPC);
            LoadShopItems();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            UpdateItemToNPC();
        }

        private void DeleteItemToNPC()
        {
            Query query = new();
            Connect.Update(query.deleteItemToNPC);
            LoadShopItems();
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            DeleteItemToNPC();
           
        }
    }
}
