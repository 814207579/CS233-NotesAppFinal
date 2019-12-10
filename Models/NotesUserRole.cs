using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesAppFinal.Models
{
    public class NotesUserRole : IdentityRole<int>
    {
        public NotesUserRole() { }
        public NotesUserRole(string name)
        {
            Name = name;
        }
    }
  
}
