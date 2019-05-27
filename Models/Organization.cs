using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static PetAdoption.Models.Enums;

namespace PetAdoption.Models
{
    public class Organization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Area Area { get; set; }
        public string Address { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        public virtual ICollection<Pet> Pets { get; set; }
        public virtual ICollection<AdoptionRequest> AdoptionRequests { get; set; }

    }
}