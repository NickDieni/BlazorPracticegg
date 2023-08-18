using System;
using System.Data.SqlClient;
using static System.Reflection.Metadata.BlobBuilder;

namespace BlazorPractice.Data
{
    public class LibraryData
    {
        public LibraryData()
        {
        }
        public List<Book> GetUsers()
        {
            BuildConnectionString nyCon = new BuildConnectionString();
            string cstring = nyCon.ConnectionString;


            List<Book> books = new List<Book>();

            using (SqlConnection con = new SqlConnection(cstring))
            {
                con.Open();

                string sqlQuery2 = "SELECT B.*, A.AuthorName FROM Books B INNER JOIN Authors A ON B.AuthorId = A.ID";

                using (SqlCommand command = new SqlCommand(sqlQuery2, con))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Book book = new Book
                            {
                                Id = Convert.ToInt32(reader["ID"]),
                                Title = reader["Bookname"].ToString(),
                                AuthorId = Convert.ToInt32(reader["AuthorId"]),
                                AuthorName = reader["AuthorName"].ToString(),
                                Borrow = reader["Borrowed"].ToString(),
                                Borrowname = reader["Borrowname"].ToString()
                            };
                            books.Add(book);
                        }
                    }
                }
                con.Close();
            }
            return books;
        }
    }

    public class Book
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Borrow { get; set; }
        public string Borrowname { get; set; }

    }

}



