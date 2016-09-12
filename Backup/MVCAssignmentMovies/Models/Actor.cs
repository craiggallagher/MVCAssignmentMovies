using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCAssignmentMovies.Models
{
    public class Actor
    {
        [Key]
        public int ActorID { get; set; }
        [Display(Name = "Actor Name"), Required]// vailidation
        [StringLength(60, ErrorMessage = "Must be between " +
                       "{2} and {1} characters long.", MinimumLength = 3)]
        public string ActorName { get; set; }
        [Display(Name = "Age")]
        [Range(0, 100)]          // vailidation range
        public int age { get; set; }
        public int MovieID { get; set; }
        public List<Movie> Movies { get; set; }
        // {
        //    get { return (moviesActors == null) ? null : moviesActors.Select(m => m.Movie).ToList(); }
        //}
    }
}