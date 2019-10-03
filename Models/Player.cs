using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokesharp.Models
{
    public class Player : User
    {

        public string Name
        {
            get;
            set;
        }

        [ForeignKey("Pokedex")]
        public int PokedexID
        {
            get;
            set;
        }

        public int MainPokedexPokemonID 
        {
            get;
            set;
        }

        public virtual Pokedex Pokedex
        {
            get;
            set;
        }

        public bool CatchedAnyPokemon() {
            return MainPokedexPokemonID > 0;
        }

    }
}

