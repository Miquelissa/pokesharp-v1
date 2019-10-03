using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokesharp.Models
{
    public class Pokedex
    {

        [Key]
        public int ID
        {
            get;
            set;
        }

        [ForeignKey("PokedexID")]
        public virtual List<PokedexPokemon> Pokemons
        {
            get;
            set;
        }


        public bool Enabled
        {
            get;
            set;
        }

        public DateTime CreatedAt
        {
            get;
            set;
        }

        public DateTime UpdatedAt
        {
            get;
            set;
        }

    }
}
