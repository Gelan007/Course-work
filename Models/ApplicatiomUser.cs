using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NumizmatDictionary.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() : base() { }   // Collectors
        public string Country { get; set; }
        public string Name { get; set; }
        public string Contacts { get; set; }
        public string AvailabilityInCollection { get; set; }

    }
}
