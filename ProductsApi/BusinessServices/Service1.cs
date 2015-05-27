//using System;
//using System.Collections.Generic;
//using Autofac.Features.OwnedInstances;
//using DataAccess;
//using ProductsApi.DataAccess;
//using ProductsApi.Infrastructure;
//using ProductsApi.Models;
//using SalesModel;

//namespace ProductsApi.BusinessServices
//{
//	public class Service1 : ServiceBase, IService1
//	{
//		public IClassA ClassA { get; set; }
//		public Owned<IClassB> OwnedClassB { get; set; }

//		public IUnitOfWork Uow { get; set; }

//		private List<int> _ints;
//		public List<int> Ints
//		{
//			get
//			{
//				if (_ints == null) _ints = new List<int>();
//				return _ints;
//			}
//			set { _ints = value; }
//		}

//		public Func<IConfig> GetConfig {
//			get { return (() => Config); }
//		}
//		public Service1(IConfig config, ILogger logger , IExceptionHandler exceptionHandler , ISecurityProvider securityProvider,IClassA classA, 
//			Owned<IClassB> ownedClassB, IUnitOfWork uow) : base(config,logger,exceptionHandler,securityProvider)
//		{
//			ClassA = classA;
//			OwnedClassB = ownedClassB;
//			Uow = uow;
//		}
//		public int Index { get; set; }


//	}
//}