using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;

namespace PaymentContext.Tests.Entities
{

    [TestClass]
    public class StudentTests
    {
        
        [TestMethod]
        public void TestMethod1()
        {
            var student = new Student("Gustavo","Barska","11111111111","email@gbarska.tk");
        }
    }
}