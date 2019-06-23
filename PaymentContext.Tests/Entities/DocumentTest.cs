using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests
{

    [TestClass]
    public class DocumentTest
    {
        //Red, Green, Refactor

        [TestMethod]
        public void ShouldReturnErrorWhenCNPJIsInvalid()
        {
            var doc = new Document("123", Domain.Enums.EDocumentType.CNPJ);
            Assert.IsTrue(doc.Invalid);
        }
        
        [TestMethod]
        public void ShouldReturnSuccessWhenCNPJIsValid()
        {
            var doc = new Document("11112311111111", Domain.Enums.EDocumentType.CNPJ);
            Assert.IsTrue(doc.Valid);
        }
        [TestMethod]
        public void ShouldReturnErrorWhenCPFJIsInvalid()
        {
            var doc = new Document("123", Domain.Enums.EDocumentType.CPF);
            Assert.IsTrue(doc.Invalid);
        }
        
        [TestMethod]
        [DataTestMethod]
        [DataRow("43428666097")]
        [DataRow("11996366068")]
        [DataRow("38540733056")]
        public void ShouldReturnSuccessWhenCPFIsValid(string cpf)
        {
            var doc = new Document(cpf, Domain.Enums.EDocumentType.CPF);
            Assert.IsTrue(doc.Valid);
        }   
    }
}