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
using Pokesharp.Models;
using Pokesharp.Data;
using Pokesharp.State;


namespace Pokesharp
{
    /// <summary>
    /// Lógica interna para EditClient.xaml
    /// </summary>
    public partial class EditClient : Window
    {
        Player user;

        public EditClient(Player player)
        {
            InitializeComponent();
            user = player;
            nickname.Text = user.Username;
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            user.Username = nickname.Text;
            Players.UpdatePlayer(user);
            Session.UpdatePlayer();
            Close();
        }
    }
}
