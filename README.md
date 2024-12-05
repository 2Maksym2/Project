__Part A__
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

1.	Перелічення (Enum):

-	FilmType – перелік жанрів фільмів (драма, комедія, фільми жахів, фантазія, романтика, трилер, анімація, документальний фільм, пригодницький фільм, мюзикл, історичний фільм.)

2.	Класи:

-	Hall – клас для зберігання списку залів та сеансів на які можна замовити квиток.

-	Cinema – клас для зберігання зал кінотеатру.

-	Movie – клас для зберігання кожного фільму з назвами, описами та жанрами.

-	Customer – клас, що представляє клієнта кінотеатру, який купує квиток.

-	Session – клас, що представляє сеанс окремої зали кінотеатру.

-	TicketSingle – клас, що представляє квитки на 1 особу.

-	TicketGroup – клас, що представляє квитки на групу осіб.

3.	Інтерфейси:

-	IPrintable – інтерфейс для друку доступних сеансів у кожній залі.

Виявлення та визначення класів і зв'язків

Асоціація: Клас Cinema має асоціацію з класом Customer (кінотеатр може мати багато клієнтів).

Агрегація: Клас Cinema має агрегацію з класом Movie (кожна зала містить фільми, але фільми існують незалежно).

Композиція: Клас Cinema має композицію з класом Hall, при видаленні класу Cinema зали також будуть видалені.

Реалізація: Клас Hall реалізує інтерфейс IPrintable.


