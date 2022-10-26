using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workshop8.Models
{
    public class AppUser : IdentityUser
    {
        public string? FolderPath { get; set; }
    }
}
