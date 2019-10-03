using Pokesharp.Data;
using Pokesharp.Models;
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
using System.Windows.Shapes;

namespace Pokesharp
{
    /// <summary>
    /// Lógica interna para Caught.xaml
    /// </summary>
    public partial class Caught : Window
    {
        private static PokemonEncountered PokemonEncountered;

        public Caught(PokemonEncountered pokemonEncountered)
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            PokemonEncountered = pokemonEncountered;
            InitializeComponent();
        }

        private void Window_Initialized(object sender, EventArgs e) {
            ImagePokemonImage.Source = new BitmapImage(new Uri(@"../../Resources/Images/Pokemon/Normal/" + PokemonEncountered.LocalPokemon.Pokemon.ImageID + ".png", UriKind.Relative));
            LabelPokemonName.Content = PokemonEncountered.LocalPokemon.Pokemon.Name + " (lvl. " + PokemonEncountered.Level + ")";
            TextBoxPokemonNotes.Text = PokemonEncountered.LocalPokemon.Pokemon.Description;
        }

        private void ButtonRegister_Click(object sender, RoutedEventArgs e) {
            PokedexPokemon pokemonCaught = PokemonAlreadyCaught();

            if (pokemonCaught == null) {
                pokemonCaught = new PokedexPokemon();
                pokemonCaught.PokemonID = PokemonEncountered.LocalPokemon.PokemonID;
                pokemonCaught.EncountersCount = 1;
                pokemonCaught.Level = PokemonEncountered.Level;
            } else {
                MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure you want to replace your " + PokemonEncountered.LocalPokemon.Pokemon.Name + " (lvl. " + PokemonEncountered.Level + ") with this one?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (messageBoxResult == MessageBoxResult.Yes) {
                    pokemonCaught.Level = PokemonEncountered.Level;
                }

                pokemonCaught.EncountersCount = pokemonCaught.EncountersCount + 1;
            }

            pokemonCaught.Nickname = TextBoxPokemonNickname.Text;
            pokemonCaught.Notes = TextBoxPokemonNotes.Text;
            pokemonCaught.Catched = true;
            pokemonCaught.Enabled = true;

            try {

                if (PokemonAlreadyCaught() == null) {
                    pokemonCaught = Pokedexes.AddPokemon(pokemonCaught, Session.Player.Pokedex);
                } else {
                    pokemonCaught = Pokedexes.UpdatePokemon(pokemonCaught, Session.Player.Pokedex);
                }

                // If is the first pokemon set as main
                if(Session.Player.Pokedex.Pokemons.Count == 0) {
                    Session.Player.MainPokedexPokemonID = pokemonCaught.ID;
                    Players.UpdatePlayer(Session.Player);
                }

                Session.UpdatePlayer();
                Close();

            } catch {
                MessageBox.Show("An error has occurred, please try again later.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private PokedexPokemon PokemonAlreadyCaught() {
            return Session.Player.Pokedex.Pokemons.FirstOrDefault(pokedexPokemon => pokedexPokemon.PokemonID == PokemonEncountered.LocalPokemon.PokemonID && pokedexPokemon.Enabled);
        }

    }
}
