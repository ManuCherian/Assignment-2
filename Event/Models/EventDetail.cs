namespace Event.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EventDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EventDetail()
        {
            MyEvents = new HashSet<MyEvent>();
        }

        [Key]
        public int IdNumber { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public DateTime Starts { get; set; }

        public DateTime Ends { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MyEvent> MyEvents { get; set; }
    }
}
