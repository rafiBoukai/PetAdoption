using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using static PetAdoption.Models.Enums;

namespace PetAdoption.Models
{
   
    public class Pet
    {
        public const int descriptionLength = 200;
        public const int rangeAge = 20;
        public int Id { get; set; }
        public string Name { get; set; }
        [Range(0,rangeAge)]
        public double Age { get; set; }
        public bool IsAdopted { get; set; }
        public PetType PetType { get; set; }
        public Area Area { get; set; }

        [StringLength(descriptionLength,ErrorMessage ="description is too long")]
        public string Description { get; set; }
        public bool IsTrained { get; set; }
        public bool IsImmuned { get; set; }

        [ForeignKey("Organization")]
        public int? OrganizationId { get; set; }
        public virtual Organization Organization { get; set; }

        public virtual ICollection<AdoptionRequest> AdoptionRequests { get; set; }

    }
}