using System;
using System.Collections.Generic;

namespace DevBuildMidTerm
{
    class Movie
    {
        public string MovieName { get; set; }
        public string MainActor { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
 
        public Movie(string movieName, string mainActor, string genre, string director)
        {
            MovieName = movieName;
            MainActor = mainActor;
            Genre = genre;
            Director = director;

        } 


        //toString

        public override string ToString()
        {
            return $"Movie Name: {MovieName}, Main Actor: {MainActor}, Genre: {Genre}, Director: {Director}";

        }

    }

    class User
    {
        //FILTER BY MOVIE NAME, MAIN ACTOR, GENRE AND DIRECTOR

        public static List<Movie> FilterMovieByName(List<Movie> movies, string movieName)
        {

            List<Movie> moviesFilteredByName = new List<Movie>();

            foreach (Movie item in movies)
            {

                if (item.MovieName == movieName)
                {
                    moviesFilteredByName.Add(item);
                }



            }

            return moviesFilteredByName;


    }

        //FilterMovieByGenre

        public static List<Movie> FilterMovieByMainActor(List<Movie> movies, string mainActor)
        {
            List<Movie> moviesFilteredByActor = new List<Movie>();
            foreach (Movie item in movies)
            {
                if (item.MainActor == mainActor)
                {
                    moviesFilteredByActor.Add(item);
                }
            }

            return moviesFilteredByActor;


        }



        public static List<Movie> FilterMovieByGenre(List<Movie> movies, string genre)
        {
            List<Movie> moviesFilteredByGenre = new List<Movie>();
            foreach (Movie item in movies)
            {
                if (item.Genre == genre)
                {
                    moviesFilteredByGenre.Add(item);
                }
            }

            return moviesFilteredByGenre;


        }


        public static List<Movie> FilterMovieByDirector(List<Movie> movies, string director)
        {
            List<Movie> moviesFilteredByDirector = new List<Movie>();
            foreach (Movie item in movies)
            {
                if (item.Director == director)
                {
                    moviesFilteredByDirector.Add(item);
                }
            }

            return moviesFilteredByDirector;


        }

        

    }

    class Admin : User
    {


        //can add movie to the movie repo

        //public static void AddMovie()
        //{


        //}
        ////can edit a movie


        // public static EditMovie()
        // {


        // }
        //remove a movie

        public static List<Movie> Delete(List<Movie> movies , string movieName)
        {
            List<Movie> deleteAMovie = new List<Movie>();
            foreach (Movie item in movies)
            {
                if (movieName == item.MovieName)
                {
                    deleteAMovie.Remove(item);
                }
            }

            return deleteAMovie;
        }
    }



    class MoviesRepo
    {

        public static List<MoviesRepo> Movies { get; }

       public static List<Movie> GetAllMovies()
        {

            List<Movie> movies = new List<Movie>
            {
                new Movie("The Notebook", "Rachel McAdams", "Romance", "Nick Cassavetes"),
                new Movie("Avatar", "Zach Tyler Eisen", "Action", "James Cameron"),
                new Movie("Reminiscence", "Hugh Jackman", "Thriller", "Lisa Joy"),
                new Movie("Titanic", "Kate Winslet", "Romance", "James Cameron"),
                new Movie("Toy Story", "Tom Hanks", "Family", "John Lasseter")


            };
            
            return movies;

        }


    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
    
            
            List<Movie> movies = MoviesRepo.GetAllMovies();
            Movie addNewMovie;


            Console.WriteLine("Welcome to the MockBuster digital movie catalog!");
            Console.WriteLine("Are you an Admin or User?: ");
            
            
            //user response
            string Resp = Console.ReadLine().ToLower();
            Console.WriteLine();

            if (Resp == "user")
            {
                Console.Clear();
                Console.Write("Would you like to [F]ilter or  [V]iew records?: ");
                string userSelection = Console.ReadLine().ToLower();

                if (userSelection == "f")
                {
                    Console.Write("Would you like to filter by Movie Name, Main Actor, Genre or Director?: ");
                    string _Resp = Console.ReadLine().ToLower();

                    if (_Resp == "movie name")
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter movie name: ");
                        string MovieToSearch = Console.ReadLine();

                        List<Movie> SearchedMovies = User.FilterMovieByName(movies, MovieToSearch);
                        foreach (Movie item in SearchedMovies)
                        {
                            Console.WriteLine($"Movie found! Movie Name: {item.MovieName}, Main Actor: {item.MainActor}, Genre {item.Genre}, Director: {item.Director}");
                        }

                    }
                    else if (_Resp == "main actor")
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter main actor name: ");
                        string MovieToSearch = Console.ReadLine();

                        List<Movie> SearchedMovies = User.FilterMovieByMainActor(movies, MovieToSearch);
                        foreach (Movie item in SearchedMovies)
                        {
                            Console.WriteLine($"Movie found! Movie Name: {item.MovieName}, Main Actor: {item.MainActor}, Genre: {item.Genre}, Director: {item.Director}");
                        }

                    }
                    else if (_Resp == "genre")
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter genre: ");
                        string MovieToSearch = Console.ReadLine();


