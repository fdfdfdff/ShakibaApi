namespace RCNClinicApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("tblReception")]
    public partial class tblReception
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblReception()
        {
            tbl_cash_AllTransaction = new HashSet<tbl_cash_AllTransaction>();
            tbl_cashrecords = new HashSet<tbl_cashrecords>();
            tblVisits = new HashSet<tblVisit>();
        }

        public long Id { get; set; }

        public long IdPatient { get; set; }

        public int IdService { get; set; }

        public DateTime RegDate { get; set; }

        public int? IdWaiting { get; set; }

        public int? IdDoctor { get; set; }

        [StringLength(1500)]
        public string KnowledgeOfOperation { get; set; }

        [StringLength(1500)]
        public string ExperienceOfBeauty { get; set; }

        [StringLength(1500)]
        public string ProblemOfOpearation { get; set; }

        [StringLength(1500)]
        public string WhatTimeWhatDo { get; set; }

        [StringLength(1500)]
        public string WhatCases { get; set; }

        [StringLength(1500)]
        public string UsageDrugs { get; set; }

        [StringLength(1500)]
        public string AlergyDrug { get; set; }

        [StringLength(1500)]
        public string ExperienceBlood { get; set; }

        [StringLength(1500)]
        public string PhysicalProblem { get; set; }

        [StringLength(1500)]
        public string Sign { get; set; }

        [StringLength(1500)]
        public string PenSatisfaction { get; set; }

        public int? IdGeneralGroup { get; set; }

        public int? IdInsure { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_cash_AllTransaction> tbl_cash_AllTransaction { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_cashrecords> tbl_cashrecords { get; set; }

        public virtual tbl_docter tbl_docter { get; set; }

        public virtual tbl_Dual tbl_Dual { get; set; }

        public virtual tbl_GeneralGroups tbl_GeneralGroups { get; set; }

        public virtual tbl_patient tbl_patient { get; set; }

        public virtual tbl_Service tbl_Service { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblVisit> tblVisits { get; set; }
    }
}
