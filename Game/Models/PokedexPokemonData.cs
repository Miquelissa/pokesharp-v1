using Pokesharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokesharp.Game.Models
{
    // data grid pokedex
    class PokedexPokemonData
    {
        public PokedexPokemon PokedexPokemon { get; set; }

        public string Name { get; set; }

        public string Nickname { get; set; }

        public int Level { get; set; }

        public string Notes { get; set; }

        public int EncountersCount { get; set; }

        public Uri Image { get; set; }

        public bool Catched { get; set; }

        public bool IsMain { get; set; }
    }
}
