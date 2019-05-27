using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PetAdoption.Models
{
    public class User
    {
        public const int inputSize = 50;
       
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter user name")]
        [StringLength(inputSize,ErrorMessage ="user name is too long")]
        [Index(IsUnique= true)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please enter password")]
        public string Password { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Please enter phone number")]
        [Display(Name="Phone number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Admin")]
        [Required(ErrorMessage = "Please select if you want to be an admin")]
        public bool IsAdmin { get; set; }

        public virtual ICollection<AdoptionRequest> AdoptionRequests { get; set; }
    }
}