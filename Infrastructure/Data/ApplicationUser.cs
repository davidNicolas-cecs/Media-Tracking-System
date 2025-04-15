using MediaNest.Domain.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaNest.Infrastructure.Data
{
    public class ApplicationUser : IdentityUser
    {
        // Extends the IdentityUser table
        // Adds a UserCollection 

        // Each user has one UserCollection (1:1 relationship)
        public int? UserCollectionId { get; set; }
        public UserCollection UserCollection { get; set; }
    }
}
