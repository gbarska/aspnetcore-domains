using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities
{

    [TestClass]
    public class StudentTests
    {
        
        [TestMethod]
        public void TestMethod1()
        {
            var student = new Student(new Name(),new Document("11111111111"), new Email("addres@mail.com"));
        }
    }
}