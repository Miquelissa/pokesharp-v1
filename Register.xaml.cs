using Pokesharp.Data;
using Pokesharp.Models;
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

namespace Pokesharp {
    /// <summary>
    /// Lógica interna para Register.xaml
    /// </summary>
    public partial class Register : Window {

        public Register() {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }

        private bool isFieldsFilled() {
            return TextBoxUsername.Text != null && !TextBoxUsername.Text.Equals("") &&
                   PasswordBoxPassword.Password != null && !PasswordBoxPassword.Password.Equals("") &&
                   PasswordBoxRepeatPassword.Password != null && !PasswordBoxRepeatPassword.Password.Equals("");
        }

        private bool isRepeatEqualsPassword() {
            return PasswordBoxPassword.Password == PasswordBoxRepeatPassword.Password;
        }

        private void ButtonRegister_Click(object sender, RoutedEventArgs e) {
            string username = TextBoxUsername.Text;
            string password = PasswordBoxPassword.Password;
            string repeatPassword = PasswordBoxRepeatPassword.Password;

            if(!isFieldsFilled()) {
                MessageBox.Show("Please fill in all fields to register", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (!isRepeatEqualsPassword()) {
                MessageBox.Show("Secrets must be the same", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
                       
            try {
                Pokedex playerPokedex = Pokedexes.Add(new Pokedex());
                Player player = new Player();

                player.Password = password;
                player.Username = username;
                player.PokedexID = playerPokedex.ID;

                Players.Add(player);
                MessageBox.Show("Welcome " + username + "! Now, type your data to enter to the Pokémon world!", "", MessageBoxButton.OK);

                Close();
            } catch {
                MessageBox.Show("An error has occurred, please try again later.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void LabelBackClick_MouseLeftButtonUp(object sender, MouseButtonEventArgs e) {
            Close();
        }
    }
}
