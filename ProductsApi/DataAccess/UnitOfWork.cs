//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace ProductsApi.DataAccess
//{
//	public interface IUnitOfWork
//		{
//			Guid? Id { get; set; }
//			void Commit();
//			IRepository<T> Repository<T>() where T : class;
//		}

//	public interface IUnitOfWork<TContext> : IUnitOfWork
//	{
//		TContext Context { get; set;}
//	}

//	public class UnitOfWork : IUnitOfWork, IDisposable
//		{
//			private Guid? _id;
//			public Guid? Id
//			{
//				get
//				{
//					if (_id == null)
//						_id = Guid.NewGuid();
//					return _id;
//				}
//				set { _id = value; }
//			}

//			public void Commit()
//			{

//			}

//			public void Dispose()
//			{
//				Id = null;
//			}
//		}
//}