using NUnit.Framework;

namespace Utils.Test
{
	[TestFixture]
	public class UtilsTests
	{

		[OneTimeSetUp]
		public void OneTimeSetup()
		{
		}

		[SetUp]
		public void Setup()
		{
		}


		[Test]
		public void TestMethod()
		{
			var teststring = "afshin:Password!";
			var encoded = teststring.EncodeToBase64();
			var decoded = encoded.DecodeFromBase64();
			Assert.That(teststring, Is.EqualTo(decoded));
		}


		[TearDown]
		public void Teardown()
		{
		}


		[OneTimeTearDown]
		public void OneTimeTearDown()
		{
		}

	}
}
