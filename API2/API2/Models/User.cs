namespace API2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public int id { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        public DateTime? dateofbirth { get; set; }

        [StringLength(500)]
        public string password { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(50)]
        public string telp { get; set; }

        [StringLength(50)]
        public string photo { get; set; }
    }
}
