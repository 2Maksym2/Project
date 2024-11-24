using project;

namespace TestProject
{
    [TestClass]
    public class MovieTests
    {
        [TestMethod]
        public void AddMovie_AddMovieToFilmsList()
        {
            // Arrange
            int expected = 1;
            var movie1 = new Movie(FilmType.Action, "Action Movie", 120, 18, 10.99);
            var newMovie = new Movie(FilmType.Comedy, "Comedy Movie", 90, 12, 8.99);
            var expected1 = newMovie;
            // Act
            movie1.AddMovie(newMovie);

            // Assert
            Assert.AreEqual(expected, movie1.Films.Count);
            Assert.AreEqual(expected1, movie1.Films[0]);
        }
    }

    [TestClass]
    public class CustomerTests
    {
        [TestMethod]
        public void CanWatchMovie_ShouldReturnTrue()
        {
            // Arrange
            var movie = new Movie(FilmType.Drama, "Drama Film", 150, 18, 12.99);
            var customer = new Customer("Alice", 20);

            // Act
            var result = customer.CanWatchMovie(movie);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanWatchMovie_ShouldReturnFalse()
        {
            // Arrange
            var movie = new Movie(FilmType.Horror, "Scary Movie", 100, 16, 9.99);
            var customer = new Customer("Bob", 14);

            // Act
            var result = customer.CanWatchMovie(movie);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void BuyTicketTest()
        {
            // Arrange
            var customer = new Customer("Charlie", 25);
            var movie = new Movie(FilmType.Adventure, "Exciting Film", 130, 12, 11.50);

            // Act
            var ticket = customer.BuyTicket(customer);

            // Assert
            Assert.IsTrue(ticket.Contains(customer.Name));
            Assert.IsTrue(ticket.Contains(movie.Title));
        }
    }
}