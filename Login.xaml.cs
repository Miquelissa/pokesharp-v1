using Microsoft.Win32;
using Pokesharp.Data;
using Pokesharp.Models;
using Pokesharp.State;
using Pokesharp.Util;
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

namespace Pokesharp
{
    /// <summary>
    /// Lógica interna para Window1.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();

            MusicPlayer.playMusic("start-theme");
        }

        private bool isFieldsFilled() {
            return TextBoxUsername.Text != null && !TextBoxUsername.Text.Equals("") &&
                   PasswordBoxPassword.Password != null && !PasswordBoxPassword.Password.Equals("");
        }

        private void LabelRegister_MouseLeftButtonUp(object sender, MouseButtonEventArgs e) {
            Register registerWindow = new Register();
            registerWindow.ShowDialog();
        }

        private void ButtonEnter_Click(object sender, RoutedEventArgs e) {
            string username = TextBoxUsername.Text;
            string password = PasswordBoxPassword.Password;

            if (!isFieldsFilled()) {
                MessageBox.Show("Please fill in all fields to enter", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            try {
                Player player = Players.FindOneByLogin(username, password);

                if (player == null) {
                    MessageBox.Show("Password or player incorrect, please try again.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                Session.Login(player);

                World world = new World();

                world.Show();
                Close();
                
            } catch {
                MessageBox.Show("An error has occurred, please try again later.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
   
        }
    }
}
