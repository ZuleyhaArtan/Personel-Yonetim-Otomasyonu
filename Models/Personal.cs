namespace deneme2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Personal")]
    public partial class Personal
    {
        public int personalId { get; set; }

        public DateTime createDate { get; set; }

        [Required]
        [StringLength(50)]
        public string personalName { get; set; }

        [Required]
        [StringLength(50)]
        public string personalLastName { get; set; }

        [Required]
        [StringLength(11)]
        public string tcNo { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime dateOfBirth { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime workStartTime { get; set; }

        public int? cityId { get; set; }

        public bool gender { get; set; }

        public int? departmantId { get; set; }

        [Required]
        [StringLength(50)]
        public string password { get; set; }

        public bool isUser { get; set; }

        public virtual City City { get; set; }

        public virtual Departmant Departmant { get; set; }
    }
}
