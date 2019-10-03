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
    static class Players
    {

        public static void Add(Player player) {

            using (Context db = new Context()) {

                player.CreatedAt = DateTime.Now;
                player.UpdatedAt = DateTime.Now;
                player.Enabled = true;
                player.Password = Util.Encryptor.MD5(player.Password);

                db.Player.Add(player);
                db.SaveChanges();
            }

        }

        public static Player FindOneByLogin(string username, string password) {

            using (Context db = new Context()) {

                password = Util.Encryptor.MD5(password);

                Player player = db.Player
                    .Include("Pokedex")
                    .Include("Pokedex.Pokemons")
                    .Include("Pokedex.Pokemons.Pokemon")
                    .Where(_player => _player.Enabled)
                    .FirstOrDefault(_player => _player.Username.Equals(username) && _player.Password.Equals(password));

                if(player != null)
                {
                    player.Pokedex.Pokemons = player.Pokedex.Pokemons.Where(pokemon => pokemon.Enabled).ToList();
                }

                return player;
            }

        }

        public static Player FindOneByID(int id) {

            using (Context db = new Context()) {

                Player player = db.Player
                    .Include("Pokedex")
                    .Include("Pokedex.Pokemons")
                    .Include("Pokedex.Pokemons.Pokemon")
                    .Where(_player => _player.Enabled)
                    .FirstOrDefault(_player => _player.ID == id);

                if (player != null)
                {
                    // filter enabled player pokemons
                    player.Pokedex.Pokemons = player.Pokedex.Pokemons.Where(pokemon => pokemon.Enabled).ToList();
                }

                return player;
            }

        }


        public static Player UpdatePlayer(Player player) {
            using (Context db = new Context()) {
                db.Player.Attach(player);
                db.Entry(player).State = EntityState.Modified;
                db.SaveChanges();

                return player;
            }
        }

    }

}
