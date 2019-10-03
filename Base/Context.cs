using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Pokesharp.Models;

namespace Pokesharp.Base
{

    public class Context : DbContext
    {

        public Context() : base("Context") { }

        public DbSet<User> User
        {
            get;
            set;
        }

        public DbSet<Player> Player
        {
            get;
            set;
        }

        public DbSet<Administrator> Administrator
        {
            get;
            set;
        }

        public DbSet<Pokemon> Pokemon
        {
            get;
            set;
        }

        public DbSet<PokedexPokemon> PokedexPokemon
        {
            get;
            set;
        }

        public DbSet<Pokedex> Pokedex
        {
            get;
            set;
        }

        public DbSet<Region> Region
        {
            get;
            set;
        }

        public DbSet<Local> Local
        {
            get;
            set;
        }

        public DbSet<LocalPokemon> LocalPokemon
        {
            get;
            set;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}