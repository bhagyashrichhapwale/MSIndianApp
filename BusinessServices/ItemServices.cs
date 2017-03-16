using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using DataModel;
using AutoMapper;
using System.Transactions;

namespace BusinessServices
{
    public class ItemServices : IItemServices
    {
        private readonly UnitOfWork _unitOfWork;

        /// <summary>
        /// Public constructor
        /// </summary>
        public ItemServices (UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ItemEntity GetItemById ( int itemId )
        {
            var item = _unitOfWork.ItemRepository.GetById(itemId);
            if(item != null)
            { 
                //Mapping of db entity Item to Business entity
                Mapper.CreateMap<Item, ItemEntity>();
                var itemModel = Mapper.Map<Item, ItemEntity>(item);
                return itemModel;
            }
            return null;
        }

        public IEnumerable<ItemEntity> GetAllItems ()
        {
            var items = _unitOfWork.ItemRepository.Get().ToList();

            if(items != null)
            {
                Mapper.CreateMap<Item, ItemEntity>();
                var itemsModel = Mapper.Map<List<Item>, List<ItemEntity>>(items);
                return itemsModel;
            }

            return null;
        }

        public int CreateItem(ItemEntity itemEntity)
        {
            using(var scope = new TransactionScope())
            {
                var item = new Item 
                {
                    ItemName = itemEntity.ItemName,
                    ItemDescription = itemEntity.ItemDescription,
                    Category = itemEntity.Category,
                    AvailStatus = itemEntity.AvailStatus,
                    ImageUrl = itemEntity.ImageUrl,
                    Price = itemEntity.Price,
                    UserId = itemEntity.UserId
                };

                _unitOfWork.ItemRepository.Insert(item);
                _unitOfWork.Save();
                scope.Complete();
                return item.Id;
            }
        }

        public bool UpdateItem(int itemId , ItemEntity itemEntity)
        {
            var success = false;

            if(itemEntity != null)
            { 
                using(var scope = new TransactionScope())
                {
                    var item = _unitOfWork.ItemRepository.GetById(itemId);
                    if(item != null)
                    {
                       item.ItemName = itemEntity.ItemName;
                       item.ItemDescription = itemEntity.ItemDescription;
                       item.Category = itemEntity.Category;
                       item.AvailStatus = itemEntity.AvailStatus;
                       item.ImageUrl = itemEntity.ImageUrl;
                       item.Price = itemEntity.Price;
                       item.UserId = itemEntity.UserId;
                        
                       _unitOfWork.ItemRepository.Update(item);
                       _unitOfWork.Save();
                       scope.Complete();
                       success = true;
                    }
                }
            }

            return success;
        }

        public bool DeleteItem(int itemId)
        {
            var success = false;

            if(itemId > 0)
            {
                using(var scope = new TransactionScope())
                {
                    var item = _unitOfWork.ItemRepository.GetById(itemId);
                    if(item != null)
                    {
                        _unitOfWork.ItemRepository.Delete(item);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }

            return success;
        }

    }
}
