using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTest
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void Test1() 
        {
            Assert.That(1, Is.EqualTo(1));
        }
    }
}
