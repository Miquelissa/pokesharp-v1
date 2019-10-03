using Pokesharp.Base;
using Pokesharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokesharp.Data {
    class Regions {

        public static List<Region> List() {
            using (Context db = new Context()) {
                return db.Region
                    .Include("Locals")
                    .Include("Locals.Pokemons")
                    .Include("Locals.Pokemons.Pokemon")
                    .Include("Locals.Region")
                    .Where(region => region.Enabled)
                    .ToList();
            }
        }
    }
}
