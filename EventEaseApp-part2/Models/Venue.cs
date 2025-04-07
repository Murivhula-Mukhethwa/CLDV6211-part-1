namespace EventEaseApp_part2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Venue")]
    public partial class Venue
    {
        public int VenueID { get; set; }

        [Required]
        [StringLength(250)]
        public string VenueName { get; set; }

        [Required]
        [StringLength(250)]
        public string Location { get; set; }

        [Required]
        [StringLength(250)]
        public string Capacity { get; set; }
    }
}
