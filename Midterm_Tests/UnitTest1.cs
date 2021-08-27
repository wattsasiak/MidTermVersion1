using System;
using Xunit;
using System.Collections.Generic;
using DevBuildMidTerm;

namespace Midterm_Tests
{
    public class UserTests
    {
        [Fact]
        public void CheckIfMovieFilteredReturnsMovie()
        {
            //arrange
            List<Movie> movies = new List<Movie>
            {
                new Movie("The Notebook", "Rachel McAdams", "Romance", "Nick Cassavetes"),
                new Movie("Avatar", "Zach Tyler Eisen", "Action", "James Cameron"),
                new Movie("Reminiscence", "Hugh Jackman", "Thriller", "Lisa Joy")
            };


            //act
            string expect = "Avatar";

            //assert
            List<Movie> movie = User.FilterMovieByName(movies, "Avatar");
            string actual = movie[0].MovieName;


            Assert.Equal(expect, actual);

        }



        [Fact]
        public void CheckIfMovieFilteredReturnsActor()
        {
            //arrange
            List<Movie> movies = new List<Movie>
            {
                new Movie("The Notebook", "Rachel McAdams", "Romance", "Nick Cassavetes"),
                new Movie("Avatar", "Zach Tyler Eisen", "Action", "James Cameron"),
                new Movie("Reminiscence", "Hugh Jackman", "Thriller", "Lisa Joy")
            };


            //act
            string expect = "Hugh Jackman";

            //assert
            List<Movie> movie = User.FilterMovieByMainActor(movies, "Hugh Jackman");
            string actual = movie[0].MainActor;


            Assert.Equal(expect, actual);


        }




        [Fact]
        public void CheckIfMovieFilteredReturnsDirector()
        {
            //arrange
            List<Movie> movies = new List<Movie>
            {
                new Movie("The Notebook", "Rachel McAdams", "Romance", "Nick Cassavetes"),
                new Movie("Avatar", "Zach Tyler Eisen", "Action", "James Cameron"),
                new Movie("Reminiscence", "Hugh Jackman", "Thriller", "Lisa Joy")
            };

            //act
            string expect = "James Cameron";

            //assert
            List<Movie> movie = User.FilterMovieByDirector(movies, "James Cameron");
            string actual = movie[0].Director;


            Assert.Equal(expect, actual);


        }


        [Fact]
        public void TestAddMedthod()
        {
            List<Movie> actual = new List<Movie>()
            {
                new Movie("The Notebook", "Rachel McAdams", "Romance", "Nick Cassavetes"),
                new Movie("Avatar", "Zach Tyler Eisen", "Action", "James Cameron"),
                new Movie("Reminiscence", "Hugh Jackman", "Thriller", "Lisa Joy")
            };

            Movie TestNewMovie = new Movie("Friday", "Ice Cube", "Comedy", "F. Gary Gray");
            Admin TestNewAdmin = new Admin();
            List<Movie> expected = new List<Movie>()
            { new Movie("The Notebook", "Rachel McAdams", "Romance", "Nick Cassavetes"),
                new Movie("Avatar", "Zach Tyler Eisen", "Action", "James Cameron"),
                new Movie("Reminiscence", "Hugh Jackman", "Thriller", "Lisa Joy"),
                new Movie("Friday", "Ice Cube", "Comedy", "F. Gary Gray")
            };

            for (int i = 0; i < actual.Count; i++)
            {
                Assert.Equal(expected[i].MovieName, actual[i].MovieName);
                Assert.Equal(expected[i].MainActor, actual[i].MainActor);
                Assert.Equal(expected[i].Genre, actual[i].Genre);
                Assert.Equal(expected[i].Director, actual[i].Director);

            }


        }


        //[Fact]
        //public void TestEditActor()
        //{

        //    Admin admin = new Admin();
        //    Movie actual = new Movie("Reminiscence", "Hugh Jackman", "Thriller", "Lisa Joy");
            
        //    admin.EditMovieActor(actual, "Reminiscence", "Asia Watts");
        //    Movie expected = new Movie("Reminiscence", "Asia Watts", "Thriller", "Lisa Joy");

        //    Assert.Equal(expected.MainActor, actual.MainActor);

        //}






    }







}

