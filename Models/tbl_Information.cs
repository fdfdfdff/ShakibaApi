namespace RCNClinicApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class tbl_Information
    {
        public int Id { get; set; }

        [StringLength(500)]
        public string Header { get; set; }

        [StringLength(50)]
        public string Tell { get; set; }

        public string Adress { get; set; }

        public string ImagePath { get; set; }

        [StringLength(500)]
        public string ServerAdress { get; set; }

        public string FolderPath { get; set; }
    }
}
