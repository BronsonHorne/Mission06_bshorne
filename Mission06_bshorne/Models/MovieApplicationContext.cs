using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_bshorne.Models
{
    public class MovieApplicationContext :DbContext
    {
        //Constructor
        public MovieApplicationContext(DbContextOptions<MovieApplicationContext> options) : base(options)
        {
            //Leave blank for now
        }
        public DbSet<ApplicationResponse> Responses { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<ApplicationResponse>().HasData(

                new ApplicationResponse
                {
                    ApplicationId = 1,
                    Category = "Action",
                    Title = "The Accountant",
                    Year = 2016,
                    Director = "Gavin O'Connor",
                    Rating = "R",
                    Edited = true,
                    Lent = null,
                    Notes = "Was an amazing movie"
                },
                new ApplicationResponse
                {
                    ApplicationId = 2,
                    Category = "Action",
                    Title = "Inception",
                    Year = 2010,
                    Director = "Christopher Nolan",
                    Rating = "PG-13",
                    Edited = false,
                    Lent = null,
                    Notes = "Was an amazing movie"
                },
                new ApplicationResponse
                {
                    ApplicationId = 3,
                    Category = "Action",
                    Title = "Deadpool",
                    Year = 2016,
                    Director = "Tim Miller",
                    Rating = "R",
                    Edited = true,
                    Lent = null,
                    Notes = "Was an amazing movie"
                }
            );
        }
    }
}
