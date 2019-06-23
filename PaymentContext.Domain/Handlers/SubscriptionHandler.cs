using System;
using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;

namespace PaymentContext.Domain.Handlers
{
    public class SubscriptionHandler :
            Notifiable,
            IHandler<CreateBoletoSubscriptionCommand>,
            IHandler<CreatePayPalSubscriptionCommand>
    {
        private readonly IStudentRepository _repository;
        private readonly IEmailService _emailService;

        public SubscriptionHandler(IStudentRepository repository,IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }
        public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
        {
            //FailFast Validations
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possivel realizar sua assinatura");
            }
           
            //verificar se o Documento ja esta cadastrado
            if (_repository.DocumentExists(command.Document))
              AddNotification("Document","Este documento já está em uso");
           
            //verificar se o Documento ja esta cadastrado
            if (_repository.EmailExists(command.Email))
              AddNotification("Document","Este email já está em uso");
              
            //gerar os VOS
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document,EDocumentType.CPF);
            var email = new Email(command.Email);
            var address = new Address(command.Street,command.Number,command.Neighborhood,command.City,command.State,command.Country,command.Zipcode);
            
            //gerar as entidades
            var student = new Student(name,document,email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
           
           //so muda a implementacao do pagamento
            var payment = new BoletoPayment(
                command.BarCode,
                command.BoletoNumber,
                command.PaidDate,
                command.ExpiredDate,
                command.Total,
                command.TotalPaid,
                command.Payer,
                new Document(command.PayerDocument,command.PayerDocumentType),
                 address,
                  email
                  );
            
            //relacionamentos    
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            //aplicar as validacoes
            AddNotifications(name, document,email, address,student, subscription,payment);
           
            //salvar as informacoes
            _repository.CreateSubscription(student);
       
            //enviar email de boas vindas
            _emailService.Send(student.Name.ToString(),student.Email.Address,"Bem vindo ao balta.io","Sua assinatura foi criada!");
           
            //retornar informacoes
            return new CommandResult(true,"Assinatura realizada com sucesso");

        }

        public ICommandResult Handle(CreatePayPalSubscriptionCommand command)
        {
              //FailFast Validations
            // command.Validate();
            // if (command.Invalid)
            // {
            //     AddNotifications(command);
            //     return new CommandResult(false, "Não foi possivel realizar sua assinatura");
            // }
           
            //verificar se o Documento ja esta cadastrado
            if (_repository.DocumentExists(command.Document))
              AddNotification("Document","Este documento já está em uso");
           
            //verificar se o Documento ja esta cadastrado
            if (_repository.EmailExists(command.Email))
              AddNotification("Document","Este email já está em uso");
              
            //gerar os VOS
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document,EDocumentType.CPF);
            var email = new Email(command.Email);
            var address = new Address(command.Street,command.Number,command.Neighborhood,command.City,command.State,command.Country,command.Zipcode);
            
            //gerar as entidades
            var student = new Student(name,document,email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
           
            var payment = new PayPalPayment(
                command.PaidDate,
                command.ExpiredDate,
                command.Total,
                command.TotalPaid,
                command.Payer,
                new Document(command.PayerDocument,command.PayerDocumentType),
                 address,
                  email,
                  command.TransactionCode
                  );
            
            //relacionamentos    
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            //aplicar as validacoes
            AddNotifications(name, document,email, address,student, subscription,payment);
           
            //salvar as informacoes
            _repository.CreateSubscription(student);
       
            //enviar email de boas vindas
            _emailService.Send(student.Name.ToString(),student.Email.Address,"Bem vindo ao balta.io","Sua assinatura foi criada!");
           
            //retornar informacoes
            return new CommandResult(true,"Assinatura realizada com sucesso");
        }
    }
}