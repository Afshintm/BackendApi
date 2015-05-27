using System;
using Autofac.Features.OwnedInstances;
using DataAccess;
using DbContexts;
using SalesModel;

namespace BusinessServices
{
    public class Service2: IService2
    {

        public Owned<IClassA> OwnedClassA { get; set; }
        public Service2(Owned<IClassA> ownedClassA ,Func<Owned<IUnitOfWork<SimpleContext>>> uowFunc )
        {
            OwnedClassA = ownedClassA;
            _uowFunc = uowFunc;
        }
        public void DoWork()
        {
            using (var u = _uowFunc())
            {
                u.Value.Save();
                OwnedClassA.Value.Id = 10;
            }
        }

        private Func<Owned<IUnitOfWork<SimpleContext>>> _uowFunc;
		public Func<Owned<IUnitOfWork<SimpleContext>>> UowFunc
        {
            get { return _uowFunc; }
            set { _uowFunc = value; }
        }
    }
}