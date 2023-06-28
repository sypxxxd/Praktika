namespace Vova
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Client")]
    public partial class Client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client()
        {
            Device = new HashSet<Device>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Num { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        public int serialPass { get; set; }

        public int numberPas { get; set; }

        public decimal phone { get; set; }

        [Column(TypeName = "image")]
        public byte[] img { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Device> Device { get; set; }
    }
}
