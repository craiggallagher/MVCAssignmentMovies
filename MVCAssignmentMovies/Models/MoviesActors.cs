using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCAssignmentMovies.Models
{
    public class MoviesActors
    {
        [Key, Column(Order = 0)]    // Composite key (first key)
        public int MovieID { get; set; }
        [Key, Column(Order = 1)]        // Composite key (second key)
        public int ActorID { get; set; }
        public bool Discounted { get; set; }    // Additional Property for relationship
        // Nav Properties
        public virtual Movie Movies { get; set; }
        public virtual Actor Actors { get; set; }
    }
}