namespace RCNClinicApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class tbl_GeneralGroups
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_GeneralGroups()
        {
            tbl_docter = new HashSet<tbl_docter>();
            tbl_Service = new HashSet<tbl_Service>();
            tbl_Tankhah = new HashSet<tbl_Tankhah>();
            tbl_Users = new HashSet<tbl_Users>();
            tblReceptions = new HashSet<tblReception>();
        }

        public int Id { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        public int? IdTypeward { get; set; }

        public int? IdType { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        [StringLength(50)]
        public string Tel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_docter> tbl_docter { get; set; }

        public virtual tbl_Dual tbl_DualTypeWard { get; set; }

        public virtual tbl_Dual tbl_DualType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Service> tbl_Service { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Tankhah> tbl_Tankhah { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Users> tbl_Users { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblReception> tblReceptions { get; set; }
    }
}
