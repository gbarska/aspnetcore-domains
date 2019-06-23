using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using System;

namespace PaymentContext.Tests
{

    [TestClass]
    public class StudentTests
    {
        private readonly Subscription _subscription;
        private readonly Address _address;
        private readonly Document _document;
        private readonly Email _email;
        private readonly Student _student;
        private readonly Name _name;
        public  StudentTests()
        {
            _name = new Name("Bruce", "Wayne");
            _document = new Document("38540733056",EDocumentType.CPF);
            _email = new Email("bat@caverna.com");
            _student = new Student(_name,_document,_email);
            _subscription = new Subscription(null);
            _address = new Address("rua das esquinas","10","vila","hortslandia","sampa","Brazil","00000000");
            
        }

        [TestMethod]
        public void ShouldReturnErrorWhenAddSubscription()
        {   
            var payment = new PayPalPayment(DateTime.Now,DateTime.Now.AddDays(5),10,10,"WAYNE CORP",_document,_address,_email,"1234678");
            _subscription.AddPayment(payment);

            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);

         Assert.IsTrue(_student.Invalid);

        }

        [TestMethod]
        public void ShouldReturnErrorWhenSubscriptionHasNoPayment()
        {
            // _student.AddSubscription(_subscription);
        _student.AddSubscription(_subscription);
         Assert.IsTrue(_student.Invalid);   

        }

        [TestMethod]
        public void ShouldReturnSuccessWhenAddSubscription()
        {
         var payment = new PayPalPayment(DateTime.Now,DateTime.Now.AddDays(5),10,10,"WAYNE CORP",_document,_address,_email,"1234678");
            _subscription.AddPayment(payment);

            // _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);

         Assert.IsTrue(_student.Valid);

        }
    }
}