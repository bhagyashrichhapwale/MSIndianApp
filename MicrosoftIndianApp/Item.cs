namespace MicrosoftIndianApp
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Item : DbContext
    {
        public Item ()
            : base("name=Item")
        {
        }

        public virtual DbSet<tblItem> tblItems { get; set; }

        protected override void OnModelCreating ( DbModelBuilder modelBuilder )
        {
        }
    }
}
