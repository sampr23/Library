using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace library
{
    class Book
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Author { get; set;}
        public int PageNumber {get; set;}
        public string Type { get; set;}

        public Book(int id, string name, string author, int pageNumber, string type){
            ID = id;
            Name = name;
            Author = author;
            PageNumber = pageNumber;
            Type = type;
        }

        public static List<Book> getLibraryBook(){

            List<Book> booksList = new List<Book>();
            booksList.Add(new Book(id : 1, name : "Salvatore, une religion interdite" , author : "Salvatore", pageNumber : 420, type : "Religion"));
            booksList.Add(new Book(id : 2, name : "Begin, la boite noir" , author : "Mumu", pageNumber : 5000, type : "Psychologie"));
            booksList.Add(new Book(id : 3, name : "Montel, la solution" , author : "Sebastien", pageNumber : 69, type : "Psychologie"));

            return booksList;
        }

        public string[] getBookInfo(Book book){
            List<string> getBook = new List<string>();
            getBook.Add(book.ID.ToString());
            getBook.Add(book.Name);
            getBook.Add(book.Author);
            getBook.Add(book.PageNumber.ToString());
            getBook.Add(book.Type);

            return getBook.ToArray();
        }

        public static string getBookInfoAPI()
        {
            string html = string.Empty;
            string url = @"https://www.googleapis.com/books/v1/volumes?q=montel&key=AIzaSyBkycVArmKU5L2cP7fylMIdaSXUZmN45yM";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }

            using JsonDocument doc = JsonDocument.Parse(html);
            JsonElement root = doc.RootElement;
            Console.WriteLine(root);

            var u1 = root[0];
            var u2 = root[1];
            Console.WriteLine(u1);
            // Console.WriteLine(u2);

            return html;
        }
    }
}