namespace RCNClinicApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class tbl_Service
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Service()
        {
            tbl_Advertising = new HashSet<tbl_Advertising>();
            tblReceptions = new HashSet<tblReception>();
        }

        public int Id { get; set; }

        public int? Code { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Nationcode { get; set; }

        [StringLength(15)]
        public string Barcode { get; set; }

        [StringLength(100)]
        public string Unit { get; set; }

        public double? FreePrices { get; set; }

        public int? IdType { get; set; }

        public bool? IsDelete { get; set; }

        public bool? IsConflict { get; set; }

        public int? IdGeneral_Group { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Advertising> tbl_Advertising { get; set; }

        public virtual tbl_Dual tbl_Dual { get; set; }

        public virtual tbl_GeneralGroups tbl_GeneralGroups { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblReception> tblReceptions { get; set; }
    }
}
