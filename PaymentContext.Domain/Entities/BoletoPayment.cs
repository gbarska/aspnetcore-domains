using System;

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
            string document,
            string address,
            string email,
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