using System;

namespace BusinessServices
{


	public interface IAnotherService
	{
		int Id { get; set; }
		string Lable { get; set; }
	}

	public class AnotherService : IAnotherService,IDisposable
	{
		public int Id { get; set; }
		public string Lable { get; set; }


		public AnotherService(/* loads of dependent components*/)
		{

		}

		public override string ToString()
		{
			return string.Format("My Id is:{0} and my lable is {1}", Id, Lable);
		}

		public void Dispose()
		{
			// Another Service is Disposing ;
		}
	}

	public interface IMyService
	{
		void DoSomething();
	}

	// MyService class depends on IAnotherService
	// MyService class is a huge and long-lived class where we have just ommited lots of other implementations
	public class MyService : IMyService
	{
		private readonly IAnotherService _anotherService;

		public MyService(IAnotherService anotherService)
		{
			_anotherService = anotherService;
		}

		public void DoSomething()
		{
			Console.WriteLine(_anotherService.ToString());
		}

		//
		//
		//
		// The rest of the class
		//
		//
		//
		//
	}

//	 Considering above code MyService class depends on IAnotherService so somehow in your dependancy registration you would say
//	 builder.RegisterType<IAnotherService>().As<IAnotherService>().InstancePerDependency();
//	 this makes sure anytime an instance of MyService is instantiated or resolved using Autofac, one instance of AnotherService will be resolved beforehead within the 
//	 lifetimescope where MyService is being instantiated.
//	 and while MyService is alive or in better term it's parrent lifetimescope is alive _anotherService needs to be alive whether or not it's being used in the rest of the code of MyService 

//	 Note that an Owned instance of a service is and object instantiated from a just-newly-created lifetimescope.  
//	 Owned<IAnotherService> _anotherService ;
//	 The good point about this object (_anotherService )  before its instantiation a new lifetimescope will be initialized and this ownedAnotherService 
//	 will be instantiated within that lifetimescope
//	 anytime in the lifetime of MyService where you no longer need _anotherService you can call Dispose() method of  like _anotherService.Dispose() ;
//	 Once you dispose it, that object and the bound lifetimescope and any other child or dependant object of that lifetimescope will be gone and released. 
//	 So you would not have to bear the unnecessary presence of _anotherService and it's loads of dependent components

//	 So our constructor part of the MyService should be like following:

//		private readonly Owned<IAnotherService> _anotherService;

//		public MyService(Owned<IAnotherService> anotherService)
//		{
//			_anotherService = anotherService;
//		}

//	 meaning that we have a lifetimescope bound to the anotherService in which anotherService is being instantiated 
//	 If you want to force all the newly created objects and resolved components inside above lifetimescope to share the same instance of anotherService 
//	 then you have to use InstancePerOwned at the time of registration like this 
	
//	 builder.RegisterType<AnotherService>().As<IAnotherService>().InstancePerOwned<IAnotherService>();
//	 and once you register AnotherService as InstancePerOwned you cannot pass pure IAnotherInstance and you will have to pass it like Owned<IAnotherInstance> or else you get exception.

}