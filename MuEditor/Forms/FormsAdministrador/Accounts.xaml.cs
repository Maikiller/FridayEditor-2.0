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
    /// Lógica interna para Accounts.xaml
    /// </summary>
    public partial class Accounts : Window
    {
        public Accounts()
        {
            InitializeComponent();
        }

        private void UpdateAccount()
        {
            MessageBoxCustomError box = new();
            if (Account.Text == "")
            {
                box.CustomMessage.Text = "Select Account";
                box.ShowDialog();
                return;
            }
            User.account = Account.Text;
            User.email = Email.Text;
            User.credits = int.Parse(Credits.Text);
            User.vipDuration = int.Parse(TimeVip.Text);



            if (VipStatus.IsChecked == true)
                User.vipStatus = 1;
            else
                User.vipStatus = -1;

            switch (TypeAccount.Text)
            {
                case "Player":
                    User.typeAccount = 0;
                    break;

                case "Banned":
                    User.typeAccount = 1;
                    break;

                case "Administrator":
                    User.typeAccount = 2;
                    break;
            }

            Query query = new();
            Connect.Update(query.updateAccount);
            DatagridAccounts.ItemsSource = Connect.LoadData(query.loadAccounts).DefaultView;

            MessageBoxCustomCheck boxCheck = new();
            boxCheck.CustomMessage.Text = "Account: " + User.account + " Update Successful";
            boxCheck.ShowDialog();

        }

        private void LoadAccounts()
        {
            Query query = new();
            DatagridAccounts.ItemsSource = Connect.LoadData(query.loadAccounts).DefaultView;
        }

        private void LoadAccountSelected()
        {

            Query query = new();
            if (Connect.LoadData(query.loadAccountName).Rows.Count > -1)
                User.guid = int.Parse(Connect.LoadData(query.loadAccountName).Rows[0].ItemArray[0].ToString());
            Account.Text = Connect.LoadData(query.loadAccountName).Rows[0].ItemArray[1].ToString();
            Email.Text = Connect.LoadData(query.loadAccountName).Rows[0].ItemArray[2].ToString();
            Register.Text = Connect.LoadData(query.loadAccountName).Rows[0].ItemArray[3].ToString();
            Credits.Text = Connect.LoadData(query.loadAccountName).Rows[0].ItemArray[4].ToString();
            CurrentIP.Text = Connect.LoadData(query.loadAccountName).Rows[0].ItemArray[5].ToString();

            if (int.Parse(Connect.LoadData(query.loadAccountName).Rows[0].ItemArray[7].ToString()) == 1)
                VipStatus.IsChecked = true;
            else
                VipStatus.IsChecked = false;

            TimeVip.Text = Connect.LoadData(query.loadAccountName).Rows[0].ItemArray[8].ToString();

            switch (int.Parse(Connect.LoadData(query.loadAccountName).Rows[0].ItemArray[6].ToString()))
            {
                case 0:
                    TypeAccount.Text = "Player";
                    break;
                case 1:
                    TypeAccount.Text = "Banned";
                    break;
                case 2:
                    TypeAccount.Text = "Administrator";
                    break;
            }

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Connect.Connection().Close();
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Config.database = "mu_online_login";
            LoadAccounts();
        }

        private void DatagridAccounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            if (dg.SelectedItem is DataRowView row)
                User.account = row["account"].ToString();

            LoadAccountSelected();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            UpdateAccount();
        }

        private void FindAccount_TextChanged(object sender, TextChangedEventArgs e)
        {
            Query query = new();
            DataView dv = Connect.LoadData(query.loadAccounts).DefaultView;
            dv.RowFilter = "Account LIKE '" + FindAccount.Text + "%'";
            DatagridAccounts.ItemsSource = dv;
        }
    }
}
