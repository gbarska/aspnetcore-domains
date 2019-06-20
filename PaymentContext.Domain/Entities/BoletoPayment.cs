using System;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
     public class BoletoPayment : Payment
    {
        public BoletoPayment(
            string cardHolderName,
            string cardNumber,
            string lastTransactionNumber,
            DateTime paidDate,
            DateTime expiredDate,
            decimal total,
            decimal totalPaid,
            string payer,
            Document document,
            Address address,
            Email email,
            string barCode,
            string boletoNumber
        ):base(
             paidDate,expiredDate,total,totalPaid,payer,document,address,email)
        {
            BarCode = barCode;
            BoletoNumber = boletoNumber;
        }

        public string BarCode { get; private set; }
        public string BoletoNumber { get; private set; }
    }
}