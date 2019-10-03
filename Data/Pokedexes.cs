using Pokesharp.Base;
using Pokesharp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokesharp.Data
{
    static class Pokedexes
    {

        public static Pokedex Add(Pokedex pokedex) {

            using (Context db = new Context()) {
                pokedex.CreatedAt = DateTime.Now;
                pokedex.UpdatedAt = DateTime.Now;
                pokedex.Enabled = true;

                Pokedex pokedexCreated = db.Pokedex.Add(pokedex);
                db.SaveChanges();

                return pokedexCreated;
            }

        }

        public static PokedexPokemon AddPokemon(PokedexPokemon pokedexPokemon, Pokedex pokedex) {

            using (Context db = new Context()) {
                pokedexPokemon.PokedexID = pokedex.ID;
                pokedexPokemon.CreatedAt = DateTime.Now;
                pokedexPokemon.UpdatedAt = DateTime.Now;
                pokedexPokemon.Enabled = true;

                PokedexPokemon pokedexPokemonCreated = db.PokedexPokemon.Add(pokedexPokemon);
                db.SaveChanges();

                return pokedexPokemonCreated;
            }

        }

        public static PokedexPokemon UpdatePokemon(PokedexPokemon pokedexPokemon, Pokedex pokedex) {
            using (Context db = new Context()) {
                pokedexPokemon.PokedexID = pokedex.ID;
                pokedexPokemon.UpdatedAt = DateTime.Now;
                pokedexPokemon.Enabled = true;

                db.PokedexPokemon.Attach(pokedexPokemon);
                db.Entry(pokedexPokemon).State = EntityState.Modified;
                db.SaveChanges();

                return pokedexPokemon;
            }
        }

        public static PokedexPokemon DisablePokemon(PokedexPokemon pokedexPokemon)
        {
            using (Context db = new Context())
            {
                pokedexPokemon.Enabled = false;

                db.PokedexPokemon.Attach(pokedexPokemon);
                db.Entry(pokedexPokemon).State = EntityState.Modified;
                db.SaveChanges();

                return pokedexPokemon;
            }
        }

    }

}
