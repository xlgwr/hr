namespace HR.Zip.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class user_mstr
    {
        [Key]
        [Column(Order = 0)]
        public long Tid { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string comp { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string userID { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [Required]
        [StringLength(50)]
        public string email { get; set; }

        [Required]
        [StringLength(256)]
        public string password { get; set; }

        [StringLength(256)]
        public string cc_super { get; set; }

        [StringLength(256)]
        public string cc_hr { get; set; }

        [StringLength(50)]
        public string u_str1 { get; set; }

        [StringLength(50)]
        public string u_str2 { get; set; }

        public decimal? u_dec1 { get; set; }

        public decimal? u_dec2 { get; set; }

        public DateTime? updateDate { get; set; }

        [StringLength(50)]
        public string createby { get; set; }

        [StringLength(50)]
        public string clientIP { get; set; }
    }
}
