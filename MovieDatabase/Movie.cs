using System;

namespace MovieDatabase
{
    internal class Movie
    {
        public string title { get; set; }
        public string category { get; set; }
        public int year { get; set; }

        public Movie(string t, string c, int y)
        {
            title = t;
            category = c;
            year = y;
        }
    }
}