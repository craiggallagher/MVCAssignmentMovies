using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCAssignmentMovies.Models
{
    public class MoviesDb: DbContext
    {
       public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public MoviesDb()
            : base("MoviesDb")
        { }
    }
}