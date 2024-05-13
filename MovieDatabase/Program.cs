using MovieDatabase;

Console.WriteLine("Welcome to my movie database!");
List<Movie> movies = new List<Movie>();
movies.Add(new Movie("Hot Rod", "Comedy", 2007));
movies.Add(new Movie("Talledega Nights", "Comedy", 2006));
movies.Add(new Movie("Oppenheimer", "Biopic", 2023));
movies.Add(new Movie("The Wolf of Wall Street", "Biopic", 2013));
movies.Add(new Movie("2001: A Space Odyssey", "SciFi", 1968));
movies.Add(new Movie("Intersteller", "SciFi", 2014));
movies.Add(new Movie("The Godfather", "Drama", 1972));
movies.Add(new Movie("The Idea of You", "Drama", 2024));
movies.Add(new Movie("The Matrix", "Action", 1999));
movies.Add(new Movie("The Raid: Redemption", "Action", 2011));

string genre;

do
{
    DisplayMenu();
    genre = GetMovieInput();
    List<Movie> subMovies = movies.Where(m => m.category.Equals(genre, StringComparison.OrdinalIgnoreCase)).ToList();
    PrintMovies(subMovies);

    Console.WriteLine("Would you like to see another genre? Enter yes or y to continue, enter anything else to end.");
    string input = Console.ReadLine().Trim().ToLower();
    if (input != "y" && input != "yes") break;
}while(true);

static string GetMovieInput()
{
    string str;
    int n;

    do
    {
        Console.WriteLine("Please enter the genre of movie you are interested in.");
        str = Console.ReadLine().Trim().ToLower();
        if (str == "comedy" || str == "biopic" || str == "scifi" || str == "drama" || str == "action")
        {
            return str;
        }
        else if(int.TryParse(str, out n) && n > 0 && n < 6)
        {
            if(n == 1)
            {
                return "action";
            }
            else if(n == 2)
            {
                return "biopic";
            }
            else if(n == 3)
            {
                return "comedy";
            }
            else if(n == 4)
            {
                return "drama";
            }
            else if (n == 5)
            {
                return "scifi";
            }
        }
        else
        {
            Console.WriteLine("Please enter comedy, biopic, scifi, drama, or action.  Alternatively, enter the number shown next to the category from the menu");
        }
    } while(true);
}

static void DisplayMenu()
{
    Console.WriteLine("1 - Action");
    Console.WriteLine("2 - Biopic");
    Console.WriteLine("3 - Comedy");
    Console.WriteLine("4 - Drama");
    Console.WriteLine("5 - SciFi");
}

static void PrintMovies(List<Movie> l)
{
    l.OrderBy(m => m.title);
    foreach (Movie m in l)
    {
        Console.WriteLine($"{m.title} ({m.year})");
    }
}