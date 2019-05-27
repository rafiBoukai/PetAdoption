using PetAdoption.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PetAdoption.DataAccessLayer
{
    public class WebAppDBContext:DbContext
    {

    /*    public WebAppDBContext():base("WebAppDBContext")
        {
            *we don't want to lose existing data 
             * in the production environment so 
            let's disable initializer 

            Database.SetInitializer<WebAppDBContext>(null);
        }*/
    
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Pet> Pets { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<AdoptionRequest> AdoptionRequests { get; set; }
    }
}