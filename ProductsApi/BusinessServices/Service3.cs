//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Services.Description;
//using ProductsApi.Models;

//namespace ProductsApi.BusinessServices
//{
//	public class Service3 : IService3
//	{
//		public int index { get; set; }

//		private Func<string, int, IClassA> _fb;
//		public Service3(Func<string,int,IClassA> fb)
//		{
//			_fb = fb;
//		}

//		public void m1()
//		{
//			_fb("input", 10);
//		}
//	}
//}