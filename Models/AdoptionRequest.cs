using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PetAdoption.Models
{
    public class AdoptionRequest
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public int? UserId { get; set; }
        public virtual User User{ get; set; }

        [ForeignKey("Pet")]
        public int? PetId { get; set; }
        public virtual Pet Pet { get; set; }

        [Display(Name= "still open")]
        public bool IsOpen { get; set; }
        public DateTime AdaptionDate { get; set; }
    }
}