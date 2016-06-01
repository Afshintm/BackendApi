using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesModel
{
    public interface IClass1 
    {
        string Name { get; set; }
    }
    public class Class1:IClass1 
    {
        public string Name{get;set;}
        public Class1(string input) { 
            Name = input ;
        }
    }
}
