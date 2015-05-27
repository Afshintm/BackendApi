using System;
using System.Collections.Generic;
using DataAccess;
using DbContexts;
using Infrastructure;


namespace BusinessServices
{
    public interface IService1
    {
        IUnitOfWork<SimpleContext> Uow { get; set; }
        List<int> Ints { get; set; }
        Func<IConfig> GetConfig { get; }
    }
}