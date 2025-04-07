namespace EventEaseApp_part2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Event")]
    public partial class Event
    {
        public int EventID { get; set; }

        [Required]
        [StringLength(250)]
        public string EventName { get; set; }

        [Required]
        [StringLength(250)]
        public string EventDate { get; set; }

        [Required]
        [StringLength(250)]
        public string Description { get; set; }

        [Required]
        [StringLength(250)]
        public string VenueID { get; set; }
    }
}
