using System;
using Autofac.Features.OwnedInstances;
using DataAccess;
using DbContexts;
using SalesModel;

namespace BusinessServices
{
    public interface IService2
    {
        Owned<IClassA> OwnedClassA { get; set; }
        Func<Owned<IUnitOfWork<SimpleContext>>> UowFunc { get; set;}

        void DoWork();
    }
}