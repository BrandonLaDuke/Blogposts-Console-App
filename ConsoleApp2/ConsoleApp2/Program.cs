using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{

    public class Blogpost
    {
        public int id;
        public string text;
        public int userid;
        public string date;
    }

    class Program
    {
        static void Main(string[] args)
        {
            var blogpost = new Blogpost();
            blogpost.id = 1;
            blogpost.text = "this is a test";
            blogpost.userid = 2;
            blogpost.date = "7/19/2016";
            InsertBlogPost(blogpost);

            ReadFromBlogPosts();

            Console.ReadLine();
        }

        static void InsertBlogPost(Blogpost blogpost)
        {
            InsertBlogPost(blogpost.id, blogpost.text, blogpost.userid, blogpost.date);
        }

        static void InsertBlogPost(int NoteId, string BlogPost, int UserId, string DatePosted)
        {
            SqlConnection sqlConnection1 = new SqlConnection(
            "Server=(LocalDb)\\v11.0;Database=aspnet-FirstProject-20160628191641;Integrated Security=true;");
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            sqlConnection1.Open();
            cmd.CommandText = "INSERT INTO [dbo].[BlogPosts] VALUES (" + NoteId + ",'" + BlogPost + "'," + UserId + ",'" + DatePosted + "')";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            reader = cmd.ExecuteReader();
            // Data is accessible through the DataReader object here.
            while (reader.Read())
            {
                Console.WriteLine(reader["NoteId"] + " " +
                reader["BlogPost"] + " " +
                reader["UserId"] + " " +
                reader["DatePosted"]);
            }

            sqlConnection1.Close();
        }

        static void InsertBlogPost()
        {
            SqlConnection sqlConnection1 = new SqlConnection(
            "Server=(LocalDb)\\v11.0;Database=aspnet-FirstProject-20160628191641;Integrated Security=true;");
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            sqlConnection1.Open();
            cmd.CommandText = "INSERT INTO [dbo].[BlogPosts] VALUES (5,'this is my post today', 15, '7/19/2016')";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            reader = cmd.ExecuteReader();
            // Data is accessible through the DataReader object here.
            while (reader.Read())
            {
                Console.WriteLine(reader["NoteId"] + " " +
                reader["BlogPost"] + " " +
                reader["UserId"] + " " +
                reader["DatePosted"]);
            }

            sqlConnection1.Close();
        }

        static void ReadFromBlogPosts()
        {
            SqlConnection sqlConnection1 = new SqlConnection(
            "Server=(LocalDb)\\v11.0;Database=aspnet-FirstProject-20160628191641;Integrated Security=true;");
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM BlogPosts";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            reader = cmd.ExecuteReader();
            // Data is accessible through the DataReader object here.
            while (reader.Read())
            {
                Console.WriteLine(reader["NoteId"] + " " +
                reader["BlogPost"] + " " +
                reader["UserId"] + " " +
                reader["DatePosted"]);
            }

            sqlConnection1.Close();
        }

        static void ReadFromBankAccounts()
        {

            {
                SqlConnection sqlConnection1 = new SqlConnection(
                "Server=(LocalDb)\\v11.0;Database=aspnet-FirstProject-20160628191641;Integrated Security=true;");
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;

                cmd.CommandText = "SELECT * FROM BankAccounts";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection1;

                sqlConnection1.Open();

                reader = cmd.ExecuteReader();
                // Data is accessible through the DataReader object here.
                while (reader.Read())
                {
                    Console.WriteLine(reader["id"] + " " +
                    reader["lastName"] + ", " +
                    reader["firstName"] + " " +
                    reader["accountNumber"] + " " +
                    reader["address"] + " " +
                    reader["balance"] + " " +
                    reader["isActive"]);
                }

                sqlConnection1.Close();
            }
        }
    }
}
