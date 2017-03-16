using DataModel.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class UnitOfWork : IDisposable
    {
        #region Private Member Variables
        private MSIndianAppDataModel _context = null;
        private GenericRepository<Item> _itemRepository;
        #endregion

        public UnitOfWork ()
        {
            _context = new MSIndianAppDataModel();
        }


        #region Public Repository creation properties
        public GenericRepository<Item> ItemRepository
        {
            get
            {
                if (this._itemRepository == null)
                    this._itemRepository = new GenericRepository<Item>(_context);

                return _itemRepository;
            }
        }
        #endregion

        #region Public Member Method
        /// <summary>
        /// Save Method
        /// </summary>
        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch(DbEntityValidationException e)
            {
                //Do the logging in a text file
                throw e;
            }
        }
        #endregion

        #region Implementing IDisposable

        #region private displace variable declaration..
        private bool disposed = false;
        #endregion
        
        /// <summary>
        /// Protected virtual dispose method 
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if(disposing)
                {
                    Debug.WriteLine("Unit of work is being disposed");
                    _context.Dispose();
                }
            }
            this.disposed= true;
        }


        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose ()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
