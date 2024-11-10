using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Text;

class Book
{
    [JsonPropertyName("Name")]
    public string Title { get; set; }

    [JsonIgnore]
    public int PublishingHouseId { get; set; }

    public PublishingHouse PublishingHouse { get; set; }
}

class PublishingHouse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Adress { get; set; }
}

public class Program
{
    public static void Main (string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        List<Book> books = new List<Book>
        {
            new Book
            {
                Title = "Game of thrones",
                PublishingHouseId = 1,
                PublishingHouse = new PublishingHouse { Id = 1, Name = "Old lion publisher", Adress = "Kuyv st." }
            },
            new Book
            {
                Title = "Chemistry of death",
                PublishingHouseId = 2,
                PublishingHouse = new PublishingHouse { Id = 2, Name = "KDS", Adress = "Lviv st." }
            }
        };


        string json = JsonSerializer.Serialize(books, new JsonSerializerOptions { WriteIndented = true });
        using (StreamWriter writer = new StreamWriter("C:/Users/Admin/Desktop/SerializedBooks.json", false, Encoding.UTF8))
        {
            writer.Write(json);
        }
    }


    /*public static void Main(string[] args)
    {
 
        Console.OutputEncoding = Encoding.UTF8;

        string json;
        using (StreamReader reader = new StreamReader("C:/Users/Admin/Desktop/Books.json", Encoding.UTF8))
        {
            json = reader.ReadToEnd();
        }

        List<Book> books = JsonSerializer.Deserialize<List<Book>>(json);

        foreach (var book in books)
        {
            if (book.PublishingHouse != null)
            {
                Console.WriteLine($"Title: {book.Title},\nPublishing House: {book.PublishingHouse.Name},\nAddress: {book.PublishingHouse.Adress}\n\n");
            }
            else
            {
                Console.WriteLine($"Title: {book.Title}, Publishing House information is missing.");
            }
        }
    }*/
}
