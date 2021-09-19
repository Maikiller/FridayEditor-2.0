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
    /// Lógica interna para Events.xaml
    /// </summary>
    public partial class Events : Window
    {
        public Events()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void ONLoad()
        {
            Config.database = "mu_game";
            Query query = new();
            DatagridEvents.ItemsSource = Connect.LoadData(query.loadEventsDatagrid).DefaultView;
            DatagridEvents.Columns[7].Visibility = Visibility.Hidden;
            Query query3 = new();
            ComboInvasion.ItemsSource = Connect.LoadData(query3.loadIvasions).DefaultView;
            ComboInvasion.DisplayMemberPath = "name";
            ComboInvasion.SelectedValuePath = "invasion";

            Config.database = "mu_online_login";
            Query query1 = new();
            ComboServer.ItemsSource = Connect.LoadData(query1.loadServerCodeList).DefaultView;
            ComboServer.DisplayMemberPath = "server";

            Config.database = "mu_editor_config";
            Query query2 = new();
            ComboEvent.ItemsSource = Connect.LoadData(query2.loadEventsCombo).DefaultView;
            ComboEvent.DisplayMemberPath = "name";
            ComboEvent.SelectedValuePath = "id";

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ONLoad();
        }

        private void SelectEvent()
        {
            Query query = new();
            if (Connect.LoadData(query.loadEventSelect).Rows.Count > 0)
            {
                ComboServer.Text = Connect.LoadData(query.loadEventSelect).Rows[0].ItemArray[0].ToString();
                ComboInvasion.Text = Connect.LoadData(query.loadEventSelect).Rows[0].ItemArray[2].ToString();
                ComboEvent.Text = Connect.LoadData(query.loadEventSelect).Rows[0].ItemArray[1].ToString();
                Hour.Text = Connect.LoadData(query.loadEventSelect).Rows[0].ItemArray[5].ToString();
                Minutes.Text = Connect.LoadData(query.loadEventSelect).Rows[0].ItemArray[6].ToString();
                Duration.Text = Connect.LoadData(query.loadEventSelect).Rows[0].ItemArray[3].ToString();
                AlertTime.Text = Connect.LoadData(query.loadEventSelect).Rows[0].ItemArray[4].ToString();
                DayWeek.Text = Connect.LoadData(query.loadEventSelect).Rows[0].ItemArray[8].ToString();
                DayMouth.Text = Connect.LoadData(query.loadEventSelect).Rows[0].ItemArray[9].ToString();
                EventSeason.Text = Connect.LoadData(query.loadEventSelect).Rows[0].ItemArray[10].ToString();
                ServerExclusive.Text = Connect.LoadData(query.loadEventSelect).Rows[0].ItemArray[11].ToString();
                EventSelected.Text = Connect.LoadData(query.loadEventSelect).Rows[0].ItemArray[7].ToString();
            }


            if (ComboEvent.Text == "Invasion")
                ComboInvasion.IsEnabled = true;

            if (ComboEvent.Text != "Invasion")
                ComboInvasion.IsEnabled = false;
        }
        private void DatagridEvents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            if (dg.SelectedItem is DataRowView row)
                Models.Events.guid = int.Parse(row["guid"].ToString());

            SelectEvent();
        }

        private void Inputs()
        {
            Config.database = "mu_game";
            MessageBoxCustomError customError = new();
            if (ComboServer.SelectedIndex == -1 || ComboEvent.SelectedIndex == -1 ||
                Hour.Text == "" || Minutes.Text == "" || Duration.Text == "" || AlertTime.Text == "" || DayWeek.Text == "" ||
                DayMouth.Text == "" || EventSeason.Text == "" || ServerExclusive.Text == "")
            {
                customError.CustomMessage.Text = "Invalid Values";
                customError.ShowDialog();
                return;
            }


            Models.Events.server = int.Parse(ComboServer.Text);

            if (ComboEvent.Text == "Invasion")
                Models.Events.invasion = int.Parse(ComboInvasion.SelectedValue.ToString());

            if (ComboEvent.Text != "Invasion")
                Models.Events.invasion = 255;

            Models.Events.events = int.Parse(ComboEvent.SelectedValue.ToString());
            Models.Events.hour = int.Parse(Hour.Text);
            Models.Events.min = int.Parse(Minutes.Text);
            Models.Events.duration = int.Parse(Duration.Text);
            Models.Events.alerTime = int.Parse(AlertTime.Text);
            Models.Events.dayWeek = int.Parse(DayWeek.Text);
            Models.Events.dayMouth = int.Parse(DayMouth.Text);
            Models.Events.eventSeason = int.Parse(EventSeason.Text);
            Models.Events.serverExclusive = int.Parse(ServerExclusive.Text);
            // Models.Events.guid = int.Parse(EventSelected.Text);
        }
        private void AddEvent()
        {
            Inputs();

            Query query = new();
            Connect.Update(query.addEvents);
            Query query1 = new();
            DatagridEvents.ItemsSource = Connect.LoadData(query1.loadEventsDatagrid).DefaultView;
            DatagridEvents.Columns[7].Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddEvent();
        }

        private void ComboEvent_DropDownClosed(object sender, EventArgs e)
        {
            if (ComboEvent.Text == "Invasion")
                ComboInvasion.IsEnabled = true;

            if (ComboEvent.Text != "Invasion")
            {
                ComboInvasion.IsEnabled = false;
                ComboInvasion.Text = "";
            }
        }

        private void ComboEvent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboEvent.Text == "Invasion")
                ComboInvasion.IsEnabled = true;

            if (ComboEvent.Text != "Invasion")
            {
                ComboInvasion.IsEnabled = false;
                ComboInvasion.Text = "";
            }

        }

        private void upateEvents()
        {
            Inputs();
            Query query = new();
            Connect.Update(query.updateEvents);

            Query query1 = new();
            DatagridEvents.ItemsSource = Connect.LoadData(query1.loadEventsDatagrid).DefaultView;
            DatagridEvents.Columns[7].Visibility = Visibility.Hidden;

        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            upateEvents();
        }

        private void deleteEvents()
        {
            Config.database = "mu_game";
            Query query = new();
            Connect.Update(query.deleteEvents);

            Query query1 = new();
            DatagridEvents.ItemsSource = Connect.LoadData(query1.loadEventsDatagrid).DefaultView;
            DatagridEvents.Columns[7].Visibility = Visibility.Hidden;
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            deleteEvents();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
