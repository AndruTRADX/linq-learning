using System;

public class Book
{
    public Book()
    {
        // Valores por defecto para las propiedades
        Title = "";
        PageCount = 0;
        PublishedDate = DateTime.MinValue;
        ThumbnailUrl = "";
        ShortDescription = "";
        LongDescription = "";
        Status = "";
        Authors = [];
        Categories = [];
    }

    public string Title { get; set; }
    public int PageCount { get; set; }
    public DateTime PublishedDate { get; set; }
    public string ThumbnailUrl { get; set; }
    public string ShortDescription { get; set; }
    public string LongDescription { get; set; }
    public string Status { get; set; }
    public string[] Authors { get; set; }
    public string[] Categories { get; set; }
}