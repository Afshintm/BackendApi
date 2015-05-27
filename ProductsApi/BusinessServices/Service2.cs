//using System;
//using Autofac.Features.OwnedInstances;
//using SalesModel;

//namespace ProductsApi.BusinessServices
//{
//	public class Service2: IService2
//	{

//		public Owned<IClassA> OwnedClassA { get; set; }
//		public Service2(Owned<IClassA> ownedClassA ,Func<Owned<IUnitOfWork>> uowFunc )
//		{
//			OwnedClassA = ownedClassA;
//			_uowFunc = uowFunc;
//		}
//		public void DoWork()
//		{
//			using (var u = _uowFunc())
//			{
//				u.Value.Commit();
//				OwnedClassA.Value.Id = 10;
//			}
//		}

//		private Func<Owned<IUnitOfWork>> _uowFunc;
//		public Func<Owned<IUnitOfWork>> UowFunc
//		{
//			get { return _uowFunc; }
//			set { _uowFunc = value; }
//		}
//	}
//}