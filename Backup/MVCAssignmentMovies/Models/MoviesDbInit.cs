using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCAssignmentMovies.Models
{
    public class MoviesDbInit : DropCreateDatabaseAlways<MoviesDb>
    {
        protected override void Seed(MoviesDb context)
        {
            var seedTeamData = new List<Movie>()   /// how the data is seeded 
            {
               new Movie(){ MovieName="Anchorman the Legend of Ron Burgundy", genre= Genre.Comedy, Rating = 7.4, Actors=
                new List<Actor>()
                {
                    new Actor(){ ActorName="Will Ferrell", age=(DateTime.Now - DateTime.Parse ("07/06/1967")).Days/365},
                    new Actor(){ ActorName="Paul Rudd", age=(DateTime.Now - DateTime.Parse ("04/06/1969")).Days/365},
                    new Actor(){ ActorName="Steve Carell", age=(DateTime.Now - DateTime.Parse ("16/08/1962")).Days/365}
                    
                }},
                //moviesActors= new List<>(MoviesActors)
            new Movie(){ MovieName  ="Talladega Nights", genre=Genre.Comedy, Rating=6.5, Actors=
                new List<Actor>()
                {
                  new Actor(){ ActorName="Will Ferrell", age=(DateTime.Now - DateTime.Parse ("07/06/1967")).Days/365},
                  new Actor(){ ActorName="John C. Reilly ", age=(DateTime.Now - DateTime.Parse ("05/08/1965")).Days/365}
                    
            }},
             new Movie(){ MovieName  ="Born", genre=Genre.Action, Rating=8.5, Actors=
                new List<Actor>()
                {
                  new Actor(){ ActorName="Matt Damon", age=(DateTime.Now - DateTime.Parse ("07/08/1977")).Days/365},
                  new Actor(){ ActorName="Franka Potente ", age=(DateTime.Now - DateTime.Parse ("05/08/1985")).Days/365},
                     new Actor(){ ActorName="Clive Owen", age=(DateTime.Now - DateTime.Parse ("12/07/1971")).Days/365}
            }},
            new Movie(){ MovieName  ="The Departed ", genre=Genre.Thriller, Rating=8.5, Actors=
                new List<Actor>()
                {
                  new Actor(){ ActorName="Matt Damon", age=(DateTime.Now - DateTime.Parse ("07/08/1977")).Days/365},
                  new Actor(){ ActorName="Mark Walburg ", age=(DateTime.Now - DateTime.Parse ("05/08/1985")).Days/365},
                     new Actor(){ ActorName="Leonardo DiCaprio", age=(DateTime.Now - DateTime.Parse ("12/07/1971")).Days/365}
            }},
            //moviesActors= new List<>(MoviesActors)
            new Movie(){ MovieName  ="Taken", genre=Genre.Action, Rating=6.5, Actors=
                new List<Actor>()
                {
                    new Actor(){ ActorName="Liam Nesson", age=(DateTime.Now - DateTime.Parse ("06/07/1952")).Days/365} }
                

        }}//moviesActors= new List<>(MoviesActors)
        ;
            
            seedTeamData.ForEach(tm => context.Movies.Add(tm));

            context.SaveChanges();
            base.Seed(context);
        }
    }
}