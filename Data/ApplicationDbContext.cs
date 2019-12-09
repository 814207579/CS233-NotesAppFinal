using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NotesAppFinal.Models;

namespace NotesAppFinal.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Note> Notes { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
