using System;
using System.Collections.Generic;

namespace Serve.API.Models
{
    public partial class UserProfile
    {
        public UserProfile()
        {
            OrganizationEmployees = new HashSet<OrganizationEmployee>();
            Organizations = new HashSet<Organization>();
        }

        public long Id { get; set; }
        public string UserId { get; set; } = null!;
        public string? ProfilePicture { get; set; }

        public virtual ICollection<OrganizationEmployee> OrganizationEmployees { get; set; }
        public virtual ICollection<Organization> Organizations { get; set; }
    }
}
