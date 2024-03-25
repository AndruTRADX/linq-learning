public class LinqQueries
{
  private readonly List<Book> booksCollection = [];

  public LinqQueries()
  {
    using StreamReader reader = new StreamReader("books.json");
    string json = reader.ReadToEnd();
    booksCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
  }

  public IEnumerable<Book> GetCollection()
  {
    return booksCollection;
  }

  // --------------- Basic Operators --------------- //

  // Where: It returns all elements that meet the condition in a "IEnumerable" list
  public IEnumerable<Book> WhereChallengeOne()
  {
    return from book in booksCollection where book.PublishedDate.Year > 2000 select book;
    // return booksCollection.ToList().Where(book => book.PublishedDate.Year > 2000);
  }

  public IEnumerable<Book> WhereChallengeTwo()
  {
    return booksCollection.ToList().Where(book => book.PageCount > 250 && book.Title.Contains("in Action"));
    // return from book in booksCollection where book.PageCount > 250 && book.Title.Contains("in Action") select book;
  }

  // All: All the elements must meet the condition, if so, it returns "true"
  public bool AllChallengeOne()
  {
    return booksCollection.All(book => book.Status == "PUBLISH");
  }

  // Any: If at least one of the elements meets the condition, it returns "true"
  public bool AnyChallengeOne()
  {
    return booksCollection.Any(book => book.PublishedDate.Year == 2005);
  }

  // Contains: Along with Where it returns all the elements that contain the value
  public IEnumerable<Book> ContainsChallengeOne()
  {
    return booksCollection.Where(book => book.Categories.Contains("Python"));
  }

  // OrderBy: Sorts the elements within a list in ascending order given the parameter we send
  public IEnumerable<Book> OrderByChallengeOne()
  {
    return booksCollection.Where(book => book.Categories.Contains("Java")).OrderBy(book => book.Title);
  }

  // OrderByDescending: Sorts the elements within a list in descending order given the parameter we send
  public IEnumerable<Book> OrderByDescendingChallengeOne()
  {
    return booksCollection.Where(book => book.PageCount > 450).OrderByDescending(book => book.PageCount);
  }

  // Take: It select the first elements of a specific amount of elements within a list
  public IEnumerable<Book> TakeChallengeOne()
  {
    return booksCollection
      .Where(book => book.Categories.Contains("Java"))
      .OrderByDescending(book => book.PublishedDate)
      .Take(3); // <- Take the first 3 of these books (With TakeLast(3) it would take the last 3 ones)
  }

  // Skip: It omits a specific amount of elements within a list and then selects the remaining elements
  public IEnumerable<Book> SkipChallengeOne()
  {
    return booksCollection
      .Where(book => book.PageCount > 400)
      .Skip(2) // It Skips two elements of the list
      .Take(2); // We take only two of them
  }

  // Select: It only returns the data we specify instead of the entire object (dynamic selection)
  public IEnumerable<Book> SelectChallengeOne()
  {
    return booksCollection
      .Take(3)
      .Select(book => new Book() { Title = book.Title, PageCount = book.PageCount });
  }

  // --------------- Aggregation Operators --------------- //

  // Count (int) && LongCount (long): It returns the amount of the items that meet a given condition
  public int CountChallengeOne(int rangeOne = 200, int rangeTwo = 500)
  {
    return booksCollection.Count(book => book.PageCount >= rangeOne && book.PageCount <= rangeTwo);
  }

  // Min: Gets the lowest specified item property of a collection
  public DateTime MinChallengeOne()
  {
    return booksCollection.Min(book => book.PublishedDate);
  }

  // Max: Gets the largest highest item property of a collection
  public int MaxChallengeOne()
  {
    return booksCollection.Max(book => book.PageCount);
  }

  // MinBy: Gets the element with the lowest value of the specified property
  public Book MinBYChallengeOne()
  {
    return booksCollection.Where(book => book.PageCount > 0).MinBy(book => book.PageCount);
  }

  // MaxBy: Gets the element with the highest value of the specified property
  public Book MaxByChallengeOne()
  {
    return booksCollection.MaxBy(book => book.PublishedDate);
  }

  // Sum: Sums all the elements of a list and return the result
  public int SumChallengeOne()
  {
    return booksCollection.Where(book => book.PageCount >= 0 && book.PageCount <= 500).Sum(book => book.PageCount);
  }

  // Aggregate: Used to accumulate some data within a variable and return this accumulated value
  public string AggregateChallengeOne()
  {
    return booksCollection
      .Where(book => book.PublishedDate.Year > 2015)
      .Aggregate("", (bookTitles, next) =>
      {
        if (bookTitles != string.Empty)
          bookTitles += " - " + next.Title;
        else
          bookTitles += next.Title;

        return bookTitles;
      });
  }

  // Average: It allows us to take an average of a numerical property that we have within the collection
  public double AverageChallengeOne()
  {
    return booksCollection.Average(book => book.Title.Length);
  }

  // --------------- Data clustering --------------- //

  // GroupBy: Allows data to be grouped by a property
  public IEnumerable<IGrouping<int, Book>> GroupByChallengeOne()
  {
    return booksCollection.Where(p => p.PublishedDate.Year >= 200).GroupBy(book => book.PublishedDate.Year);
  }

  // Lookup: Allows you to use the entire collection in a dictionary and group the data by a property.
  public ILookup<char, Book> LookupChallengeOne()
  {
    return booksCollection.ToLookup(book => book.Title[0], book => book);
  }

  // Join: Allows us to intercept two collections and return the elements found in both collections
  public IEnumerable<Book> JoinChallengeOne()
  {
    IEnumerable<Book> collection = booksCollection.Where(x => x.PublishedDate.Year > 2005);
    IEnumerable<Book> result = booksCollection
      .Where(y => y.PageCount > 500)
      .Join(collection,
        y => y.Title,
        x => x.Title,
        (y, x) => y);

    return result;
  }
}