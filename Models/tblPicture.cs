namespace RCNClinicApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("tblPicture")]
    public partial class tblPicture
    {
        public long Id { get; set; }

        public long IdVisit { get; set; }

        [Required]
        [StringLength(150)]
        public string Filepath { get; set; }

        public virtual tblVisit tblVisit { get; set; }
    }
}
