using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokesharp.Models
{
    public class Local
    {

        [Key]
        public int ID
        {
            get;
            set;
        }

        [ForeignKey("Region")]
        public int RegionID
        {
            get;
            set;
        }

        public virtual Region Region
        {
            get;
            set;
        }

        [ForeignKey("LocalID")]
        public virtual List<LocalPokemon> Pokemons
        {
            get;
            set;
        }

        public string Name {
            get;
            set;
        }

        public string ImageID
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

        [NotMapped]
        public List<LocalPokemon> CommonPokemons {
            get {
                return Pokemons.Where(localPokemon => localPokemon.Rarity == PokemonRarity.Common).ToList();
            }
        }

        [NotMapped]
        public List<LocalPokemon> UncommonPokemons {
            get {
                return Pokemons.Where(localPokemon => localPokemon.Rarity == PokemonRarity.Uncommon).ToList();
            }
        }

        [NotMapped]
        public List<LocalPokemon> MythicalPokemons {
            get {
                return Pokemons.Where(localPokemon => localPokemon.Rarity == PokemonRarity.Mythical).ToList();
            }
        }

        [NotMapped]
        public List<LocalPokemon> LegendaryPokemons {
            get {
                return Pokemons.Where(localPokemon => localPokemon.Rarity == PokemonRarity.Legendary).ToList();
            }
        }

    }
}
