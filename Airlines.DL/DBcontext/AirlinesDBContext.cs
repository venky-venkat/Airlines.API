using Airlines.DL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airlines.DL.DBcontext
{
    public class AirlinesDBContext : DbContext
    {
        public AirlinesDBContext(DbContextOptions<AirlinesDBContext> options) : base(options)
        {

        }

        public DbSet<Login> Login { get; set; }
        public DbSet<Airline> Airlines { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
