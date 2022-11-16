using System;
using System.Collections.Generic;

namespace Serve.Core.Models
{
    public partial class Organization
    {
        public Organization()
        {
            EmployeePermissions = new HashSet<EmployeePermission>();
            EmployeeRoles = new HashSet<EmployeeRole>();
            Notifications = new HashSet<Notification>();
            OrganizationEmployees = new HashSet<OrganizationEmployee>();
            OrganizationMedia = new HashSet<OrganizationMedium>();
            OrganizationUnavailableDates = new HashSet<OrganizationUnavailableDate>();
            Users = new HashSet<User>();
        }

        public long Id { get; set; }
        public string? BusinessName { get; set; }
        public string? BusinessEmail { get; set; }
        public string? PhoneNumber { get; set; }
        public string? WebsiteUrl { get; set; }
        public string? InstagramUrl { get; set; }
        public string? FacebookUrl { get; set; }
        public string? WhatsappUrl { get; set; }
        public long? Creator { get; set; }
        public string? ProfilePicture { get; set; }
        public string? BusinessDescription { get; set; }
        public string? Industry { get; set; }
        public string? BusinessBio { get; set; }
        public string? AuthenticationType { get; set; }

        public virtual UserProfile? CreatorNavigation { get; set; }
        public virtual ICollection<EmployeePermission> EmployeePermissions { get; set; }
        public virtual ICollection<EmployeeRole> EmployeeRoles { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<OrganizationEmployee> OrganizationEmployees { get; set; }
        public virtual ICollection<OrganizationMedium> OrganizationMedia { get; set; }
        public virtual ICollection<OrganizationUnavailableDate> OrganizationUnavailableDates { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
