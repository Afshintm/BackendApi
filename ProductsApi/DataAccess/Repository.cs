//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Web;

//namespace ProductsApi.DataAccess
//{
//	public interface IRepository<TEntity> : IDisposable where TEntity : class
//	{
//		TEntity FindById(object id);
//		void InsertGraph(TEntity entity);
//		void Update(TEntity entity);
//		void Delete(object id);
//		void Delete(TEntity entity);
//		void Insert(TEntity entity);
//		RepositoryQuery<TEntity> Query();

//	}

//	public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
//	{
//		public TEntity FindById(object id)
//		{
//			throw new NotImplementedException();
//		}

//		public void InsertGraph(TEntity entity)
//		{
//			throw new NotImplementedException();
//		}

//		public void Update(TEntity entity)
//		{
//			throw new NotImplementedException();
//		}

//		public void Delete(object id)
//		{
//			throw new NotImplementedException();
//		}

//		public void Delete(TEntity entity)
//		{
//			throw new NotImplementedException();
//		}

//		public void Insert(TEntity entity)
//		{
//			throw new NotImplementedException();
//		}

//		public RepositoryQuery<TEntity> Query()
//		{
//			throw new NotImplementedException();
//		}

//		public void Dispose()
//		{
//			throw new NotImplementedException();
//		}
//		/// <summary>
//		/// Repository Get method is accessable inside the repository assembly
//		/// </summary>
//		/// <param name="filter"></param>
//		/// <param name="orderBy"></param>
//		/// <param name="includeProperties"></param>
//		/// <param name="page"></param>
//		/// <param name="pageSize"></param>
//		/// <returns></returns>
//		internal IQueryable<TEntity> Get(
//			Expression<Func<TEntity, bool>> filter = null,
//			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
//			List<Expression<Func<TEntity, object>>> includeProperties = null,
//			int? page = null,
//			int? pageSize = null)
//		{
//			IQueryable<TEntity> query = DbSet;

//			if (includeProperties != null)
//				includeProperties.ForEach(i => { query = query.Include(i); });

//			if (filter != null)
//				query = query.Where(filter);

//			if (orderBy != null)
//				query = orderBy(query);

//			if (page != null && pageSize != null)
//				query = query
//					.Skip((page.Value - 1) * pageSize.Value)
//					.Take(pageSize.Value);

//			return query;
//		}

//	}
//}