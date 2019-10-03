using Pokesharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokesharp.Game.Models
{
    // data grid locals
    class LocalData 
    {
        public Local Local { get; set; }

        public Uri Image { get; set; }

        public string Name { get; set; }

        public int PokemonCount { get; set; }
    }
}
