namespace Vova
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Device")]
    public partial class Device
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Device()
        {
            FirstDiagnostic = new HashSet<FirstDiagnostic>();
            Repair = new HashSet<Repair>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public int type { get; set; }

        [Required]
        [StringLength(50)]
        public string model { get; set; }

        [Required]
        [StringLength(50)]
        public string damage { get; set; }

        [Required]
        [StringLength(50)]
        public string complaint { get; set; }

        public int? master { get; set; }

        public int client { get; set; }

        public virtual Client Client1 { get; set; }

        public virtual Type Type1 { get; set; }

        public virtual Types Types { get; set; }

        public virtual Worker Worker { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FirstDiagnostic> FirstDiagnostic { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Repair> Repair { get; set; }
    }
}
