using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using MovieShop.Core.Entities;

namespace MovieShop.Infrastructure.Data
{
    public class MovieShopDbContext : DbContext
    {

        public MovieShopDbContext(DbContextOptions<MovieShopDbContext> options) : base(options)
        {

        }

        // add-migration will lock for a class that derives from DbContext class
        // does that dbcontext class has dbset? If yes it will look for entity of that dbset
        // By default if any dbset entity has id property then EF will automatically assume it's a primary key
        // EF will check with the existing Database based on connection string and compare them and generate the migration file
        public DbSet<Genre> Genres { get; set; }

    }
}
