using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests
{
     [TestClass]
    public class SubscriptionHandlerTests
    {
           [TestMethod]
        public void ShouldReturnErrorWhenDocumentExists()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(),new FakeEmailService());
            var command = new CreateBoletoSubscriptionCommand();
            
        command.FirstName ="Bruce";
        command.LastName ="Wayne";
        command.Document ="99999999999";
        command.Email ="email23@example.com";
        command.BarCode ="1234567890";
        command.BoletoNumber ="12345044444";
        command.PaymentNumber ="123121";
        command.PaidDate =DateTime.Now;
        command.ExpiredDate =DateTime.Now.AddMonths(1);
        command.Total = 60;
        command.TotalPaid =60;
        command.Payer ="Wayne Corp";
        command.PayerDocument ="11111111111";
        command.PayerDocumentType = EDocumentType.CPF;
        command.PayerEmail ="bat@dc.com";
        command.Street ="gotham st";
        command.Number ="10";
        command.Neighborhood = "gotham neigh";
        command.City ="gotham";
        command.State ="got";
        command.Country ="us";
        command.Zipcode ="00000000";

        handler.Handle(command);
        Assert.AreEqual(false,handler.Valid);
        }
    }
}