namespace RCNClinicApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class tbl_docter
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_docter()
        {
            tblReceptions = new HashSet<tblReception>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Lastname { get; set; }

        [StringLength(15)]
        public string Mobile { get; set; }

        [StringLength(15)]
        public string Tel { get; set; }

        public string Adress { get; set; }

        public int? IdSpecialityDr { get; set; }

        [StringLength(20)]
        public string MedicalCouncil { get; set; }

        public int? CalculationType { get; set; }

        [StringLength(100)]
        public string Pic { get; set; }

        public int? IdGenereal_Group { get; set; }

        public double? PercentOrConstValue { get; set; }

        public virtual tbl_Dual tbl_DualCalcType { get; set; }

        public virtual tbl_Dual tbl_DualSpeciality { get; set; }

        public virtual tbl_GeneralGroups tbl_GeneralGroups { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblReception> tblReceptions { get; set; }
    }
}
