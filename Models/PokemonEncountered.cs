using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokesharp.Models
{
    public class PokemonEncountered
    {
        public LocalPokemon LocalPokemon 
        {
            get;
            set;
        }

        public int Level {
            get;
            set;
        }
    }
}
