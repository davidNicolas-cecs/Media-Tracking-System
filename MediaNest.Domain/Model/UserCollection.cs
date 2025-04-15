using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaNest.Domain.Model
{
    public class UserCollection
    {
        public int Id { get; set; }

        // This property links UserCollection to ApplicationUser (1:1 relationship)
        public string UserId { get; set; }
        public ICollection<UserCollectionItems> Items { get; set; }
            
    }
}
