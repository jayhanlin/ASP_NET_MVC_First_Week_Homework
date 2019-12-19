using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Homework.Repository.Services
{
    public class BaseService<TEntity> : IDisposable where TEntity : class
    {
        private DbContext baseContext { get; set; }
        public BaseService(DbContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            
            context.Database.CommandTimeout = 300;   //設置為5分鐘
            this.baseContext = context;
            ///// Entity SQL語法紀錄
            //this.baseContext.Database.Log = (slog) => Debug.WriteLine(slog);
        }

        /// <summary>
        /// 建立資料
        /// </summary>
        /// <param name="instance">table entity object</param>
        public void Create(TEntity instance)
        {
            if (instance == null)
                throw new ArgumentNullException("instance");

            this.baseContext.Set<TEntity>().Add(instance);
            this.SaveChanges();
        }

        /// <summary>
        /// 建立多筆資料
        /// </summary>
        /// <param name="instances">table entity object collection</param>
        public void CreateMultiple(IEnumerable<TEntity> instances)
        {
            if (instances == null)
                throw new ArgumentNullException("instance");

            baseContext.Set<TEntity>().AddRange(instances);
            SaveChanges();
        }

        /// <summary>
        /// 更新資料
        /// </summary>
        /// <param name="instance">table entity object</param>
        public void Update(TEntity instance)
        {
            if (instance == null)
                throw new ArgumentNullException("instance");

            this.baseContext.Entry(instance).State = EntityState.Modified;
            this.SaveChanges();
        }

        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <param name="instance">table entity object</param>
        public void Delete(TEntity instance)
        {
            if (instance == null)
                throw new ArgumentNullException("instance");

            this.baseContext.Entry(instance).State = EntityState.Deleted;
            this.SaveChanges();
        }

        /// <summary>
        /// 依照PK取得資料
        /// </summary>
        /// <param name="keyValues">key object list</param>
        /// <returns>table entity object</returns>
        public TEntity GetDataByKey(params object[] keyValues)
        {
            return this.baseContext.Set<TEntity>().Find(keyValues);
        }

        /// <summary>
        /// 取得所有資料
        /// </summary>
        /// <returns>table entity object collection</returns>
        public IQueryable<TEntity> GetDataAll()
        {
            return this.baseContext.Set<TEntity>().AsQueryable();
        }

        /// <summary>
        /// 依照where陳述式取得所有資料
        /// </summary>
        /// <param name="predicate">Where Lamda陳述式</param>
        /// <returns>table entity object collection</returns>
        protected IQueryable<TEntity> GetDataByExpression(Expression<Func<TEntity, bool>> wPredicate)
        {
            if (wPredicate != null)
                return this.baseContext.Set<TEntity>().Where<TEntity>(wPredicate);

            throw new ArgumentNullException("wPredicate");
        }

        //<summary>
        //執行Native SQL語法
        //</summary>
        //<param name="Sql">SQL Command</param>
        //<param name="Params">SQL Params</param>
        /// <returns>table entity object collection</returns>
        protected IQueryable<TEntity> NativeSQL(string Sql, params object[] Params)
        {
            return this.baseContext.Set<TEntity>().SqlQuery(Sql, Params).AsQueryable();
        }

        /// <summary>
        /// 執行跨Table Native SQL語法 or Store Procedure
        /// </summary>
        /// <typeparam name="T">自訂義物件</typeparam>
        /// <param name="Sql">SQL Command</param>
        /// <param name="Params">SQL Params</param>
        /// <returns>user define object</returns>
        protected IQueryable<T> NativeSQLEx<T>(string Sql, params object[] Params) where T : class
        {
            return this.baseContext.Database.SqlQuery<T>(Sql, Params).AsQueryable();
        }

        /// <summary>
        /// 執行Insert, Update, Delete語法
        /// </summary>
        /// <typeparam name="T">自訂義物件</typeparam>
        /// <param name="Sql">SQL Command</param>
        /// <param name="Params">SQL Params</param>
        /// <returns>user define object</returns>
        protected int NativeExecuteSqlCommand(string Sql, params object[] Params)
        {
            return this.baseContext.Database.ExecuteSqlCommand(Sql, Params);
        }

        /// <summary>
        /// DbContext's SaveChanges
        /// </summary>
        public void SaveChanges()
        {
            this.baseContext.SaveChanges();
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Overwrite Dispose
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.baseContext != null)
                {
                    this.baseContext.Dispose();
                    this.baseContext = null;
                }
            }
        }

    }

}
