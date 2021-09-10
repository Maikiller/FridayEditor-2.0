using System.Windows;
using MuEditor.Forms.FormsAdministrador;

namespace MuEditor.Forms.FormsUsers
{
    /// <summary>
    /// Lógica interna para Window1.xaml
    /// </summary>
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Window_Closed_1(object sender, System.EventArgs e)
        {
            Login login = new();
            login.Visibility = Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Hidden;
            MainAdmin mainAdmin = new();
            mainAdmin.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Account account = new();
            account.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Character character = new();
            character.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Guild guild = new();
            guild.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Commands commands = new();
            commands.Show();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Tickets tickets = new();
            tickets.Show();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Events events = new();
            events.Show();
        }
    }
}