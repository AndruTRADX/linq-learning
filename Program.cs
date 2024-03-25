LinqQueries queries = new();

static void PrintValues(IEnumerable<Book> bookList)
{
  Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Title", "Page Number", "Published Date");
  foreach (var item in bookList)
  {
    Console.WriteLine("{0,-60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
  }
}

static void PrintDictionary(ILookup<char, Book> bookList, char letter)
{
  Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Title", "Page Number", "Published Date");
  foreach (var item in bookList[letter])
  {
    Console.WriteLine("{0,-60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.Date.ToShortDateString());
  }

}

PrintValues(queries.SkipChallengeOne());

ILookup<char, Book> dictionaryLookup = queries.LookupChallengeOne();
PrintDictionary(dictionaryLookup, 'A');