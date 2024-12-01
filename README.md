__ПОСТАНОВКА ЗАДАЧІ__
1.	Обрати і коротко описати нову предметну область.
2.	Для обраної предметної області з використанням IDE (наприклад, Visual Studio 2022) або будь-якого спеціалізованого онлайн-сервісу (наприклад, https://www.lucidchart.com) за два етапи побудувати модель предметної області у вигляді діаграми класів, на якій класи/інтерфейси мають бути пов’язані різними типами відношень: асоціація, агрегація, композиція, реалізація.
Етап 1: Виявлення та визначення необхідних перелічень, класів, інтерфейсів та зав’язків між ними (див. приклад на рис. 1). Бажано використовувати всі перелічені у п.2 типи відношень. 
Порада: якщо предметна область буде стосуватися приватної клініки, то розпочати виділення класів з класу «Клініка» і далі дивитися: а які інші класи потрібні, і як вони будуть пов’язані з класом «Клініка» і з іншими вже виділеними класами.
Етап 2: Детальне проєктування класів та інтерфейсів: для полів/властивостей необхідно вказати модифікатор доступу, назву, тип; для методів – додатково визначити тип значення, що повертається, та список параметрів 
3.	Засобами середи розробки (IDE) отримати/створити каркас проєкту, для цього необхідно визначити в окремих файлах *.cs всі спроєктовані у п.2 інтерфейси, класи, перелічення. Коректно реалізувати відношення між класами! Увага! Реалізовувати властивості, конструктори і методи у класах не потрібно! Замість реального коду вони мають містити «заглушки»: throw new NotImplementedException().
4.	Для тестування спроєктованих класів додати проєкт з тест-класами, які повинні містити достатній для повноцінного тестування набір реалізованих unit-тестів. Увага! Методи класів предметної області коду ще не мають, але для них вже пишемо повноцінні unit-тести (TDD-принцип розробки програми). Після запуску розроблених unit-тестів їх статус має бути failed.
5.	Використання GitHub-репозиторію з коммітами є обов’язковим! Репозиторій повинен мати заповнений Readme.md файл, в який необхідно: 
-	додати оформлений за допомогою markdown-розмітки опис предметної області (використовуйте заголовки, списки, рисунки та ін.);
-	вставити розроблену діаграму класів.
 

__ВИКОНАННЯ РОБОТИ__

__Опис класу__

Опис предметної області: кінотеатр
1.	Перелічення (Enum):

–	FilmType – перелік жанрів фільмів (драма, комедія, фільми жахів, фантазія, романтика, трилер, анімація, документальний фільм, пригодницький фільм, мюзикл, історичний фільм.)

2.	Класи:

–	Hall – клас для зберігання списку залів та сеансів на які можна замовити квиток.

–	Cinema – клас для створення сеансів до окремої зали.

–	Movie – клас для зберігання кожного фільму з назвами, описами та жанрами.

–	Customer – клас, що представляє клієнта кінотеатру, який купує квиток.

–	Cashier – клас для касира, який продає квитки.

3.	Інтерфейси:

–	IPrintable – інтерфейс для друку доступних сеансів у кожній залі.

__Виявлення та визначення класів і зв'язків__

Асоціація: Клас Cinema має асоціацію з класом Cashier (кінотеатр може найняти багато касирів).

Агрегація: Клас Hall має агрегацію з класом Movie (кожна зала містить фільми, але фільми існують незалежно).

Композиція: Клас Cinema має композицію з класом Hall, при видаленні класу Cinema зали також будуть видалені.

Реалізація: Клас Hall реалізує інтерфейс IPrintable.

![ Виявлення та визначення елементів предметної області та зв’язки між ними](https://github.com/2Maksym2/Project/blob/main/Pictures/%D0%97%D0%BD%D1%96%D0%BC%D0%BE%D0%BA%20%D0%B5%D0%BA%D1%80%D0%B0%D0%BD%D0%B0%202024-11-25%20071823.jpg)

Рисунок 1 – Виявлення та визначення елементів предметної області та зв’язки між ними
 
 ![ Детальне проєктування елементів моделі предметної області](https://github.com/2Maksym2/Project/blob/main/Pictures/%D0%97%D0%BD%D1%96%D0%BC%D0%BE%D0%BA%20%D0%B5%D0%BA%D1%80%D0%B0%D0%BD%D0%B0%202024-11-25%20071807.jpg)

Рисунок 2 – Детальне проєктування елементів моделі предметної області

 ![ Запущені тести](https://github.com/2Maksym2/Project/blob/main/Pictures/%D0%97%D0%BD%D1%96%D0%BC%D0%BE%D0%BA%20%D0%B5%D0%BA%D1%80%D0%B0%D0%BD%D0%B0%202024-11-25%20071716.jpg)

Рисунок 3 – Запущені тести

Посилання на GitHub: https://github.com/2Maksym2/Project


__ДОДАТОК__

Лістинг

Вміст консольного додатку (Cinema.cs):

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class Cinema
    {
        public List<Cashier> Cashiers { get; } = new List<Cashier>();
        public List<Hall> Halls { get; } = new List<Hall>();
        public Cinema()
        {
            Halls = new List<Hall>
        {
            new Hall (1,100),
            new Hall (1,120),
        };
        }
    } 
}
Вміст консольного додатку (Hall.cs):

using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
 public class Hall : IPrintable
    {
        public int HallId { get; set; }
        public int Capacity { get; set; }
        public DateTime MovieDate { get; set; }

   public Hall(int hallId, int capacity)
        {
            HallId = hallId;
            Capacity = capacity;
        }

  public void PrintDetails()
        {
            throw new NotImplementedException();
        }

 public List<int> AvailableSeats(int HallId, DateTime movieDate, int capacity)
        {
            throw new NotImplementedException();
        }
    }
}

Вміст консольного додатку (Customer.cs):

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class Customer
    {
        public string Name { get; set; }
        public int Age { get; set; }

 public Customer(string name, int age)
        {
            Name = name;
            Age = age;
        }

  public string BuyTicket(Customer customer)
        {
            throw new NotImplementedException();
        }

 public bool CanWatchMovie(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}

Вміст консольного додатку (Cashier.cs):

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class Cashier
    {
        public string Name { get; set; }
        public double Salary { get; set; }

 public Cashier(string name, double salary)
        {
            Name = name;
            Salary = salary;
        }
    }
}

Вміст консольного додатку (Movie.cs):

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class Movie
    {
        public List<Movie> Films { get; } = new List<Movie>();
        public FilmType Genre { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public int AgeRestriction { get; set; }
        public double TicketPrice { get; set; }

 public Movie(FilmType genre, string title, int duration, int ageRestriction, double ticketPrice)
        {
            Genre = genre;
            Title = title;
            Duration = duration;
            AgeRestriction = ageRestriction;
            TicketPrice = ticketPrice;
        }

 public List<Movie> AddMovie(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}

Вміст консольного додатку (FilmType.cs):

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
   public enum FilmType{
        Action,
        Drama,
        Comedy,
        Horror,
        Fantasy,
        Romance,
        Thriller,
        Animation,
        Documentary,
        Adventure,
        Musical,
        Historical
    }
}

Вміст консольного додатку (Ticket.cs):

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class Ticket
    {
        public int SeatNumber { get; set; }
        public int HallId { get; set; }
        public DateTime MovieDate { get; set; }
        public double TicketPrice { get; set; }
        public Cashier Cashier { get; set; }

 public Ticket(int hallId, DateTime movieDate, double ticketPrice, int seatNumber, Cashier cashier)
        {
            HallId = hallId;
            MovieDate = movieDate;
            TicketPrice = ticketPrice;
            SeatNumber = seatNumber;
            Cashier = cashier;
        }
    }
}
Вміст консольного додатку (UnitTest.cs):

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
