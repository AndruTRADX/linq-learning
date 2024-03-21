LinqQueries queries = new LinqQueries();

static void PrintValues(IEnumerable<Book> bookList)
{
  Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Title", "Page Number", "Published Date");
  foreach (var item in bookList)
  {
    Console.WriteLine("{0,-60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
  }
}

PrintValues(queries.GetCollection());