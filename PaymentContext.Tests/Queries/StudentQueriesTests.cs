using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests
{

    [TestClass]
    public class StudentQueriesTests

    {
        //Red, Green, Refactor
        private IList<Student> _students;
        
        public StudentQueriesTests()
        {
            _students = new List<Student> ();
            for (int i = 0; i < 10; i++)
            {
                _students.Add(new Student(
                    new Name("Aluno","Test Name"),
                    new Document("1111111111"+i.ToString(),Domain.Enums.EDocumentType.CPF),
                    new Email(i.ToString()+"@mail.com")));
            }
        }

        [TestMethod]
        public void ShouldReturnNullWhenDocumentDoesNotExists()
        {
            var exp = StudentQueries.GetStudentInfo("12345678911");
            var student = _students.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreEqual(null,student);
        }
        
        [TestMethod]
        public void ShouldReturnStudentWhenDocumentExists()
        {
            var exp = StudentQueries.GetStudentInfo("11111111111");
            var student = _students.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreNotEqual(null,student);
        }
    }
}