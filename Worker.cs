namespace Vova
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Worker")]
    public partial class Worker
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Worker()
        {
            Device = new HashSet<Device>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int tabNum { get; set; }

        [Required]
        [StringLength(50)]
        public string FIO { get; set; }

        public int position { get; set; }

        public decimal oklad { get; set; }

        public decimal? percentToRepair { get; set; }

        [StringLength(50)]
        public string status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Device> Device { get; set; }

        public virtual Position Position1 { get; set; }
    }
}
