using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
    public interface IItemServices
    {
        ItemEntity GetItemById ( int itemId );
        IEnumerable<ItemEntity> GetAllItems ();
        int CreateItem ( ItemEntity item );
        bool UpdateItem ( int itemId , ItemEntity item );
        bool DeleteItem ( int itemId );
    }
}
