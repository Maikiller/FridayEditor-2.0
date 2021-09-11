using MuEditor.Database;
using MuEditor.Forms.Utils;
using System;
using System.Collections.Generic;
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

namespace MuEditor.Forms
{
    /// <summary>
    /// Lógica interna para DatabaseConfig.xaml
    /// </summary>
    public partial class DatabaseConfig : Window
    {
        public DatabaseConfig()
        {
            InitializeComponent();
        }

        private void LoginDatabase()
        {
            Config.server = ServerIP.Text;
            Config.user = User.Text;
            Config.password = Password.Text;
            Config.port = Port.Text;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoginDatabase();
            Connect.DetectedApplicationError();
            CustomMessageBoxCheck box = new();
            if (Config.applicationError == 0)
            {
                box.CustomMessage.Text = "Database Connected";
                box.ShowDialog();
                Close();
            }
            
        }
    }
}