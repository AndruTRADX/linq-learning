public class LinqQueries
{
  private readonly List<Book> booksCollection = new();

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

  // Where
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
}