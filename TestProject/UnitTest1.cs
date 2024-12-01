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
        public void AddSession_ShouldAddSessionToList()
        {
            // Arrange
            var cinema = new Cinema();
            var hall = new Hall(1, 50);
            var movie = new Movie("Action Movie", FilmType.Action, 120);
            var session = new Session(movie, hall, DateTime.Now, 150);
            int expectedCount = 1;

            // Act
            cinema.AddSession(session);

            // Assert
            Assert.AreEqual(expectedCount, cinema.Sessions.Count);
        }
    }
    [TestClass]
    public class TicketSingleTests
    {
        public void BuySingleTicket_ReduceAvailableSeats()
        {
            // Arrange
            var hall = new Hall(1, 50);
            var movie = new Movie("Drama Movie", FilmType.Drama, 150);
            var session = new Session(movie, hall, DateTime.Now, 15);
            int seatNumber = 5;
            int expectedAvailableSeats = hall.Capacity - 1;

            // Act
            var ticket = session.BuySingleTicket(seatNumber);

            // Assert
            Assert.AreEqual(expectedAvailableSeats, session.AvailableSeats.Count);
            Assert.IsFalse(session.AvailableSeats.Contains(seatNumber));
        }
    }
    [TestClass]
    public class TicketGroupTests
    {
        public void BuyGroupTicket_ReduceAvailableSeats()
        {
            // Arrange
            var hall = new Hall(1, 50);
            var movie = new Movie("Adventure Movie", FilmType.Adventure, 140);
            var session = new Session(movie, hall, DateTime.Now, 20);
            var seatNumbers = new List<int> { 1, 2, 3 };
            int expectedAvailableSeats = hall.Capacity - seatNumbers.Count;

            // Act
            var ticket = session.BuyMultipleTickets(seatNumbers);

            // Assert
            Assert.AreEqual(expectedAvailableSeats, session.AvailableSeats.Count);
            foreach (var seat in seatNumbers)
            {
                Assert.IsFalse(session.AvailableSeats.Contains(seat));
            }
        }
    }

}