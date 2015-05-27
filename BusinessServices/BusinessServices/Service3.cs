using System;
using SalesModel;

namespace BusinessServices
{
    public class Service3 : IService3
    {
        public int index { get; set; }

        private Func<string, int, IClassA> _fb;
        public Service3(Func<string,int,IClassA> fb)
        {
            _fb = fb;
        }

        public void m1()
        {
            _fb("input", 10);
        }
    }
}