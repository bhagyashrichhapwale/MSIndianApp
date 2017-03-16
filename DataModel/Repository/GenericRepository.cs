using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Repository
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        #region Private Member Variables
        internal MSIndianAppDataModel context;
        internal DbSet<TEntity> db;
        #endregion

        #region Public Constructor..
        public GenericRepository (MSIndianAppDataModel context)
        {
            this.context = context;
            this.db = context.Set<TEntity>();
        }
        #endregion

        #region Public Member Method
        
        /// <summary>
        /// Generic Get method for all entities
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> Get()
        {
            IQueryable<TEntity> query = db;
            return query.ToList();
        }
        
        /// <summary>
        /// Generic Get Method on basis of ids 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual TEntity GetById(int id)
        {
            return db.Find(id);
        }

        /// <summary>
        /// Add a new Entity to the db
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Insert(TEntity entity)
        {
            db.Add(entity);
        }

        /// <summary>
        /// Modify the entity
        /// </summary>
        /// <param name="entityToUpdate"></param>
        public virtual void Update(TEntity entityToUpdate)
        {
            db.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        /// <summary>
        /// Delete an entry 
        /// </summary>
        /// <param name="entityToDeleted"></param>
        public virtual void Delete(int id)
        {
            var entityToDeleted = db.Find(id);
            Delete(entityToDeleted);

        }
       
        /// <summary>
        /// Delete method for entities
        /// </summary>
        /// <param name="entityToDeleted"></param>
        public virtual void Delete( TEntity entityToDeleted )
        {
            if(context.Entry(entityToDeleted).State == EntityState.Detached)
            {
                db.Attach(entityToDeleted);
            }
            db.Remove(entityToDeleted);
        }

        #endregion  
    }
}
