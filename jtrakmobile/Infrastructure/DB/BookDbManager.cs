using jtrakmobile.Models;
using SQLite;
using System.Collections.Generic;
using System.Linq;

namespace jtrakmobile.Infrastructure.DB
{
    public class BookDbManager : IDbManager<Book>
    {
        public bool Insert(Book book)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<Book>();
                conn.CreateTable<Author>();

                int booksInserted = conn.Insert(book);
                int authorInserted = conn.Insert(new Author { Name = book.Author });

                return booksInserted + authorInserted >= 2;
            }
        }

        public List<Book> GetAll()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<Book>();
                conn.CreateTable<Author>();

                return (from b in conn.Table<Book>()
                        join a in conn.Table<Author>() on b.AuthorId equals a.Id into authorJoin
                        from aj in authorJoin.DefaultIfEmpty()
                        select b).ToList();
            }
        }
    }
}
