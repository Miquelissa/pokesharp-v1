using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokesharp.Models
{
    public class LocalPokemon
    {

        [Key]
        public int ID
        {
            get;
            set;
        }

        [ForeignKey("Local")]
        public int LocalID
        {
            get;
            set;
        }

        public virtual Local Local
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

        public string Rarity
        {
            get;
            set;
        }

        public int MinimumLevel {
            get;
            set;
        }

        public int MaximumLevel {
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
