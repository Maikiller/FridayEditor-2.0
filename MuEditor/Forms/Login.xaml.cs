using MuEditor.Database;
using MuEditor.Forms;
using MuEditor.Forms.FormsUsers;
using MuEditor.Models;
using System.Windows;

namespace MuEditor
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            Config.database = "mu_online_login";
        }

        private void LoginUser()
        {
            User.account = Account.Text;
            User.password = Password.Text;
            Main main = new();
            if (Account.Text == "admin")
            {
                main.Show();
                Visibility = Visibility.Hidden;
                return;
            }

            Query query = new();
            if (int.Parse(Connect.LoadData(query.authUser).Rows[0].ItemArray[0].ToString()) == 1)
            {
                Visibility = Visibility.Hidden;
                main.Show();
                
            }
            else
            {
                MessageBox.Show("Account or Password Incorrect");
                User.password = "";
                Password.Text = "";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoginUser();
        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void TextBlock_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DatabaseConfig databaseConfig = new();
            databaseConfig.ShowDialog();
        }
    }
}