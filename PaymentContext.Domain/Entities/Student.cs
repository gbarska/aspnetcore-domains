using System.Collections.Generic;
using System.Linq;

namespace PaymentContext.Domain.Entities
{
    public class Student
    {

        private IList<Subscription>  _subscriptions;
        public Student(string firstName, string lastName, string document, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Document = document;
            Email = email;
            _subscriptions = new List<Subscription>();
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Document { get; private set; }
        public string Email { get; private set; }
        public IReadOnlyCollection<Subscription> Subscriptions 
        { get {  return _subscriptions.ToArray(); } }

        public void AddSubscription(Subscription subscription)
        {
            //Regra de Negocio: duas opçoes: se ja existir uma assinatura ativa, cancela             
            //ou cancela toda assinatura ativa existente e adiciona a nova
            foreach(var item in Subscriptions)
               item.Inactivate();    

            _subscriptions.Add(subscription);
        }
      
    }
}