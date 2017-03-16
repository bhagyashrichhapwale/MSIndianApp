using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class ItemEntity
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public string ImageUrl { get; set; }
        public int Category { get; set; }
        public decimal? Price { get; set; }
        public int UserId { get; set; }
        public bool AvailStatus { get; set; }
    }
}
