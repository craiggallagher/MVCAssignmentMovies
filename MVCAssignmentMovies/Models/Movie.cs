using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCAssignmentMovies.Models
{
   public enum Genre 
    { 
       Horror,Comedy,Thriller,Action, Crime
    }
    public class Movie
    {
        [Key]
        public int MovieID { get; set; }
        [Display(Name = "Movie Name"), Required]        // vailidation
         [StringLength(100, ErrorMessage = "Must be between " +
                       "{2} and {1} characters long.", MinimumLength = 1)]
        public string MovieName { get; set; }
         [Display(Name = "Rating"), Required]
        [Range(0, 10)]       // vailidation range
        public double Rating { get; set; }
         [Display(Name = "Genre")]
        public Genre genre { get; set; }
        [Display(Name = "No of Actors")]
        public virtual List<Actor> Actors { get; set; }
        //public virtual List<MoviesActors> moviesActors { get; set; }
        //{
        //    get { return (moviesActors == null) ? null : moviesActors.Select(a => a.Actor).ToList(); }
        //}
    }
}