using Pokesharp.State;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pokesharp.Components
{
    /// <summary>
    /// Interação lógica para PlayerSession.xam
    /// </summary>
    public partial class PlayerSession : UserControl
    {
        public PlayerSession()
        {
            InitializeComponent();
        }

        private void LabelWelcomeUser_Loaded(object sender, RoutedEventArgs e) {
            if(Session.Player != null) {
                LabelWelcomeUser.Content = "Welcome " + Session.Player.Username + "!";
            }
        }

        private void ButtonLeave_Click(object sender, RoutedEventArgs e) {
            Session.Logout();

            Window currentWindow = Application.Current.Windows.OfType<Window>().SingleOrDefault(window => window.IsActive);
            currentWindow.Hide();

            Login login = new Login();
            login.Show();
        }
    }
}
