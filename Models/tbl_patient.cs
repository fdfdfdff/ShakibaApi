namespace RCNClinicApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class tbl_patient
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_patient()
        {
            tblReceptions = new HashSet<tblReception>();
        }

        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        public string Address { get; set; }

        [Required]
        [StringLength(50)]
        public string Tel { get; set; }

        [StringLength(150)]
        public string Moaref { get; set; }

        public int IdSex { get; set; }

        [StringLength(100)]
        public string Job { get; set; }

        [StringLength(15)]
        public string birthDay { get; set; }

        [StringLength(50)]
        public string InsurenceBookletNum { get; set; }

        [StringLength(50)]
        public string FatherName { get; set; }

        public int? IDFirstInsure { get; set; }

        [StringLength(50)]
        public string DossierNumberTemporary { get; set; }

        [StringLength(50)]
        public string DossierNumberPermanent { get; set; }

        [StringLength(50)]
        public string Education { get; set; }

        [StringLength(150)]
        public string PathPic { get; set; }

        public virtual tbl_Dual tbl_Dual { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblReception> tblReceptions { get; set; }
    }
}
