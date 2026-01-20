using System;
using System.Collections;
using System.Diagnostics.Metrics;

namespace _30_11_25_part_2_Standart_Interfaces_HW
{
    class CompareByRating : IComparer<Movie>
    {
        public int Compare(Movie? x, Movie? y)
        {
            if (x == null && y == null) return 0;
            if (x == null || x.Rating == null) return -1;
            if (y == null || y.Rating == null) return 1;

            return x.Rating.Value.CompareTo(y.Rating.Value);
        }
    }

    class CompareByYear : IComparer<Movie>
    {
        public int Compare(Movie? x, Movie? y)
        {
            if (x == null && y == null) return 0;
            if (x == null || x.Year == null) return -1;
            if (y == null || y.Year == null) return 1;

            return x.Year.Value.CompareTo(y.Year.Value);
        }
    }


    class Cinema : IEnumerable
    {
        Movie[] movies;
        public string Address { get; set; }
        public Cinema(string address)
        {
            movies = new Movie[0];
            Address = address;
        }

        public void Sort()
        {
            movies.Sort();
        }
        public void Sort(IComparer<Movie> comparer)
        {
            movies.Sort(comparer);
        }

        public void Add(Movie movie)
        {
            movies = movies.Append(movie).ToArray();
        }

        public IEnumerator GetEnumerator()
        {
            return movies.GetEnumerator();
        }

        public void PrintInfo()
        {
            Console.WriteLine(this.ToString());
            foreach (Movie movie in movies)
            {
                Console.WriteLine(movie.ToString());
            }
        }

        public override string ToString()
        {
            return $"Cinema has {movies.Length} movies";
        }
    }

    class Director : ICloneable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Director(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public object Clone()
        {
            return new Director(FirstName, LastName);
        }
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }

    public enum Genre
    {
        None = 0,
        Comedy,
        Tragedy,
        Horror,
        Thriller,
        Romantic
    }

    class Movie : ICloneable, IComparable<Movie>
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public Director? Director { get; set; }
        public string? Country { get; set; }
        public Genre? MovieGenre { get; set; }
        public int? Year { get; set; }
        public float? Rating { get; set; }

        public Movie(string title)
        {
            Title = title;
        }

        public Movie(string title, string? description, Director? director, string? country, Genre? movieGenre, int? year, float? rating)
        {
            Title = title;
            Description = description;
            Director = director;
            Country = country;
            MovieGenre = movieGenre;
            Year = year;
            Rating = rating;
        }


        public object Clone()
        {
            return new Movie(Title, Description, (Director?)Director?.Clone(), Country, MovieGenre, Year, Rating);
        }

        public int CompareTo(Movie? other)
        {
            if (other == null) return 1;

            return Title.CompareTo(other.Title);
        }

        public override string ToString()
        {
            return string.Join(" ",
                Title,
                Description ?? "No Description",
                Director?.ToString() ?? "No Director",
                Country ?? "No Country",
                MovieGenre?.ToString() ?? "No MovieGenre",
                Year?.ToString() ?? "No Year",
                Rating?.ToString() ?? "No Rating");
        }
    }

    

    internal class Program
    {
        static void Main(string[] args)
        {
            Cinema cinema1 = new Cinema("Address 1");
            cinema1.Add(new Movie("Friday 13th", "Teenagers go to camp", new Director("John", "Pork"), null, Genre.Horror, 1999, 5f));
            cinema1.Add(new Movie("Trueman", null, new Director("John", "Doe"), null, null, 2000, 5f));
            cinema1.Add(new Movie("Movie 1", null, null, null, null, 2015, 3f));
            cinema1.Add(new Movie("Test Movie"));
            cinema1.Add(new Movie("Movie 2", null, null, null, null, 2035, 1f));

            Movie movie1 = new Movie("Movie 3", null, null, null, null, 1985, 4.5f);
            cinema1.Add(movie1);

            cinema1.PrintInfo();

            cinema1.Sort();
            cinema1.PrintInfo();

            cinema1.Sort(new CompareByRating());
            cinema1.PrintInfo();

            cinema1.Sort(new CompareByYear());
            cinema1.PrintInfo();

            Movie movie2 = (Movie)movie1.Clone();

            movie2.Director = new Director("test", "Last");
            cinema1.Add(movie2);

            cinema1.PrintInfo();


            

        }
    }
}
