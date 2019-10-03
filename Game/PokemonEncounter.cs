using Pokesharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokesharp.Game
{
    class PokemonEncounter
    {

        public static PokemonEncountered FindPokemon(Local local) {
            Random random = new Random();
            int dice = random.Next(0, 1000); // creates a number between 1 and 1000

            if (dice <= 200) { // 20%: not found any pokemon
                return null;
            }

            List<LocalPokemon> pokemons = null;

            if (dice <= 650) { // 45%: common pokemon
                pokemons = local.CommonPokemons;
            } else if (dice <= 825) { // 17.5%: uncommon pokemon
                pokemons = local.UncommonPokemons;
            } else if (dice <= 925) { // 10%: mythical pokemon
                pokemons = local.MythicalPokemons;
            } else { // 7.5%: legendary pokemon
                pokemons = local.LegendaryPokemons;
            }

            if(pokemons.Count == 0) { // not found if don't exists any pokemon in the rarity
                return null;
            }

            int index = random.Next(pokemons.Count);
            LocalPokemon randomPokemon = pokemons[index];
            int level = random.Next(randomPokemon.MinimumLevel < randomPokemon.MaximumLevel ? randomPokemon.MinimumLevel : randomPokemon.MaximumLevel, randomPokemon.MinimumLevel > randomPokemon.MaximumLevel ? randomPokemon.MinimumLevel : randomPokemon.MaximumLevel);

            return new PokemonEncountered {
                Level = level,
                LocalPokemon = randomPokemon
            };
        }

        public static bool TryCatch(PokemonEncountered pokemonEncountered) {
            Random random = new Random();
            int dice = random.Next(0, 1000); // creates a number between 1 and 1000

            if (pokemonEncountered.LocalPokemon.Rarity == PokemonRarity.Common) { // 80%: catch rate common pokemon
                return dice <= 800;
            } else if (pokemonEncountered.LocalPokemon.Rarity == PokemonRarity.Uncommon) { // 60%: catch rate uncommon pokemon
                return dice <= 600;
            } else if (pokemonEncountered.LocalPokemon.Rarity == PokemonRarity.Mythical) { // 30%: catch rate mythical pokemon
                return dice <= 300;
            } else if (pokemonEncountered.LocalPokemon.Rarity == PokemonRarity.Legendary) { // 15%: catch rate legendary pokemon
                return dice <= 150;
            } else {
                return false; // can't caught anything!
            }
        }

        public static bool Battle(PokedexPokemon pokedexPokemon, PokemonEncountered pokemonEncountered) {
            Random random = new Random();

            // power set for battle
            double power = 0;
            if (pokemonEncountered.LocalPokemon.Rarity == PokemonRarity.Common) {
                power = 0;
            } else if (pokemonEncountered.LocalPokemon.Rarity == PokemonRarity.Uncommon) {
                power = 2.5;
            } else if (pokemonEncountered.LocalPokemon.Rarity == PokemonRarity.Mythical) {
                power = 5;
            } else if (pokemonEncountered.LocalPokemon.Rarity == PokemonRarity.Legendary) {
                power = 10;
            }

            return pokedexPokemon.Level >= (pokemonEncountered.Level + power);
        }

    }
}
