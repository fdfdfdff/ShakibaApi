namespace RCNClinicApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class tbl_Tankhah
    {
        public long Id { get; set; }

        public double? Price { get; set; }

        public DateTime? Date { get; set; }

        [StringLength(100)]
        public string Payer { get; set; }

        public string Description { get; set; }

        public int? IdGeneralGroup { get; set; }

        public DateTime? DateSave { get; set; }

        public DateTime? DateEdit { get; set; }

        public int? WhoSave { get; set; }

        public int? WhoEdit { get; set; }

        public virtual tbl_GeneralGroups tbl_GeneralGroups { get; set; }

        public virtual tbl_Users tbl_UserEdit { get; set; }

        public virtual tbl_Users tbl_UsersSave { get; set; }
    }
}
