using System.Collections.Generic;
using System.Linq;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public class Student : Entity
    {
        private IList<Subscription>  _subscriptions;
        public Student(Name name, Document document, Email email)
        {
            Name = name;
            Document = document;
            Email = email;
            _subscriptions = new List<Subscription>();
            
            AddNotifications(name,document,email);
        }

        public Name Name { get; set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; set; }
        public IReadOnlyCollection<Subscription> Subscriptions 
        { get {  return _subscriptions.ToArray(); } }

        public void AddSubscription(Subscription subscription)
        {
            //Regra de Negocio: duas opçoes: se ja existir uma assinatura ativa, cancela             
            //ou cancela toda assinatura ativa existente e adiciona a nova
            // foreach(var item in Subscriptions)
            //    item.Inactivate();    
            var hasSubsActive = false;

            foreach (var item in _subscriptions)
            {
                if (item.Active) 
                    hasSubsActive = true;               
            }                

            AddNotifications(new Contract()
            .Requires()
            .IsFalse(hasSubsActive,"Student.Subscriptions","Você já tem uma assinatura ativa")
            );

            _subscriptions.Add(subscription);
        }
      
    }
}