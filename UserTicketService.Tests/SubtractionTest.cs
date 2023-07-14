using NUnit.Framework;
using System;
using System.Security.Cryptography.X509Certificates;


namespace UserTicketService.Tests
{
    public class SubtractionTest
    {
        [Test]
        public void SubtractionReturn()
        {
            var wq = new Subtraction();
               
            Assert.That(wq.SubtractionTest(4, 1) == 3);
            
        }
        [Test]
        public void SubtractionReturn2()
        {
            var wq = new Subtraction();

            Assert.That(wq.Division(4, 4) == 1);
        }
        [Test]
        public void SubtractionReturn3()
        {
            var wq = new Subtraction();

            Assert.Throws<DivideByZeroException> (() => wq.Division(4, 0));
        }
    }

    

    public class Subtraction
    {
        public int SubtractionTest(int a, int b)
        {
            return a - b;
        }
        public int Division(int a, int b)
        {
            return a / b;
        }
    }
}


