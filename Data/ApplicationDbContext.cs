using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NotesAppFinal.Models;

namespace NotesAppFinal.Data
{
    public class ApplicationDbContext : IdentityDbContext<NotesUser, NotesUserRole, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<NoteModel> NoteModels { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<NotesUserRole>().HasData
                (
                    new NotesUserRole[]
                    {
                        new NotesUserRole
                        {
                            Id = 1,
                            Name = "Admin",
                            NormalizedName = "Admin".ToUpper()
                        },
                        new NotesUserRole
                        {
                            Id = 2,
                            Name = "Manager",
                            NormalizedName = "Manager".ToUpper()
                        },
                        new NotesUserRole
                        {
                            Id = 3,
                            Name = "Dev",
                            NormalizedName = "Dev".ToUpper()
                        },
                        new NotesUserRole
                        {
                            Id = 4,
                            Name = "User",
                            NormalizedName = "User".ToUpper()
                        }
                    }
                    );

            builder.Entity<NoteModel>().HasData
                (
                new NoteModel[]
                {
                    new NoteModel
                    {
                        Id = 100,
                        Heading = "Heading1",
                        Content = "Content1",
                        categoryId = 0,
                        userId = null
                    },

                    new NoteModel
                    {
                        Id = 101,
                        Heading = "Heading2",
                        Content = "Content2",
                        categoryId = 1,
                        userId = null
                    },

                    new NoteModel
                    {
                        Id = 102,
                        Heading = "Heading3",
                        Content = "Content3",
                        categoryId = 2,
                        userId = null
                    }
                }
                );
        }
    }
}
