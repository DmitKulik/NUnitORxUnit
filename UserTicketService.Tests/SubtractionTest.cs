using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;


namespace UserTicketService.Tests
{
    [TestFixture]
    public class TicketServiceTests
    {
        [Test]
        public void GeTicketPriceMustReturnNotNullableTicket()
        {
            var ticketServiceTest = new TicketService();
            Assert.IsNotNull(ticketServiceTest.GetTicketPrice(1));
        }

        [Test]
        public void GeTicketPriceMustThrowException()
        {
            var ticketServiceTest = new TicketService();
            Assert.Throws<TicketNotFoundException>(() => ticketServiceTest.GetTicketPrice(100));
        }

    }

    public class Ticket
    {
        public int Id { get; }
        public string Description { get; }
        public int Price { get; }

        public Ticket(int id, string description, int price)
        {
            this.Id = id;
            this.Description = description;
            this.Price = price;
        }
    }
    public interface ITicketService
    {
        int GetTicketPrice(int ticketId);
    }
    public class TicketService : ITicketService
    {
        public int GetTicketPrice(int ticketId)
        {                           //FirstOrDefault
            var ticket = FakeBaseData.FirstOrDefault(t => t.Id == ticketId);
            return (ticket is null) ?
               throw new TicketNotFoundException() : ticket.Id;
        }

        private IEnumerable<Ticket> FakeBaseData
        {
            get{
                return new List<Ticket>
                {
                      new Ticket(1, "Москва - Санкт-Петербург", 3500),
                      new Ticket(2, "Челябинск - Магадан", 3500),
                      new Ticket(3, "Норильск - Уфа", 3500)
                };
            }
        }
    }
    public class TicketNotFoundException : Exception
    {
    }
}


