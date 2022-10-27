using System;
using System.ComponentModel;


namespace library
{    
    class Program
    {
        static void Main(string[] args)
        {
            List<Book> booksList = Book.getLibraryBook();
            string book = Book.getBookInfoAPI();
            showBookCollection(booksList);
            searchOption(booksList);
        }


        //This function will write the booklist on screen and ask the user if he want to see them
        static void showBookCollection(List<Book> booksList)
        {
            Console.WriteLine("Do you want to see every Book in the Collection? y or n" );
            char seeEveryBook = Console.ReadKey().KeyChar;
            while(seeEveryBook != 'y' && seeEveryBook != 'n')
            {
                seeEveryBook = Console.ReadKey().KeyChar;
            }
            
            if(seeEveryBook == 'y')
            {

                foreach (var book in booksList)
                {
                    string[] actualBook = book.getBookInfo(book);
                    Array.ForEach(actualBook, Console.WriteLine);
                    Console.WriteLine();
                }
            }
        }

        //Ask the user how he want to sort the book and return a string with the user choice
        static void searchOption(List<Book> booksList)
        {
            Console.WriteLine("Do you want to search by : \n\t1=ID\n\t2=Name\n\t3=Author\n\t4=PageNumber\n\t5=Type");
            char seachType = Console.ReadKey().KeyChar;

            while(seachType != '1' && seachType != '2' && seachType != '3' && seachType != '4' && seachType != '5')
            {
                seachType = Console.ReadKey().KeyChar;
            }
            if(seachType == '1')
                searchByID(booksList);
            else if(seachType == '2')
                searchByNameOrAuthor(booksList, seachType);
            else if(seachType == '3')
                searchByNameOrAuthor(booksList, seachType);
            else if(seachType == '4')
                searchByPageNumber(booksList);
            else if(seachType == '5')
                searchByType(booksList);
        
    
        }

        //Search in the booksList with the desired ID
        static void searchByID(List<Book> booksList)
        {
            Console.WriteLine("Enter the id you want to search : ");
            string? idToSearch = Console.ReadLine();
            if(idToSearch != null)
            {
                int idToSearchInt = Int32.Parse(idToSearch);
                foreach(var book in booksList)
                {
                    if(book.ID == idToSearchInt)
                    {
                        string[] actualBook = book.getBookInfo(book);
                        Array.ForEach(actualBook, Console.WriteLine);
                    }
                }
            }
        }

        //Search by name or Author in the booksList 
        static void searchByNameOrAuthor(List<Book> booksList, char seachType)
        {
            Console.WriteLine("Enter the {0} you want to search : ", (seachType == '2')? "name" : "author");
            string? nameToSearch = Console.ReadLine();
            if(nameToSearch != null)
            {
                List<Book> booksFound = (seachType == '2')? booksList.FindAll(c => (c.Name.ToLower()).Contains(nameToSearch.ToLower())) : booksList.FindAll(c => (c.Author.ToLower()).Contains(nameToSearch.ToLower()));

                if(booksFound.Count > 0)
                {
                    foreach (var book in booksFound)
                    {
                        foreach(PropertyDescriptor descriptor in TypeDescriptor.GetProperties(book))
                        {
                            string name = descriptor.Name;
                            object? value = descriptor.GetValue(book);
                            Console.WriteLine("{0} : {1}", name, value);
                        }
                        Console.WriteLine();
                    }
                }
            }
        }

        //Search the booksList with the desired number of pages
        static void searchByPageNumber(List<Book> booksList)
        {
            Console.WriteLine("How many pages ?");
            string? howManyPage = Console.ReadLine();
            int howManyPageInt;
            bool success = int.TryParse(howManyPage, out howManyPageInt);
            
            if(success)
            {
                foreach (var book in booksList)
                {
                    if(book.PageNumber == howManyPageInt)
                    {
                        string[] actualBook = book.getBookInfo(book);
                        Array.ForEach(actualBook, Console.WriteLine);    
                    }
                }
            }
        }

        //Search with the type of the book
        static void searchByType(List<Book> booksList)
        {
            Console.WriteLine("What is the type of book?");
            string? bookType = Console.ReadLine();
            if(bookType != null)
            {
                List<Book> booksFound = booksList.FindAll(c => (c.Type.ToLower()).Contains(bookType.ToLower()));

                if(booksFound.Count > 0)
                {
                    foreach (var book in booksFound)
                    {
                        foreach(PropertyDescriptor descriptor in TypeDescriptor.GetProperties(book))
                        {
                            string name = descriptor.Name;
                            object? value = descriptor.GetValue(book);
                            Console.WriteLine("{0} : {1}", name, value);
                        }
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
