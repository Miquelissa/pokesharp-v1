using Pokesharp.Game;
using Pokesharp.Models;
using Pokesharp.Game.Models;
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
    /// Lógica interna para WorldRegion.xaml
    /// </summary>
    public partial class WorldRegion : Window
    {
        private static Region Region;

        public WorldRegion(Region region)
        {
            Region = region;

            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();

            ImageGifLoading.Visibility = Visibility.Hidden;
            LabelLoading.Visibility = Visibility.Hidden;
            LabelLocals.Content = region.Name + " - Locals";
        }

        private void DataGridLocals_Loaded(object sender, RoutedEventArgs e) {

            List<LocalData> items = new List<LocalData>();

            foreach (Local local in Region.Locals) {
                items.Add(new LocalData() {
                    Local = local,
                    Image = new Uri(@"../../Resources/Images/Local/" + local.ImageID + ".png", UriKind.Relative),
                    Name = local.Name,
                    PokemonCount = local.Pokemons.Count
                });
            }

            DataGridLocals.ItemsSource = items;

        }

        private void ButtonRow_Click(object sender, RoutedEventArgs e) {
            Local local = ((LocalData)((Button)e.Source).DataContext).Local;
            int randomTimeout = new Random().Next(5000);

            ToggleLoading();
            Timeout timeout = new Timeout(() => {
                Application.Current.Dispatcher.Invoke((Action)delegate {
                    PokemonEncountered pokemonEncountered = PokemonEncounter.FindPokemon(local);

                    if (pokemonEncountered == null) {
                        MessageBox.Show("No pokémons were found! Please, try again!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        ToggleLoading();
                        return;
                    }

                    Encounter encounter = new Encounter(pokemonEncountered);

                    encounter.Show();
                    Hide();
                });
            }, randomTimeout);

        }

        private void ButtonBackToWorld_Click(object sender, RoutedEventArgs e) {
            World world = new World();

            Hide();
            world.Show();
        }

        private void ToggleLoading() {
            DataGridLocals.Opacity = DataGridLocals.Opacity == 0.4 ? 1 : 0.4;
            ImageGifLoading.Visibility = ImageGifLoading.Visibility == Visibility.Visible ? Visibility.Hidden : Visibility.Visible;
            LabelLoading.Visibility = LabelLoading.Visibility == Visibility.Visible ? Visibility.Hidden : Visibility.Visible;

            // Disable/Enable all clicks
            IsHitTestVisible = IsHitTestVisible ? false : true;
        }

        internal class Timeout : System.Timers.Timer {
            public Timeout(Action action, double delay) {
                AutoReset = false;
                Interval = delay;
                Elapsed += (sender, args) => action();
                Start();
            }
        }
    }
}
