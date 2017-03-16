namespace DataModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MSIndianAppDataModel : DbContext
    {
        public MSIndianAppDataModel ()
            : base("name=MSIndianAppDataModel")
        {
        }

        public virtual DbSet<Item> Items { get; set; }

        protected override void OnModelCreating ( DbModelBuilder modelBuilder )
        {
        }
    }
}
