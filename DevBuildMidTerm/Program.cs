using System;
using System.Collections.Generic;

namespace DevBuildMidTerm
{
    public class Movie
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

    public class User
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

    public class Admin : User
    {


        List<Movie> newMovies = MoviesRepo.GetAllMovies();


        public void AddMovieToList(Movie newMovieToADD)
        {
            newMovies.Add(newMovieToADD);
        }

     
        public static void EditMovieActor(List<Movie> movies, string _MovieName, string updateActor)
        {
            foreach (Movie item in movies)
            {
                if (item.MovieName == _MovieName)
                {
                    item.MainActor = updateActor;
                }
            }


        }


        public static void EditMovieGenre(List<Movie> movies, string _MovieName, string updateGenre)
        {
            foreach (Movie item in movies)
            {
                if (item.MovieName == _MovieName)
                {
                    item.Genre = updateGenre;
                }
            }


        }

        public static void EditMovieDirector(List<Movie> movies, string _MovieName, string updateDirector)
        {
            foreach (Movie item in movies)
            {
                if (item.MovieName == _MovieName)
                {
                    item.Director = updateDirector;
                }
            }


        }


        public static void DeleteAMovie(List<Movie> movies, string movieToDelete)
        {
            for (int i = 0; i < movies.Count; i++)
            {
                if (movies[i].MovieName == movieToDelete)
                {
                    movies.Remove(movies[i]);
                }
            }

        }








        public class MoviesRepo
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


        static bool Continue()
        {
            while (true)
            {
                Console.WriteLine("Would you like to continue or quit? (continue/quit)");
                string response = Console.ReadLine();
                response = response.ToLower();


                if (response == "y" || response == "continue")
                {
                    return true;
                }
                else if (response == "quit" || response == "no")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Please enter continue or quit");
                }

            }
        }


        class Program
        {
            static void Main(string[] args)
            {
                do
                {



                    List<Movie> movies = MoviesRepo.GetAllMovies();
                    Movie addNewMovie;


                    Console.WriteLine("Welcome to the MockBuster digital movie catalog!");
                    Console.WriteLine("Are you an Admin or User?: ");


                    //user response
                    string Resp = Console.ReadLine().ToLower();
                    Console.WriteLine();

                    if (Resp == "user" | Resp == "User")
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

                            foreach (Movie item in movies)
                            {
                                Console.WriteLine(item);
                            }
                        }








                    }
                    else if (Resp == "admin" | Resp == "Admin")
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

                            foreach (Movie item in movies)
                            {
                                Console.WriteLine(item);
                            }
                        }
                        else if (userSelection == "d")
                        {

                            Console.WriteLine("Please enter name of movie you wish to delete: ");
                            string movieToDelete = Console.ReadLine();

                            Admin.DeleteAMovie(movies, movieToDelete);
                            Console.WriteLine($"{movieToDelete} has been deleted.");


                        }
                        else if (userSelection == "e" | userSelection == "E")
                        {
                            Console.WriteLine("Please enter the name of the movie that you wish to edit: ");
                            string _MovieName = Console.ReadLine();

                            Console.WriteLine("What category would you like to edit (Main Actor, Genre or Director) : ");
                            string response = Console.ReadLine().ToLower();

                            if (response == "main actor")
                            {
                                Console.WriteLine("Enter name of main actor: ");
                                string updateActor = Console.ReadLine();
                                Admin.EditMovieActor(movies, _MovieName, updateActor);
                                Console.WriteLine($"The main actor of {_MovieName} has been updated to {updateActor}.");
                            }
                            else if (response == "genre")
                            {
                                Console.WriteLine("Enter genre: ");
                                string updateGenre = Console.ReadLine();
                                Admin.EditMovieActor(movies, _MovieName, updateGenre);
                                Console.WriteLine($"The main actor of {_MovieName} has been updated to {updateGenre}.");
                            }
                            else if (response == "director")
                            {
                                Console.WriteLine("Enter name of director: ");
                                string updateDirector = Console.ReadLine();
                                Admin.EditMovieActor(movies, _MovieName, updateDirector);
                                Console.WriteLine($"The main actor of {_MovieName} has been updated to {updateDirector}.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid response entered.");
                            }

                        }
                        else if (userSelection == "a")
                        {

                            //temp code - this will be moved to a method in Admin
                            Console.Write("Would you like to add a movie to the list? (y/n): ");
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

                                Console.WriteLine();
                                Console.WriteLine("Here's the updated list!");

                                foreach (Movie item in movies)
                                {
                                    Console.WriteLine(item);
                                }


                            }

                            else
                            {
                                Console.WriteLine("Invalid Response entered. Please enter 'y' or 'n'");
                            }




                        }
                    }



                } while (Continue());
            }
        }
    }
}


