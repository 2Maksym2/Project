using project;

namespace TestProject
{
    [TestClass]
    public class MovieTests
    {
        [TestMethod]
        public void AddMovie_AddMovieToList()
        {
            // Arrange
            var cinema = new Cinema();
            var movie = new Movie("Funny Movie", FilmType.Comedy, 90);
            int expectedMovieCount = 1;

            // Act
            cinema.AddMovie(movie);

            // Assert
            Assert.AreEqual(expectedMovieCount, cinema.Movies.Count);
        }
    }

    [TestClass]
    public class HallTests
    {
        [TestMethod]
        public void AddSession_AddSessionToList()
        {
            // Arrange
            var cinema = new Cinema();
            var hall = new Hall(1, 50);
            List<int> seats = new List<int>();
            for (int i = 1; i <= hall.Capacity; i++)
            {
                seats.Add(i);
            }

            var movie = new Movie("Action Movie", FilmType.Action, 120);
            var session = new Session(movie, DateTime.Now, 150, seats);
            int expectedCount = 1;

            // Act
            hall.AddSession(session);

            // Assert
            Assert.AreEqual(expectedCount, hall.Sessions.Count);
        }
    }
    [TestClass]
    public class TicketSingleTests
    {
        [TestMethod]
        public void BuySingleTicket_ReduceAvailableSeats()
        {
            // Arrange
            var hall = new Hall(1, 50);
            var movie = new Movie("Drama Movie", FilmType.Drama, 150);
            List<int> seats = new List<int>();
            for (int i = 1; i <= hall.Capacity; i++)
            {
                seats.Add(i);
            }
            var session = new Session(movie, DateTime.Now, 15, seats);
            int seatNumber = 5;
            int expectedAvailableSeats = hall.Capacity - 1;
            var customer = new Customer("Ivan");

            // Act
            var ticket = customer.BuySingleTicket(session, seatNumber);

            // Assert
            Assert.AreEqual(expectedAvailableSeats, session.AvailableSeats.Count);
            Assert.IsFalse(session.AvailableSeats.Contains(seatNumber));
        }
    }
    [TestClass]
    public class TicketGroupTests
    {
        [TestMethod]
        public void BuyGroupTicket_ReduceAvailableSeats()
        {
            // Arrange
            var hall = new Hall(1, 50);
            var movie = new Movie("Adventure Movie", FilmType.Adventure, 140);
            List<int> seats = new List<int>();
            for (int i = 1; i <= hall.Capacity; i++)
            {
                seats.Add(i);
            }

            var session = new Session(movie, DateTime.Now, 20, seats);
            var seatNumbers = new List<int> { 1, 2, 3 };
            int expectedAvailableSeats = hall.Capacity - seatNumbers.Count;
            var customer = new Customer("Ivan");

            // Act
            var ticket = customer.BuyGroupTickets(session, seatNumbers);

            // Assert
            Assert.AreEqual(expectedAvailableSeats, session.AvailableSeats.Count);
            foreach (var seat in seatNumbers)
            {
                Assert.IsFalse(session.AvailableSeats.Contains(seat));
            }
        }
    }

}