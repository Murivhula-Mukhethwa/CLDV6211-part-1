namespace EventEaseApp_part2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Booking")]
    public partial class Booking
    {
        public int BookingID { get; set; }

        [Required]
        [StringLength(250)]
        public string EventID { get; set; }

        [Required]
        [StringLength(250)]
        public string VenueID { get; set; }

        [Required]
        [StringLength(250)]
        public string BookingDate { get; set; }
    }
}