![ Виявлення та визначення елементів предметної області та зв’язки між ними](https://github.com/2Maksym2/Project/blob/main/Pictures/2.jpg)

Рисунок 1 – Виявлення та визначення елементів предметної області та зв’язки між ними
 
 ![ Детальне проєктування елементів моделі предметної області](https://github.com/2Maksym2/Project/blob/main/Pictures/1.jpg)

Рисунок 2 – Детальне проєктування елементів моделі предметної області

 ![ Запущені тести](https://github.com/2Maksym2/Project/blob/main/Pictures/5.jpg)

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
        public List<Hall> Halls { get; set; } = new List<Hall>(); 
        public List<Movie> Movies { get; set; } = new List<Movie>();
        public Cinema()
        {
            Hall hall1 = new Hall(1, 60); 
            Hall hall2 = new Hall(2, 80); 
            Halls.Add(hall1);
            Halls.Add(hall2);
            Halls.Sort();
        }
        public void AddMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

    } 
}

Вміст консольного додатку (Session.cs):

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class Session
    {
        public Movie SMovie { get; set; }
        public DateTime MovieDate { get; set; }
        public double TicketPrice { get; set; }
        public List<int> AvailableSeats { get; set; }

  public Session(Movie movie,  DateTime movieDate, double ticketPrice, List<int> availableSeats)
        {
            SMovie = movie;
            MovieDate = movieDate;
            TicketPrice = ticketPrice;

 AvailableSeats = availableSeats;
            
 }

 public bool IsSessionFull()
        {
           throw new NotImplementedException();
        }
  public void ReserveSeats(List<int> seatNumbers)
        {
            throw new NotImplementedException();
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
        public List<Session> Sessions { get; set; } = new List<Session>();

 public Hall(int hallId, int capacity)
        {
            HallId = hallId;
            Capacity = capacity;
        }
        public void AddSession(Session session)
        {
            throw new NotImplementedException();
        }
        public void PrintDetails()
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

 public Customer(string name)
        {
            Name = name;
        }

 public TicketSingle BuySingleTicket(Session session, int seatNumber)
        {
            throw new NotImplementedException();
        }

 public TicketGroup BuyGroupTickets(Session session, List<int> seatNumbers)
        {
            throw new NotImplementedException();
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
        public FilmType Genre { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
public Movie(string title, FilmType genre, int duration)
        {
            Title = title;
            Genre = genre;
            Duration = duration;
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

Вміст консольного додатку (TicketGroup.cs):

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class TicketGroup:Ticket
    {
        public List<int> SeatNumbers { get; set; }
        public double TicketPrice { get; set; } 

 public TicketGroup(List<int> seatNumbers, double ticketPrice)
        {
            SeatNumbers = seatNumbers;
            TicketPrice = ticketPrice;
        }

 public override double CalculateTotalPrice()
        {
            throw new NotImplementedException();
        }
    }
}

Вміст консольного додатку (TicketSingle.cs):

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class TicketSingle :Ticket
    {
        public  int SeatNumber { get; set; }
        public double TicketPrice { get; set; } 

  public TicketSingle(int seatNumber, double ticketPrice)
        {
            SeatNumber = seatNumber;
            TicketPrice = ticketPrice;
        }
        public double CalculateTotalPrice()
        {
            throw new NotImplementedException();
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



__Part B__


__ПОСТАНОВКА ЗАДАЧІ__

1.	Удосконалити проєкт, скорегував діаграму класів, додавши реалізацію хоча б одним класом будь-якого інтерфейсу(ів) .NET (IClonable, IComparable, IEnumereable тощо).

2.	Передбачити множинну реалізацію інтерфейсів.

3.	Додати хоча б один абстрактний клас*, від якого успадкувати декілька нових чи вже існуючих класів.

4.	Передбачити хоча б один варіант реалізації поліморфізму (бажано обидва):

Варіант 1: об’єкти похідного класу обробляються як об’єкти базового класу (в параметрах методів, в колекціях та ін.);

Варіант 2: перевизначення (overriding) успадкованих методів, визначення типу об’єкта під час виконання програми і виклик відповідної реалізації методу.

5.	Скорегувати каркас проєкту.

6.	Замінити заглушки в проєкті конкретними реалізаціями методів, властивостей тощо.

7.	Запустити unit-тести, досягти проходження всіх unit-тестів.

8.	Спроєктувати меню для програми, пункти меню мають відповідати предметній області і бути логічними.

9.	Реалізувати основну програму (файл Program.cs) у відповідності до спроєктованого меню.

10.	Виконати функціональне тестування всіх пунктів меню.

11.	Оформити звіт

-	Титульний аркуш
-	Завдання
-	Опис предметної області
-	Діаграма класів
-	Демонстрація реалізації поліморфізму
-	Результати запуску unit-тестів.
-	Результати функціонального тестування
-	Програмний код класів
-	Програмний код основної програми
 
__ВИКОНАННЯ РОБОТИ__

__Опис предметної області: кінотеатр__

1.	Перелічення (Enum):

-	FilmType – перелік жанрів фільмів (драма, комедія, фільми жахів, фантазія, романтика, трилер, анімація, документальний фільм, пригодницький фільм, мюзикл, історичний фільм.)

2.	Класи:

- Hall – клас для зберігання списку залів та сеансів на які можна замовити квиток.
-	Cinema – клас для зберігання зал кінотеатру.
-	Movie – клас для зберігання кожного фільму з назвами, описами та жанрами.
-	Customer – клас, що представляє клієнта кінотеатру, який купує квиток.
-	Session – клас, що представляє сеанс окремої зали кінотеатру.
-	TicketSingle – клас, що представляє квитки на 1 особу.
-	TicketGroup – клас, що представляє квитки на групу осіб.
-	Ticket – абстрактний клас, що представляє основу для створення різних типів квитів.

3.	Інтерфейси:

-	IPrintable – інтерфейс для друку доступних сеансів у кожній залі.

__Діаграма класів__
 
 ![ Виявлення та визначення елементів предметної області та зв’язки між ними](https://github.com/2Maksym2/Project/blob/main/Pictures/4.jpg)
 
 Рисунок 1 – Виявлення та визначення елементів предметної області та зв’язки між ними
 
![Детальне проєктування елементів моделі предметної області](https://github.com/2Maksym2/Project/blob/main/Pictures/3.jpg)

Рисунок 2 – Детальне проєктування елементів моделі предметної області

__Демонстрація реалізації поліморфізму__

SingleTicket:
        public override string SuccessfulPurchase()
        {
            return "Successfully purchased a single ticket";
        }
 
 ![Демонстрація реалізації поліморфізму для SingleTicket](https://github.com/2Maksym2/Project/blob/main/Pictures/8.jpg)

Рисунок 3 – Демонстрація реалізації поліморфізму для SingleTicket


GroupTicket:
        public override string SuccessfulPurchase()
        {
            return "Successfully purchased a group ticket";
        }
 
![Демонстрація реалізації поліморфізму для GroupTicket](https://github.com/2Maksym2/Project/blob/main/Pictures/7.jpg)

Рисунок 4 – Демонстрація реалізації поліморфізму для GroupTicket


__Результати запуску unit-тестів__
 
![Результат запуску unit-тестів](https://github.com/2Maksym2/Project/blob/main/Pictures/6.jpg)

Рисунок 5 – Результат запуску unit-тестів


__Результати функціонального тестування__
 
![Результат запуску unit-тестів](https://github.com/2Maksym2/Project/blob/main/Pictures/9.jpg)

Рисунок 6 – Результат функціонального тестування №1 некоректний вибір в меню
 
![Результат функціонального тестування №2 ](https://github.com/2Maksym2/Project/blob/main/Pictures/10.jpg)

Рисунок 7 – Результат функціонального тестування №2 

![Результат функціонального тестування №3 додавання фільму до фільмотеки](https://github.com/2Maksym2/Project/blob/main/Pictures/11.jpg)

Рисунок 8 – Результат функціонального тестування №3 додавання фільму до фільмотеки
 
![Результат функціонального тестування №4 додавання сеансу до зали](https://github.com/2Maksym2/Project/blob/main/Pictures/12.jpg)

Рисунок 9 – Результат функціонального тестування №4 додавання сеансу до зали
 
![Результат функціонального тестування №5 покупка білету на одного](https://github.com/2Maksym2/Project/blob/main/Pictures/13.jpg)

Рисунок 10 – Результат функціонального тестування №5 покупка білету на одного
 
![Результат функціонального тестування №6 покупка групового білету](https://github.com/2Maksym2/Project/blob/main/Pictures/14.jpg)

Рисунок 11 – Результат функціонального тестування №6 покупка групового білету
 
![Результат функціонального тестування №7](https://github.com/2Maksym2/Project/blob/main/Pictures/15.jpg)

Рисунок 12 – Результат функціонального тестування №7


__Посилання на GitHub__: https://github.com/2Maksym2/Project
 


__ДОДАТОК__

__Лістинг__

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
        public List<Hall> Halls { get; set; } = new List<Hall>(); 
        public List<Movie> Movies { get; set; } = new List<Movie>();
        public Cinema()
        {
            Hall hall1 = new Hall(1, 60); 
            Hall hall2 = new Hall(2, 80); 
            Halls.Add(hall1);
            Halls.Add(hall2);
            Halls.Sort();
        }
        public void AddMovie(Movie movie)
        {
            Movies.Add(movie);
        }

    } 
}

Вміст консольного додатку (Session.cs):

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class Session
    {
        public Movie SMovie { get; set; }
        public DateTime MovieDate { get; set; }
        public double TicketPrice { get; set; }
        public List<int> AvailableSeats { get; set; }

   public Session(Movie movie,  DateTime movieDate, double ticketPrice, List<int> availableSeats)
        {
           SMovie = movie;
            MovieDate = movieDate;
            TicketPrice = ticketPrice;
    AvailableSeats = availableSeats;
            
        }

  public bool IsSessionFull()
        {
           return AvailableSeats.Count == 0;
        }

 public void ReserveSeats(List<int> seatNumbers)
        {
            foreach (var seat in seatNumbers)
            {
                if (AvailableSeats.Contains(seat))
                {
                    AvailableSeats.Remove(seat);
                }
                else
                {
                    throw new Exception($"Seat {seat} is already reserved or does not exist.");
                }
            }
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
    public class Hall : IPrintable, IComparable<Hall>
    {
        public int HallId { get; set; } 
        public int Capacity { get; set; } 
        public List<Session> Sessions { get; set; } = new List<Session>();

  public Hall(int hallId, int capacity)
        {
            HallId = hallId;
            Capacity = capacity;
        }
  public void AddSession(Session session)
        {
            Sessions.Add(session);
        }
        public void PrintDetails()
        {
            Console.WriteLine($"Hall {HallId} Capacity {Capacity}");
        Console.WriteLine("Sessions:");

 foreach (var session in Sessions)
        {
            Console.WriteLine($"Movie: {session.SMovie.Title}, Time: {session.MovieDate}");
            Console.WriteLine($"Available Seats:");

   var seats = session.AvailableSeats;
     for (int i = 0; i < seats.Count; i++)
            {
           Console.Write(seats[i] + "\t");

 if ((i + 1) % 5 == 0)
                {
                    Console.WriteLine();
                }
            }

 Console.WriteLine(); 
        }
        }
 public int CompareTo(Hall? obj)
       {
           if (obj == null) return 1;
           return Capacity.CompareTo(obj.Capacity);
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

 public Customer(string name)
        {
            Name = name;
        }

 public TicketSingle BuySingleTicket(Session session, int seatNumber)
        {
           if (!session.AvailableSeats.Contains(seatNumber))
                throw new Exception($"Seat {seatNumber} is not available.");

 session.AvailableSeats.Remove(seatNumber);
 return new TicketSingle(seatNumber, session.TicketPrice);
        }

 public TicketGroup BuyGroupTickets(Session session, List<int> seatNumbers)
        {
            session.ReserveSeats(seatNumbers);
            return new TicketGroup(seatNumbers, session.TicketPrice);
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
        public FilmType Genre { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }

 public Movie(string title, FilmType genre, int duration)
        {
            Title = title;
            Genre = genre;
            Duration = duration;
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

Вміст консольного додатку (TicketGroup.cs):

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class TicketGroup:Ticket
    {
        public List<int> SeatNumbers { get; set; }
        public override double TicketPrice { get; set; } 

  public TicketGroup(List<int> seatNumbers, double ticketPrice)
        {
            SeatNumbers = seatNumbers;
            TicketPrice = ticketPrice;
        }

  public override double CalculateTotalPrice()
        {
           return SeatNumbers.Count * TicketPrice;
        }
  public override string SuccessfulPurchase()
        {
            return "Successfully purchased a group ticket";
        }
    }
}

Вміст консольного додатку (TicketSingle.cs):

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace project
{
    public class TicketSingle :Ticket
    {
        public  int SeatNumber { get; set; }
        public override double TicketPrice { get; set; } 

  public TicketSingle(int seatNumber, double ticketPrice)
        {
            SeatNumber = seatNumber;
            TicketPrice = ticketPrice;
        }
     public override double CalculateTotalPrice()
        {
           return TicketPrice;
        }
    public override string SuccessfulPurchase()
        {
            return "Successfully purchased a single ticket";
        }
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
    public abstract class Ticket
    {
        public abstract double TicketPrice { get; set; }
        public abstract double CalculateTotalPrice();
        public virtual string SuccessfulPurchase()
        {
            return "Successfully purchased a  ticket";
        }
    }
}

Вміст консольного додатку (Program.cs):

using System;
namespace project
{
    class Program
    {
        static void Main(string[] args)
        {
           Cinema cinema = new Cinema();
            bool running = true;

  do
            {
                try
                {
                    Console.WriteLine("\nMenu: ");
                    Console.WriteLine("1. Add a movie to the library");
                    Console.WriteLine("2. Add a session to a hall");
                    Console.WriteLine("3. Buy a ticket");
                    Console.WriteLine("4. Show available sessions");
                    Console.WriteLine("5. Show movie library");
                    Console.WriteLine("6. Exit"); 
                    string choice = Console.ReadLine();

 if (string.IsNullOrWhiteSpace(choice))
                    {
                        Console.WriteLine("Input cannot be empty. Try again.");
                        continue;
                    }

  switch (choice)
                    {
                        case "1":
                            AddMovie(cinema);
                            break;

 case "2":
                            AddSession(cinema);
                            break;

 case "3":
                            BuyTicket(cinema);
                            break;

  case "4":
                            PrintAvailableSessions(cinema);
                            break;

  case "5":
                            PrintMovieLibrary(cinema);
                            break;

   case "6":
                            running = false;
                            break;

   default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            } while (running);
        }

 static void AddMovie(Cinema cinema)
               {
                   string title;
                   do
                   {
                       try
                       {
                           Console.Write("\nEnter the movie title: ");
                           title = Console.ReadLine();
                           if (string.IsNullOrWhiteSpace(title))
                               throw new Exception("Movie title cannot be empty.");
                           break;
                       }
                       catch (Exception ex)
                       {
                           Console.WriteLine($"Error: {ex.Message}");
                       }
                   } while (true);

  FilmType genre;
                   do
                   {
                       try
                       {
                           Console.WriteLine("\nSelect the genre:");
                           int i = 0;
                           foreach (var type in Enum.GetValues(typeof(FilmType)))
                           {
                               Console.WriteLine($"{i} - {type}");
                               i++;
                           }

  string genret = Console.ReadLine();
                           if (string.IsNullOrWhiteSpace(genret))
                               throw new Exception("Genre cannot be empty.");
                           if (!Enum.TryParse<FilmType>(genret, true, out genre))
                               throw new Exception("Invalid genre.");
                           if (int.TryParse(genre.ToString(), out int number))
                           {
                               throw new Exception("Invalid genre.");
                           }

  break;
                       }
                       catch (Exception ex)
                       {
                           Console.WriteLine($"Error: {ex.Message}");
                       }
                   } while (true);

 int duration;
                   do
                   {
                       try
                       {
                           Console.Write("\nEnter the movie duration (in minutes): ");
                           string durationInput = Console.ReadLine();
                           if (string.IsNullOrWhiteSpace(durationInput))
                               throw new Exception("Duration cannot be empty.");
                           if (!int.TryParse(durationInput, out duration) || duration <= 0)
                               throw new Exception("Invalid duration format.");
                           break;
                       }
                       catch (Exception ex)
                       {
                           Console.WriteLine($"Error: {ex.Message}");
                       }
                   } while (true);

 Movie movie = new Movie(title, genre, duration);
                   cinema.AddMovie(movie);
                   Console.WriteLine("\nMovie added successfully.");
               }

 static void AddSession(Cinema cinema)
               {
                   if (cinema.Movies.Count == 0)
                   {
                       Console.WriteLine("Cannot add a session. No movies in the library.");
                       return;
                   }

   Hall hall = null;
      Movie movie = null;
      DateTime sessionDateTime = DateTime.MinValue;
    double price = 0;

  do
                   {
                       try
                       {
                           Console.Write("Choose a hall (1 or 2): ");
                           string hallInput = Console.ReadLine();
                           if (string.IsNullOrWhiteSpace(hallInput))
                               throw new Exception("Hall selection cannot be empty.");
                           if (!int.TryParse(hallInput, out int hallId) || hallId < 1 || hallId > cinema.Halls.Count)
                               throw new Exception("Invalid hall number.");
                           hall = cinema.Halls[hallId - 1];
                           break;
                       }
                       catch (Exception ex)
                       {
                           Console.WriteLine($"Error: {ex.Message}");
                       }
                   } while (true);

   do
                   {
                       try
                       {
                           Console.WriteLine("Select a movie:");
                           for (int i = 0; i < cinema.Movies.Count; i++)
                           {
                               Console.WriteLine($"{i + 1}. {cinema.Movies[i].Title}");
                           }

   string movieInput = Console.ReadLine();
  if (string.IsNullOrWhiteSpace(movieInput))
                               throw new Exception("Movie selection cannot be empty.");
                           if (!int.TryParse(movieInput, out int movieIndex) || movieIndex < 1 || movieIndex > cinema.Movies.Count)
                               throw new Exception("Invalid movie choice.");

=  movie = cinema.Movies[movieIndex - 1];
                           break;
                       }
                       catch (Exception ex)
                       {
                           Console.WriteLine($"Error: {ex.Message}");
                       }
                   } while (true);

  do
                   {
                       try
                       {
                           Console.Write("Enter the session date and time (format: yyyy-MM-dd HH:mm): ");
                           string dateInput = Console.ReadLine();
                           if (string.IsNullOrWhiteSpace(dateInput))
                               throw new Exception("Date cannot be empty.");
                           if (!DateTime.TryParse(dateInput, out sessionDateTime))
                               throw new Exception("Invalid date format.");
                           if (sessionDateTime < DateTime.Now)
                               throw new Exception("Cannot create a session in the past.");

   var endTime = sessionDateTime.AddMinutes(movie.Duration);

  foreach (var s in hall.Sessions)
                           {
                               var sessionEndTime = s.MovieDate.AddMinutes(s.SMovie.Duration);
                               if ((sessionDateTime >= s.MovieDate && sessionDateTime < sessionEndTime) ||
                                   (endTime > s.MovieDate && endTime <= sessionEndTime))
                               {
                                   throw new Exception("The session overlaps with an existing session.");
                               }
                           }
                           break;
                       }
                       catch (Exception ex)
                       {
                           Console.WriteLine($"Error: {ex.Message}");
                       }
                   } while (true);

 do
                   {
                       try
                       {
                           Console.Write("Enter ticket price: ");
                           string priceInput = Console.ReadLine();
                           if (string.IsNullOrWhiteSpace(priceInput))
                               throw new Exception("Price cannot be empty.");
                           if (!double.TryParse(priceInput, out price) || price <= 0)
                               throw new Exception("Invalid price format.");
                           break;
                       }
                       catch (Exception ex)
                       {
                           Console.WriteLine($"Error: {ex.Message}");
                       }
                   } while (true);
                    List<int> availableSeats = new List<int>();
                     for (int i = 1; i <= hall.Capacity; i++)
                     {
                       availableSeats.Add(i);
                     }
            Session session = new Session(movie, sessionDateTime, price, availableSeats);
                   hall.AddSession(session);
                   Console.WriteLine("Session added successfully.");
               }
              
        static void BuyTicket(Cinema cinema)
               {
                   List<Session> allSessions = new List<Session>();
                   foreach (var hall in cinema.Halls)
                   {
                       foreach (var session in hall.Sessions)
                       {
                           allSessions.Add(session);
                       }
                   }

 if (allSessions.Count == 0)
                   {
                       Console.WriteLine("No sessions available to buy tickets.");
                       return;
                   }

  Session selectedSession;

do
                   {
                       try
                       {
                           Console.WriteLine("Choose a session:");
                           for (int i = 0; i < allSessions.Count; i++)
                           {
                               Console.WriteLine(
                                   $"\n{i + 1}. {allSessions[i].SMovie.Title}, " +
                                   $"Time: {allSessions[i].MovieDate}");
                               var seats = allSessions[i].AvailableSeats;
                               for (int j = 0; j < seats.Count; j++)
                               {
                                   Console.Write(seats[j] + "\t");

 if ((j + 1) % 5 == 0)
                                   {
                                       Console.WriteLine();
                                   }
                               }

  Console.WriteLine();
                           }



 string sessionInput = Console.ReadLine();
                           if (string.IsNullOrWhiteSpace(sessionInput))
                               throw new Exception("Session selection cannot be empty.");
                           if (!int.TryParse(sessionInput, out int sessionIndex) || sessionIndex < 1 || sessionIndex > allSessions.Count)
                               throw new Exception("Invalid session choice.");

  selectedSession = allSessions[sessionIndex - 1];

 if (selectedSession.IsSessionFull())
                               throw new Exception("No available seats for the selected session.");

   break;
                       }
                       catch (Exception ex)
                       {
                           Console.WriteLine($"Error: {ex.Message}");
                       }
                   } while (true);

  do
                   {
                       try
                       {
                           Customer cinemacustomer = null;
                          do{
                               try
                               {
                                   Console.Write("Enter your nickname: ");

string nickname = Console.ReadLine();

 if (string.IsNullOrWhiteSpace(nickname))
                                       throw new Exception("Nickname  cannot be empty.");
                                   cinemacustomer = new Customer(nickname);

 break;
                               }
                               catch (Exception ex)
                               {
                                   Console.WriteLine($"Error: {ex.Message}");
                               }
                           } while (true);
                           Console.Write("Do you want to buy a single ticket or a group ticket? (1/2): ");
                           string ticketType = Console.ReadLine()?.Trim().ToLower();

 if (string.IsNullOrWhiteSpace(ticketType) || (ticketType != "1" && ticketType != "2"))
                               throw new Exception("Invalid input. Please enter 1 (single) or 2 (group).");

if (ticketType == "1")
                           {
                               int seatNumber = 0; 
                               do
                               {
                                   try
                                   {
                                       Console.Write("Enter seat number: ");
                                       string seatInput = Console.ReadLine();

 if (string.IsNullOrWhiteSpace(seatInput))
                                           throw new Exception("Seat number cannot be empty.");
                                       if (!int.TryParse(seatInput, out seatNumber))
                                           throw new Exception("Input must be digits only.");

 if (!selectedSession.AvailableSeats.Contains(seatNumber))
                                           throw new Exception($"Seat {seatNumber} is not available.");

 break;
                                   }
                                   catch (Exception ex)
                                   {
                                       Console.WriteLine($"Error: {ex.Message}");
                                   }
                               } while (true);

 var ticket = cinemacustomer.BuySingleTicket(selectedSession, seatNumber);
                               Console.WriteLine($"{ticket.SuccessfulPurchase()} for seat {seatNumber}.");
                               Console.WriteLine($"Ticket price: {ticket.TicketPrice}.");
                           }
                              else if (ticketType == "2")
                               {
                                   List<int> Seats = new List<int>(); 

int seatCount = 0;
                                   do
                                   {
                                       try
                                       {
                                           Console.Write("Enter the number of seats you want to reserve (1-10): ");
                                           string seatsCountInput = Console.ReadLine();

 if (string.IsNullOrWhiteSpace(seatsCountInput))
                                               throw new Exception("Seats count cannot be empty.");
                                           if (!int.TryParse(seatsCountInput, out seatCount) || seatCount < 1 || seatCount > 10)
                                               throw new Exception("You can buy from 1 to 10 seats.");

 break; 
                                       }
                                       catch (Exception ex)
                                       {
                                           Console.WriteLine($"Error: {ex.Message}");
                                       }
                                   } while (true);

for (int i = 0; i < seatCount; i++)
                                   {
                                       do
                                       {
                                           try
                                           {
                                               Console.Write($"Enter seat number {i + 1}: ");
                                               string seatInput = Console.ReadLine();

 if (string.IsNullOrWhiteSpace(seatInput))
                                                   throw new Exception("Seat number cannot be empty.");
                                               if (!int.TryParse(seatInput, out int seatNumber))
                                                   throw new Exception("Input must be digits only.");
                                               if (!selectedSession.AvailableSeats.Contains(seatNumber))
                                                   throw new Exception($"Seat {seatNumber} is not available.");
                                               if (Seats.Contains(seatNumber))
                                                   throw new Exception($"Seat {seatNumber} has already been selected.");

 Seats.Add(seatNumber);
                                               break; 
                                           }
                                           catch (Exception ex)
                                           {
                                               Console.WriteLine($"Error: {ex.Message}");
                                           }
                                       } while (true);
                                   }

var groupTicket = cinemacustomer.BuyGroupTickets(selectedSession, Seats);
                                   Console.WriteLine($"{groupTicket.SuccessfulPurchase()} for seats: {string.Join(", ", Seats)}.");
                                   Console.WriteLine($"Total ticket price: {groupTicket.CalculateTotalPrice()}.");
                               }
                           break;
                       }
                       catch (Exception ex)
                       {
                           Console.WriteLine($"Error: {ex.Message}");
                       }
                   } while (true);
               }

static void PrintAvailableSessions(Cinema cinema)
               {
                   foreach (var hall in cinema.Halls)
                   {
                       hall.PrintDetails();
                   }
               }

static void PrintMovieLibrary(Cinema cinema)
               {
                   Console.WriteLine("\nMovie Library:");
                   if (cinema.Movies.Count == 0)
                   {
                       Console.WriteLine("No movies in the library.");
                       return;
                   }

for (int i = 0; i < cinema.Movies.Count; i++)
                   {
                       var movie = cinema.Movies[i];
                       Console.WriteLine($"{i + 1}. {movie.Title} - Genre: {movie.Genre}, Duration: {movie.Duration} minutes");
                   }
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

