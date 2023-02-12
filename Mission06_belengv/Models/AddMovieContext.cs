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

        //Seeding my database with my 3 favorite movies
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<ApplicationResponse>().HasData(
                new ApplicationResponse
                {
                    EntryId = 1,
                    Category = "Drama",
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
                    Category = "Action",
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
                    Category = "Action",
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
