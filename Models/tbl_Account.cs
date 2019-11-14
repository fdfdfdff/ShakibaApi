namespace RCNClinicApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class tbl_Account
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Account()
        {
            tbl_cash_AllTransaction = new HashSet<tbl_cash_AllTransaction>();
        }

        public short Id { get; set; }

        [Required]
        [StringLength(100)]
        public string NameBank { get; set; }

        public string NumAccount { get; set; }

        public string NumCard { get; set; }

        public string Branch { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_cash_AllTransaction> tbl_cash_AllTransaction { get; set; }
    }
}
