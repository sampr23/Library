# Library

This program is used to search between a collection of book created inside the program in the book class.

Im trying to implement the [GoogleBookAPI](https://developers.google.com/books)

You will need an API key to test this feature and create a file in the class folder with the name APIKeysLocal.cs and put the following code :
```CS
public static partial class APIKeys
{
    static APIKeys()
    {
        GoogleBookAPI = "PUT_YOUR_API_KEY_HERE";
    }
}
```
