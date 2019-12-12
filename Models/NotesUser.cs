using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NotesAppFinal.Models
{
    public class NotesUser : IdentityUser<int>
    {
        [PersonalData, StringLength(20)]    
        public string FirstName { get; set; }
        [PersonalData, StringLength(20)]
        public string LastName { get; set; }
    }
}
