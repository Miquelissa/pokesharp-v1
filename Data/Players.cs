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

                return db.Player
                    .Include("Pokedex")
                    .Include("Pokedex.Pokemons")
                    .Include("Pokedex.Pokemons.Pokemon")
                    .Where(player => player.Enabled)
                    .FirstOrDefault(player => player.Username.Equals(username) && player.Password.Equals(password));

            }

        }

        public static Player FindOneByID(int id) {

            using (Context db = new Context()) {

                return db.Player
                    .Include("Pokedex")
                    .Include("Pokedex.Pokemons")
                    .Include("Pokedex.Pokemons.Pokemon")
                    .Where(player => player.Enabled)
                    .FirstOrDefault(player => player.ID == id);

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
