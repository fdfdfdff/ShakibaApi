namespace RCNClinicApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class tbl_Insure
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Insure()
        {
            tbl_InsureAccount = new HashSet<tbl_InsureAccount>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int? Percents { get; set; }

        public int? percentBed { get; set; }

        public int? IdInsureOrg { get; set; }

        [StringLength(300)]
        public string InsureCDName { get; set; }

        [StringLength(4)]
        public string Code { get; set; }

        public bool? IsDelete { get; set; }

        public virtual tbl_InsurOrg tbl_InsurOrg { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_InsureAccount> tbl_InsureAccount { get; set; }
    }
}
