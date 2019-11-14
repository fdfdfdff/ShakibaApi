namespace RCNClinicApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class tbl_Users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Users()
        {
            tbl_cash_AllTransactionEdit = new HashSet<tbl_cash_AllTransaction>();
            tbl_cash_AllTransactionSave = new HashSet<tbl_cash_AllTransaction>();
            tbl_cashrecordEdit = new HashSet<tbl_cashrecords>();
            tbl_cashrecordsSave = new HashSet<tbl_cashrecords>();
            tbl_InsureAccountEdit = new HashSet<tbl_InsureAccount>();
            tbl_InsureAccountSave = new HashSet<tbl_InsureAccount>();
            tbl_TankhahEdit = new HashSet<tbl_Tankhah>();
            tbl_TankhahSave = new HashSet<tbl_Tankhah>();
            tbl_Users_Role = new HashSet<tbl_Users_Role>();
        }

        public int Id { get; set; }

        [Required]
       // [Column("FName")]
        [StringLength(500)]
        public string UserName { get; set; }

        [StringLength(500)]
        public string Password { get; set; }

        [Column(TypeName = "ntext")]
        public string UserCommand { get; set; }

        public bool? IsDr { get; set; }

        public bool? IsDelete { get; set; }

        public int? PersonnelOrDrId { get; set; }

        public int? IdGeneralGroup { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_cash_AllTransaction> tbl_cash_AllTransactionEdit { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_cash_AllTransaction> tbl_cash_AllTransactionSave { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_cashrecords> tbl_cashrecordEdit { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_cashrecords> tbl_cashrecordsSave { get; set; }

        public virtual tbl_GeneralGroups tbl_GeneralGroups { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_InsureAccount> tbl_InsureAccountEdit { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_InsureAccount> tbl_InsureAccountSave { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Tankhah> tbl_TankhahEdit { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Tankhah> tbl_TankhahSave { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Users_Role> tbl_Users_Role { get; set; }
    }
}
