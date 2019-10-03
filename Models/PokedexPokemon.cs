using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokesharp.Models
{
    public class PokedexPokemon
    {
        [Key]
        public int ID
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

        public virtual Pokedex Pokedex
        {
            get;
            set;
        }

        [ForeignKey("Pokemon")]
        public int PokemonID
        {
            get;
            set;
        }

        public virtual Pokemon Pokemon
        {
            get;
            set;
        }


        public int Level
        {
            get;
            set;
        }

        public string Nickname
        {
            get;
            set;
        }

        public string Notes
        {
            get;
            set;
        }

        public bool Catched
        {
            get;
            set;
        }

        public int EncountersCount
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
