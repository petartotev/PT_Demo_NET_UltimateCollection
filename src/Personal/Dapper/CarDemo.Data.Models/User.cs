using Microsoft.AspNetCore.Identity;
using System;

namespace CarDemo.Data.Models
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DateModified { get; set; }

        public string Image { get; set; }

        public Guid? ApiKey { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsBanned { get; set; }

        public bool IsAdmin { get; set; }
    }
}
