using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace EventEaseApp_part2.Models
{
    public partial class EventEaseDBContext : DbContext
    {
        public EventEaseDBContext()
            : base("name=EventEaseDBContext")
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Venue> Venues { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>()
                .Property(e => e.EventID)
                .IsUnicode(false);

            modelBuilder.Entity<Booking>()
                .Property(e => e.VenueID)
                .IsUnicode(false);

            modelBuilder.Entity<Booking>()
                .Property(e => e.BookingDate)
                .IsUnicode(false);

            modelBuilder.Entity<Event>()
                .Property(e => e.EventName)
                .IsUnicode(false);

            modelBuilder.Entity<Event>()
                .Property(e => e.EventDate)
                .IsUnicode(false);

            modelBuilder.Entity<Event>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Event>()
                .Property(e => e.VenueID)
                .IsUnicode(false);

            modelBuilder.Entity<Venue>()
                .Property(e => e.VenueName)
                .IsUnicode(false);

            modelBuilder.Entity<Venue>()
                .Property(e => e.Location)
                .IsUnicode(false);

            modelBuilder.Entity<Venue>()
                .Property(e => e.Capacity)
                .IsUnicode(false);
        }
    }
}
