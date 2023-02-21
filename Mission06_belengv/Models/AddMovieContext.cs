using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_belengv.Models
{
    public class AddMovieContext: DbContext
    {
        //Constructor
        public AddMovieContext(DbContextOptions<AddMovieContext> options): base(options)
        {
            //blank
        }
        public DbSet<ApplicationResponse> Responses { get; set; }
        public DbSet<Category> Categories { get; set; }

        //Seeding my database with my 3 favorite movies
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName= "Action/Adventure" },
                new Category { CategoryId = 2, CategoryName = "Comedy" },
                new Category { CategoryId = 3, CategoryName = "Drama" },
                new Category { CategoryId = 4, CategoryName = "Family" },
                new Category { CategoryId = 5, CategoryName = "Horror/Suspense" },
                new Category { CategoryId = 6, CategoryName = "Miscellaneous" },
                new Category { CategoryId = 7, CategoryName = "Television" },
                new Category { CategoryId = 8, CategoryName = "VHS" }
                
            );

            mb.Entity<ApplicationResponse>().HasData(
                new ApplicationResponse
                {
                    EntryId = 1,
                    CategoryId = 3,
                    Title = "The Longest Ride",
                    Director = "Nikolas Sparks",
                    Year = 2014,
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "Megan",
                    Notes = "Best movie ever!!"

                },
                new ApplicationResponse
                {
                    EntryId = 2,
                    CategoryId = 1,
                    Title = "The Amazing Spider Man",
                    Director = "Sam Raimi",
                    Year = 2012,
                    Rating = "PG",
                    Edited = true,
                    LentTo = "Carla",
                    Notes = "Andrew Garfiels is everyhting!!"

                },
                new ApplicationResponse
                {
                    EntryId = 3,
                    CategoryId = 1,
                    Title = "Top Gun",
                    Director = "Tony Scott",
                    Year = 2022,
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "Mom",
                    Notes = "How can this movie be so good? "

                }

            );
                
        }
    }
}
