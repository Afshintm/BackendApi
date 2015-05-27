//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Linq;
//using System.Web;

//namespace ProductsApi.Infrastructure
//{
//	public class Config : IConfig
//	{
//		const string TestUserNameKey = "TestUserName" ;
//		public string TestUserName
//		{
//			get { return GetValue(TestUserNameKey); }
//		}

//		private string GetValue(string key, string defaultValue="")
//		{
//			try
//			{
//				var value = ConfigurationManager.AppSettings[key];
//				if (string.IsNullOrEmpty(value))
//				{
//					value = defaultValue;
//				}
//				return value;
//			}
//			catch (ConfigurationErrorsException e)
//			{
//				return defaultValue;
//			}
//		}

//	}
//}