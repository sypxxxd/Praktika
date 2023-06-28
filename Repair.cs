namespace Vova
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Repair")]
    public partial class Repair
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Repair()
        {
            PartsToRepair = new HashSet<PartsToRepair>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public int device { get; set; }

        [Required]
        public string comment { get; set; }

        public int status { get; set; }

        public decimal? cost { get; set; }

        public virtual Device Device1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartsToRepair> PartsToRepair { get; set; }

        public virtual Status Status1 { get; set; }
    }
}
