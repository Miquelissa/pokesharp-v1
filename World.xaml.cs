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

namespace Pokesharp {
    /// <summary>
    /// Lógica interna para World.xaml
    /// </summary>
    public partial class World : Window {
        public World() {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }

        private void DataGridRegions_Loaded(object sender, RoutedEventArgs e) {
            List<Region> regions = Regions.List();
            DataGridRegions.ItemsSource = regions;
        }

        private void ButtonRow_Click(object sender, RoutedEventArgs e) {
            Region region = (Region)((Button)e.Source).DataContext;

            WorldRegion worldRegion = new WorldRegion(region);

            Hide();
            worldRegion.Show();
        }
    }
}
