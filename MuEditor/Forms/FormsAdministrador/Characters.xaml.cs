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
using MuEditor.Models;
using MuEditor.Forms.Utils;

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

        public class RaceID
        {
            public string flag { get; set; }
            public int flag_valor { get; set; }

            public List<RaceID> list = new();

            public List<RaceID> ListFlags()
            {
                list.Add(new RaceID { flag = "DARK WIZARD", flag_valor = 0 });
                list.Add(new RaceID { flag = "SOUL MASTER", flag_valor = 1 });
                list.Add(new RaceID { flag = "GRAND MASTER", flag_valor = 3 });
                list.Add(new RaceID { flag = "SOUL WIZARD", flag_valor = 7 });
                list.Add(new RaceID { flag = "-------------" });
                list.Add(new RaceID { flag = "DARK KNIGHT", flag_valor = 16 });
                list.Add(new RaceID { flag = "BLADE KNIGHT", flag_valor = 17 });
                list.Add(new RaceID { flag = "BLADE MASTER", flag_valor = 19 });
                list.Add(new RaceID { flag = "DRAGON KNIGHT", flag_valor = 23 });
                list.Add(new RaceID { flag = "-------------" });
                list.Add(new RaceID { flag = "FAIRY ELF", flag_valor = 32 });
                list.Add(new RaceID { flag = "MUSE ELF", flag_valor = 33 });
                list.Add(new RaceID { flag = "HIGH ELF", flag_valor = 35 });
                list.Add(new RaceID { flag = "NOBLE ELF", flag_valor = 39 });
                list.Add(new RaceID { flag = "-------------" });
                list.Add(new RaceID { flag = "MAGIC GLADIATOR", flag_valor = 48 });
                list.Add(new RaceID { flag = "DUEL MASTER", flag_valor = 51 });
                list.Add(new RaceID { flag = "MAGIC KNIGHT", flag_valor = 55 });
                list.Add(new RaceID { flag = "-------------" });
                list.Add(new RaceID { flag = "DARK LORD", flag_valor = 64 });
                list.Add(new RaceID { flag = "LORD EMPEROR", flag_valor = 67 });
                list.Add(new RaceID { flag = "EMPIRE LORD", flag_valor = 71 });
                list.Add(new RaceID { flag = "-------------" });
                list.Add(new RaceID { flag = "SUMMONER", flag_valor = 80 });
                list.Add(new RaceID { flag = "BLOODY SUMMONER", flag_valor = 81 });
                list.Add(new RaceID { flag = "DIMENSION MASTER", flag_valor = 83 });
                list.Add(new RaceID { flag = "DIMENSIONER", flag_valor = 87 });
                list.Add(new RaceID { flag = "-------------" });
                list.Add(new RaceID { flag = "RAGE FIGHTER", flag_valor = 96 });
                list.Add(new RaceID { flag = "FIST MASTER", flag_valor = 99 });
                list.Add(new RaceID { flag = "FIST BLASER", flag_valor = 106 });
                list.Add(new RaceID { flag = "-------------" });
                list.Add(new RaceID { flag = "GROW LANCER", flag_valor = 112 });
                list.Add(new RaceID { flag = "MIRAGE LANCER", flag_valor = 115 });
                list.Add(new RaceID { flag = "SHINING LANCER", flag_valor = 119 });
                list.Add(new RaceID { flag = "-------------" });
                list.Add(new RaceID { flag = "RUNE WIZARD", flag_valor = 128 });
                list.Add(new RaceID { flag = "RUNE SPELL MASTER", flag_valor = 129 });
                list.Add(new RaceID { flag = "GRAND RUNE MASTER", flag_valor = 131 });
                list.Add(new RaceID { flag = "MAJESTIC RUNE WIZARD", flag_valor = 135 });
                list.Add(new RaceID { flag = "-------------" });
                list.Add(new RaceID { flag = "SLAYER", flag_valor = 144 });
                list.Add(new RaceID { flag = "ROYAL SLAYER", flag_valor = 145 });
                list.Add(new RaceID { flag = "MASTER SLAYER", flag_valor = 147 });
                list.Add(new RaceID { flag = "SLAUGHTERER", flag_valor = 151 });
                list.Add(new RaceID { flag = "-------------" });
                list.Add(new RaceID { flag = "GUN CRUSHER", flag_valor = 160 });
                list.Add(new RaceID { flag = "GUN BREAKER", flag_valor = 161 });
                list.Add(new RaceID { flag = "MASTER GUN BREAKER", flag_valor = 163 });
                list.Add(new RaceID { flag = "HEIST GUN CRUSHER", flag_valor = 167 });
                return list;
            }
        }

        public void LoadRaceComboBox()
        {
            RaceID race = new();
            race.ListFlags();
            Race.ItemsSource = race.list;
            Race.DisplayMemberPath = "flag";
            Race.SelectedValuePath = "flag_valor";
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
            LoadRaceComboBox();
            DatagridCharacters.ItemsSource = Connect.LoadData(query.loadAllCharacter).DefaultView;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Query query = new();
            DataView dv = Connect.LoadData(query.loadAllCharacter).DefaultView;
            dv.RowFilter = "name LIKE '" + FindCharacters.Text + "%'";
            DatagridCharacters.ItemsSource = dv;
        }

        private void LoadCharacterName()
        {
            Query query = new();
            Status.Foreground = Brushes.Red;
            Character.guid = int.Parse(Connect.LoadData(query.loadCharacterName).Rows[0].ItemArray[0].ToString());
            Status.Text = "Offline";
            ActiveGM.IsChecked = false;
            AllPermissions.IsChecked = false;
            Name.Text = Connect.LoadData(query.loadCharacterName).Rows[0].ItemArray[3].ToString();
            Level.Text = Connect.LoadData(query.loadCharacterName).Rows[0].ItemArray[4].ToString();
            //Experience.Text = Connect.LoadData(query.loadCharacterName).Rows[0].ItemArray[7].ToString();
            Points.Text = Connect.LoadData(query.loadCharacterName).Rows[0].ItemArray[10].ToString();
            LevelMaster.Text = Connect.LoadData(query.loadCharacterName).Rows[0].ItemArray[5].ToString();
            //ExperienceMaster.Text = Connect.LoadData(query.loadCharacterName).Rows[0].ItemArray[8].ToString();
            PointsMaster.Text = Connect.LoadData(query.loadCharacterName).Rows[0].ItemArray[11].ToString();
            LevelMajestic.Text = Connect.LoadData(query.loadCharacterName).Rows[0].ItemArray[6].ToString();
            //ExperienceMajestic.Text = Connect.LoadData(query.loadCharacterName).Rows[0].ItemArray[9].ToString();
            PointsMajestic.Text = Connect.LoadData(query.loadCharacterName).Rows[0].ItemArray[12].ToString();
            Strength.Text = Connect.LoadData(query.loadCharacterName).Rows[0].ItemArray[13].ToString();
            Agility.Text = Connect.LoadData(query.loadCharacterName).Rows[0].ItemArray[14].ToString();
            Vitality.Text = Connect.LoadData(query.loadCharacterName).Rows[0].ItemArray[15].ToString();
            Energy.Text = Connect.LoadData(query.loadCharacterName).Rows[0].ItemArray[16].ToString();
            Leadership.Text = Connect.LoadData(query.loadCharacterName).Rows[0].ItemArray[17].ToString();
            Zen.Text = Connect.LoadData(query.loadCharacterName).Rows[0].ItemArray[18].ToString();
            GoblinPoints.Text = Connect.LoadData(query.loadCharacterName).Rows[0].ItemArray[22].ToString();
            AddFruit.Text = Connect.LoadData(query.loadCharacterName).Rows[0].ItemArray[19].ToString();
            DecFruit.Text = Connect.LoadData(query.loadCharacterName).Rows[0].ItemArray[20].ToString();
            Character.race = int.Parse(Connect.LoadData(query.loadCharacterName).Rows[0].ItemArray[2].ToString());

            switch (int.Parse(Connect.LoadData(query.loadCharacterName).Rows[0].ItemArray[2].ToString()))
            {
                case 0:
                    Race.Text = "DARK WIZARD";
                    break;
                case 1:
                    Race.Text = "SOUL MASTER";
                    break;
                case 3:
                    Race.Text = "GRAND MASTER";
                    break;
                case 7:
                    Race.Text = "SOUL WIZARD";
                    break;

                case 16:
                    Race.Text = "DARK KNIGHT";
                    break;
                case 17:
                    Race.Text = "BLADE KNIGHT";
                    break;
                case 19:
                    Race.Text = "BLADE MASTER";
                    break;
                case 23:
                    Race.Text = "DRAGON KNIGHT";
                    break;

                case 32:
                    Race.Text = "FAIRY ELF";
                    break;
                case 33:
                    Race.Text = "MUSE ELF";
                    break;
                case 35:
                    Race.Text = "HIGH ELF";
                    break;
                case 39:
                    Race.Text = "NOBLE ELF";
                    break;

                case 48:
                    Race.Text = "MAGIC GLADIATOR";
                    break;
                case 51:
                    Race.Text = "DUEL MASTER";
                    break;
                case 55:
                    Race.Text = "MAGIC KNIGHT";
                    break;

                case 64:
                    Race.Text = "DARK LORD";
                    break;
                case 67:
                    Race.Text = "LORD EMPEROR";
                    break;
                case 71:
                    Race.Text = "EMPIRE LORD";
                    break;

                case 80:
                    Race.Text = "SUMMONER";
                    break;
                case 81:
                    Race.Text = "BLOODY SUMMONER";
                    break;
                case 83:
                    Race.Text = "DIMENSION MASTER";
                    break;
                case 87:
                    Race.Text = "DIMENSIONER";
                    break;

                case 96:
                    Race.Text = "RAGE FIGHTER";
                    break;
                case 99:
                    Race.Text = "FIST MASTER";
                    break;
                case 106:
                    Race.Text = "FIST BLASER";
                    break;

                case 112:
                    Race.Text = "GROW LANCER";
                    break;
                case 115:
                    Race.Text = "MIRAGE LANCER";
                    break;
                case 119:
                    Race.Text = "SHINING LANCER";
                    break;

                case 128:
                    Race.Text = "RUNE WIZARD";
                    break;
                case 129:
                    Race.Text = "RUNE SPELL MASTER";
                    break;
                case 131:
                    Race.Text = "GRAND RUNE MASTER";
                    break;
                case 135:
                    Race.Text = "MAJESTIC RUNE WIZARD";
                    break;

                case 144:
                    Race.Text = "SLAYER";
                    break;
                case 145:
                    Race.Text = "ROYAL SLAYER";
                    break;
                case 147:
                    Race.Text = "MASTER SLAYER";
                    break;
                case 151:
                    Race.Text = "SLAUGHTERER";
                    break;

                case 160:
                    Race.Text = "GUN CRUSHER";
                    break;
                case 161:
                    Race.Text = "GUN BREAKER";
                    break;
                case 163:
                    Race.Text = "MASTER GUN BREAKER";
                    break;
                case 167:
                    Race.Text = "HEIST GUN CRUSHER";
                    break;
                default:
                    break;
            }

            if (int.Parse(Connect.LoadData(query.loadCharacterName).Rows[0].ItemArray[1].ToString()) == 2)
                ActiveGM.IsChecked = true;

            if (int.Parse(Connect.LoadData(query.loadCharacterName).Rows[0].ItemArray[21].ToString()) == 4194303)
                AllPermissions.IsChecked = true;

            if (int.Parse(Connect.LoadData(query.loadCharacterName).Rows[0].ItemArray[24].ToString()) == 1)
            {
                Status.Foreground = Brushes.Green;
                Status.Text = "Online";
            }



            int levelResult = int.Parse(Level.Text) + int.Parse(LevelMaster.Text) + int.Parse(LevelMajestic.Text);
            LevelTotal.Text = levelResult.ToString();
        }

        private void UpdateCharacter()
        {
            Character.authority = 0;
            Character.admin_flags = 0;

            if (ActiveGM.IsChecked == true)
                Character.authority = 2;

            if (AllPermissions.IsChecked == true)
                Character.admin_flags = 4194303;

            Character.name = Name.Text;
            Character.level = int.Parse(Level.Text);
            Character.level_master = int.Parse(LevelMaster.Text);
            Character.level_majestic = int.Parse(LevelMajestic.Text);

            /* Desnecessary
            Character.experience = int.Parse(Experience.Text);
            Character.experience_master = int.Parse(ExperienceMaster.Text);
            Character.experience_majestic = int.Parse(ExperienceMajestic.Text);
            */
            Character.points = int.Parse(Points.Text);
            Character.points_master = int.Parse(PointsMaster.Text);
            Character.points_majestic = int.Parse(PointsMajestic.Text);
            Character.strenght = int.Parse(Strength.Text);
            Character.agility = int.Parse(Agility.Text);
            Character.vitality = int.Parse(Vitality.Text);
            Character.energy = int.Parse(Energy.Text);
            Character.leadership = int.Parse(Leadership.Text);
            Character.zen = int.Parse(Zen.Text);
            Character.add_fruit_points = int.Parse(AddFruit.Text);
            Character.dec_fruit_points = int.Parse(DecFruit.Text);
            Character.goblin_points = int.Parse(GoblinPoints.Text);

            MessageBoxCustomError boxError = new();
            if (Name.Text == "")
            {
                boxError.CustomMessage.Text = "Character not selected";
                boxError.ShowDialog();
                return;
            }

            Query query1 = new();
            if (int.Parse(Connect.LoadData(query1.loadCharacterName).Rows[0].ItemArray[24].ToString()) == 1)
            {
                boxError.CustomMessage.Text = "Character " + Name.Text + " is online, disconnect! to be able to update";
                boxError.ShowDialog();
                return;
            }


            Query query = new();
            Connect.Update(query.updateCharacterName);
            MessageBoxCustomCheck boxCheck = new();
            boxCheck.CustomMessage.Text = "Character: " + Character.name + " Update Successful !";
            boxCheck.ShowDialog();
        }

        private void DatagridAccounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            if (dg.SelectedItem is DataRowView row)
                Character.name = row["name"].ToString();

            LoadCharacterName();
        }

        private void Race_DropDownClosed(object sender, EventArgs e)
        {
            Character.race = int.Parse(Race.SelectedValue.ToString());
        }

        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            UpdateCharacter();
        }

    }
}
