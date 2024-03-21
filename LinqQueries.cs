public class LinqQueries
{
  private List<Book> booksCollection = new();

  public LinqQueries()
  {
    using (StreamReader reader = new StreamReader("books.json"))
    {
      string json = reader.ReadToEnd();
      booksCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
    }
  }

  public IEnumerable<Book> GetCollection()
  {
    return booksCollection;
  }
}