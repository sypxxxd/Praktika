namespace Vova
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SpecificationsOfPart")]
    public partial class SpecificationsOfPart
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idScpecification { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idPart { get; set; }

        public decimal value { get; set; }

        public virtual DevicePart DevicePart { get; set; }

        public virtual Specifications Specifications { get; set; }
    }
}
