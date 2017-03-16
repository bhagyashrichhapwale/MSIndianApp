namespace DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblItem")]
    public partial class Item
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string ItemName { get; set; }

        [StringLength(300)]
        public string ItemDescription { get; set; }

        [StringLength(200)]
        public string ImageUrl { get; set; }

        public int Category { get; set; }

        public decimal? Price { get; set; }

        public int UserId { get; set; }

        public bool AvailStatus { get; set; }
    }
}
