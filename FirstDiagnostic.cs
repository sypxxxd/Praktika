namespace Vova
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FirstDiagnostic")]
    public partial class FirstDiagnostic
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idDiagnostic { get; set; }

        public int device { get; set; }

        [Required]
        [StringLength(50)]
        public string description { get; set; }

        public virtual Device Device1 { get; set; }
    }
}
