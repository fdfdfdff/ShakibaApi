namespace RCNClinicApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("tblVisit")]
    public partial class tblVisit
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblVisit()
        {
            tbl_Advertising = new HashSet<tbl_Advertising>();
            tbl_SMS = new HashSet<tbl_SMS>();
            tblPictures = new HashSet<tblPicture>();
        }

        public long Id { get; set; }

        public long IdReception { get; set; }

        public DateTime VisitDate { get; set; }

        public int? IdWaiting { get; set; }

        public string Comment { get; set; }

        public int? Count { get; set; }

        public double? Percents { get; set; }

        public double? Tariff { get; set; }

        public double? FreePrices { get; set; }

        public DateTime? DateRequest { get; set; }

        [NotMapped]
        public string FarsiDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Advertising> tbl_Advertising { get; set; }

        public virtual tbl_Dual tbl_Dual { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_SMS> tbl_SMS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPicture> tblPictures { get; set; }

        public virtual tblReception tblReception { get; set; }
    }
}
