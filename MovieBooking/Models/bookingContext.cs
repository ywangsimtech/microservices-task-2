using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MovieBooking.Models
{
    public class bookingContext : DbContext
    {
        public bookingContext(DbContextOptions<bookingContext> options)
            : base(options)
        {
        }

        public DbSet<booking> booking { get; set; }
    }
}
