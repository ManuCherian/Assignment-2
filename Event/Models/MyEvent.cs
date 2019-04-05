namespace Event.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MyEvent
    {
        [Key]
        public int EventId { get; set; }

        [Required]
        [StringLength(255)]
        public string EventTitle { get; set; }

        [StringLength(80)]
        public string Location { get; set; }

        public int IdNumber { get; set; }

        public virtual EventDetail EventDetail { get; set; }
    }
}
