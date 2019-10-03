using Pokesharp.Data;
using Pokesharp.Game;
using Pokesharp.Models;
using Pokesharp.State;
using System;
using System.Collections.Generic;
using System.Drawing;
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
    /// Lógica interna para Encounter.xaml
    /// </summary>
    public partial class Encounter : Window
    {
        private static PokemonEncountered PokemonEncountered;

        public Encounter(PokemonEncountered pokemonEncountered)
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            PokemonEncountered = pokemonEncountered;
            InitializeComponent();
        }

        private void Window_Initialized(object sender, EventArgs e) {
            MessageBox.Show("A wild " + PokemonEncountered.LocalPokemon.Pokemon.Name + " appears!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

            ButtonBattle.IsEnabled = Session.Player.CatchedAnyPokemon();
            ImagePokemonImage.Source = new BitmapImage(new Uri(@"../../Resources/Images/Pokemon/Normal/" + PokemonEncountered.LocalPokemon.Pokemon.ImageID + ".png", UriKind.Relative));
            LabelPokemonName.Content = PokemonEncountered.LocalPokemon.Pokemon.Name + " (lvl. " + PokemonEncountered.Level + ")";
        }

        private void ButtonCatch_Click(object sender, RoutedEventArgs e) {
            bool isCaught = PokemonEncounter.TryCatch(PokemonEncountered);

            if(!isCaught) {
                MessageBox.Show("The Pokémon broken free. Wild " + PokemonEncountered.LocalPokemon.Pokemon.Name + " ran from battle!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                BackToRegion(false);
                return;
            }

            MessageBox.Show(PokemonEncountered.LocalPokemon.Pokemon.Name + " was caught!", "Gotcha!", MessageBoxButton.OK);

            Caught caught = new Caught(PokemonEncountered);

            caught.Closed += Caught_Closed;
            caught.ShowDialog();
        }

        private void BackToRegion(bool isRun) {
            WorldRegion worldRegion = new WorldRegion(PokemonEncountered.LocalPokemon.Local.Region);

            if (isRun) {
                MessageBox.Show("Got away safely!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            worldRegion.Show();
            Hide();
        }

        private void Caught_Closed(object sender, EventArgs e) {
            BackToRegion(false);
        }

        private void Window_Closed(object sender, EventArgs e) {
            BackToRegion(true);
        }

        private void ButtonRun_Click(object sender, RoutedEventArgs e) {
            BackToRegion(true);
        }

        private void ButtonBattle_Click(object sender, RoutedEventArgs e) {
            PokedexPokemon pokedexPokemon = Session.Player.Pokedex.Pokemons.FirstOrDefault(pokemon => Session.Player.MainPokedexPokemonID == pokemon.ID);
            bool win = PokemonEncounter.Battle(pokedexPokemon, PokemonEncountered);

            try {
                if(win) {
                    pokedexPokemon.Level += 1;
                    MessageBox.Show(pokedexPokemon.Pokemon.Name + " grew to lvl " + pokedexPokemon.Level + "!", "Win", MessageBoxButton.OK);
                    Pokedexes.UpdatePokemon(pokedexPokemon, Session.Player.Pokedex);

                    Session.UpdatePlayer();
                } else {
                    MessageBox.Show(pokedexPokemon.Pokemon.Name + " was fainted.", "Lose", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

                BackToRegion(false);
            } catch {
                MessageBox.Show("An error has occurred, please try again later.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