                        List<Movie> SearchedMovies = User.FilterMovieByGenre(movies, MovieToSearch);
                        foreach (Movie item in SearchedMovies)
                        {
                            Console.WriteLine($"Movie found! Movie Name: {item.MovieName}, Main Actor: {item.MainActor}, Genre: {item.Genre}, Director: {item.Director}");
                        }
                    }
                    else if (_Resp == "director")
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter director name: ");
                        string MovieToSearch = Console.ReadLine();


                        List<Movie> SearchedMovies = User.FilterMovieByDirector(movies, MovieToSearch);
                        foreach (Movie item in SearchedMovies)
                        {
                            Console.WriteLine($"Movie found! Movie Name: {item.MovieName}, Main Actor: {item.MainActor}, Genre: {item.Genre}, Director: {item.Director}");
                        }
                    }


                }
                else if (userSelection == "v")
                {
                    Console.Clear();
                    foreach (Movie item in movies)
                    {
                        Console.WriteLine(item);
                    }
                }








            }
            else if (Resp == "admin")
            {
                Console.Clear();
                Console.Write("Would you like to [F]ilter, [A]dd, [E]dit, [V]iew or [D]elete records?: ");
                string userSelection = Console.ReadLine().ToLower();

                if (userSelection == "f")
                {
                    Console.Write("Would you like to filter by Movie Name, Main Actor, Genre or Director?: ");
                    
                    string _Resp = Console.ReadLine().ToLower();

                    if (_Resp == "movie name")
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter movie name: ");
                        string MovieToSearch = Console.ReadLine();

                        List<Movie> SearchedMovies = User.FilterMovieByName(movies, MovieToSearch);
                        foreach (Movie item in SearchedMovies)
                        {
                            Console.WriteLine($"Movie found! Movie Name: {item.MovieName}, Main Actor: {item.MainActor}, Genre: {item.Genre}, Director: {item.Director}");
                        }

                    }
                    else if (_Resp == "main actor")
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter main actor name: ");
                        string MovieToSearch = Console.ReadLine();

                        List<Movie> SearchedMovies = User.FilterMovieByMainActor(movies, MovieToSearch);
                        foreach (Movie item in SearchedMovies)
                        {
                            Console.WriteLine($"Movie found! Movie Name: {item.MovieName}, Main Actor: {item.MainActor}, Genre: {item.Genre}, Director: {item.Director}");
                        }





                    }
                    else if (_Resp == "genre")
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter genre: ");
                        string MovieToSearch = Console.ReadLine();


                        List<Movie> SearchedMovies = User.FilterMovieByGenre(movies, MovieToSearch);
                        foreach (Movie item in SearchedMovies)
                        {
                            Console.WriteLine($"Movie found! Movie Name: {item.MovieName}, Main Actor: {item.MainActor}, Genre: {item.Genre}, Director: {item.Director}");
                        }
                    }
                    else if (_Resp == "director")
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter director name: ");
                        string MovieToSearch = Console.ReadLine();


                        List<Movie> SearchedMovies = User.FilterMovieByDirector(movies, MovieToSearch);
                        foreach (Movie item in SearchedMovies)
                        {
                            Console.WriteLine($"Movie found! Movie Name: {item.MovieName}, Main Actor: {item.MainActor}, Genre: {item.Genre}, Director: {item.Director}");
                        }
                    }


                }
                else if (userSelection == "v")
                {
                    Console.Clear();
                    foreach (Movie item in movies)
                    {
                        Console.WriteLine(item);
                    }
                }
                else if (userSelection == "d")
                {
                    Console.Clear();
                    Console.WriteLine("Please enter name of movie you wish to delete: ");
                    string MovieToDelete = Console.ReadLine();


                    List<Movie> updatedMovies = Admin.Delete(movies, MovieToDelete);
                    foreach (Movie item in updatedMovies)
                    {
                        if (MovieToDelete == item.MovieName)
                        {
                            Console.WriteLine("The movie {MovieToDelete} has been deleted from the list.");
                        }
                        else
                        {
                            Console.WriteLine( ($"{MovieToDelete} was not found in the list"));
                        }
                       
                    }



                }
                else if (userSelection == "a" )
                {
                    Console.Clear();
                    //temp code - this will be moved to a method in Admin
                    Console.Write("Would you like to add a movie to the list? ");
                    string userResp = Console.ReadLine();

                    if (userResp == "y" | userResp == "yes" | userResp == "Y")
                    {
                        Console.WriteLine("Please enter movie name: ");
                        string selectMovieName = Console.ReadLine().ToLower();
                        Console.WriteLine("Please enter name of main actor: ");
                        string selectMainActor = Console.ReadLine().ToLower();
                        Console.WriteLine("Please enter genre: ");
                        string selectGenre = Console.ReadLine().ToLower();
                        Console.WriteLine("Please enter director name: ");
                        string selectDirector = Console.ReadLine().ToLower();


                        addNewMovie = new Movie(selectMovieName, selectMainActor, selectGenre, selectDirector);
                        movies.Add(addNewMovie);

                        Console.WriteLine("Here's the updated list!");

                        foreach (Movie item in movies)
                        {
                            Console.WriteLine(item);
                        }


                    }


                }
            }

            

        }
    }
}


