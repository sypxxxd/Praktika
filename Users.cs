namespace Vova
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TabID { get; set; }

        [Required]
        [StringLength(50)]
        public string FIO { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(50)]
        public string Dolzhnost { get; set; }

        [Required]
        [StringLength(50)]
        public string Login { get; set; }

        [Required]
        [StringLength(50)]
        public string Pass { get; set; }
    }
}
