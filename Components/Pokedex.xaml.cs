using Pokesharp.Data;
using Pokesharp.Game.Models;
using Pokesharp.Models;
using Pokesharp.State;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interação lógica para Pokedex.xam
    /// </summary>
    public partial class Pokedex : UserControl
    {
        public Pokedex()
        {
            InitializeComponent();
        }

        private void RefreshData() {
            Player player = Session.Player;

            if (player != null) {

                List<PokedexPokemonData> items = new List<PokedexPokemonData>();

                foreach (PokedexPokemon pokedexPokemon in player.Pokedex.Pokemons) {
                    items.Add(new PokedexPokemonData() {
                        PokedexPokemon = pokedexPokemon,
                        Image = new Uri(@"../../Resources/Images/Pokemon/Icon/" + pokedexPokemon.Pokemon.ImageID + ".png", UriKind.Relative),
                        Name = pokedexPokemon.Pokemon.Name,
                        Nickname = pokedexPokemon.Nickname,
                        Level = pokedexPokemon.Level,
                        Notes = pokedexPokemon.Notes,
                        EncountersCount = pokedexPokemon.EncountersCount,
                        Catched = pokedexPokemon.Catched,
                        IsMain = pokedexPokemon.ID == player.MainPokedexPokemonID
                    });
                }

                DataGridPokedex.ItemsSource = items;

            }
        }

        private void DataGridPokedex_Loaded(object sender, RoutedEventArgs e) {
            RefreshData();
        }

        private void Row_DoubleClick(object sender, RoutedEventArgs e) {
            DataGridRow dataGridRow = sender as DataGridRow;
            if (dataGridRow.Item is PokedexPokemonData) {
                PokedexPokemonData pokedexPokemonData = dataGridRow.Item as PokedexPokemonData;

                Session.Player.MainPokedexPokemonID = pokedexPokemonData.PokedexPokemon.ID;
                Players.UpdatePlayer(Session.Player);

                RefreshData();
            }
        }

        private void ButtonRow_Click(object sender, RoutedEventArgs e)  {
            PokedexPokemon pokedexPokemon = ((PokedexPokemonData)((Button)e.Source).DataContext).PokedexPokemon;
            
            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure you want to kill " + pokedexPokemon.Pokemon.Name + " (lvl. " + pokedexPokemon.Level + ")?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                Pokedexes.DisablePokemon(pokedexPokemon);
                Session.UpdatePlayer();

                RefreshData();
            }
        } 

        private void DataGridPokedex_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
