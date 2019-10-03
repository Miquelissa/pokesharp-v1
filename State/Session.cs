using Pokesharp.Data;
using Pokesharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokesharp.State {

    static class Session {

        static public User User {
            get;
            set;
        }

        public static void Login(User user) {
            User = user;
        }

        public static void Logout() {
            User = null;
        }

        public static void UpdatePlayer() {
            User = Players.FindOneByID(Player.ID);
        }


        public static Player Player {

            get {

                return (Player)User;

            }

        }

        public static Administrator Administrator {

            get {

                return (Administrator)User;

            }

        }

    }

}
