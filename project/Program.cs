using System;


namespace project
{
    class Program
    {
        static void Main(string[] args)
        {
           Cinema cinema = new Cinema();
            bool running = true;
            cinema.MovieAdded += DisplayMessage;
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
                            PrintMovieLibrary(cinema, IsLongMovie, DisplayMessage);
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

                           movie = cinema.Movies[movieIndex - 1];
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

                           cinemacustomer.TicketPurchased += DisplayMessage;
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
            string mes = "";
                   foreach (var hall in cinema.Halls)
                   {
                      mes += hall.PrintDetails();
                   }
            Console.WriteLine(mes);
               }

        static void PrintMovieLibrary(Cinema cinema, Predicate<Movie> longmovie, Action<string> message)
               {
                   Console.WriteLine("\nMovie Library:");
                   if (cinema.Movies.Count == 0)
                   {
                       Console.WriteLine("No movies in the library.");
                       return;
                   }

                    message.Invoke("\nMovies shorter than 2 hours:");
                    foreach (var movie in cinema.Movies)
                    {
                        if (!longmovie.Invoke(movie))
                        {
                           message.Invoke($"- {movie.Title} ({movie.Duration} minutes)");
                        }
                    }
                     message.Invoke("\nMovies longer than 2 hours:");
                    foreach (var movie in cinema.Movies)
                    {
                         if (longmovie.Invoke(movie))
                         {
                           message.Invoke($"- {movie.Title} ({movie.Duration} minutes)");
                         }
                    }
        }
        static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
        static bool IsLongMovie(Movie movie)
        {
            return movie.Duration > 120;
        }
    }
}