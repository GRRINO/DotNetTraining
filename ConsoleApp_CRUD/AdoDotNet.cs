using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_CRUD
{
    public class AdoDotNet
    {
        private readonly string _connectionString = "Data Source=.;Initial Catalog=DotNetTraining;User ID=sa;Password=sasa@123;";
        public void Read()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            Console.WriteLine("Database Connecting");
            connection.Open();

            string query = @"SELECT[BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
      ,[IsDelete]
  FROM[dbo].[tblBlog]";

            SqlCommand cmd = new SqlCommand(query, connection);
            //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //adapter.Fill(dt);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader["BlogId"]);
                Console.WriteLine(reader["BlogTitle"]);
                Console.WriteLine(reader["BlogAuthor"]);
                Console.WriteLine(reader["BlogContent"]);
            }

            Console.WriteLine("Database Closing");
            connection.Close();

            //foreach(DataRow dr in dt.Rows)
            //{
            //    Console.WriteLine(dr["BlogId"]);
            //    Console.WriteLine(dr["BlogTitle"]);
            //    Console.WriteLine(dr["BlogAuthor"]);
            //    Console.WriteLine(dr["BlogContent"]);
            //}
        }

        public void Create()
        {
            Console.Write("Enter Blog Title: ");
            string title = Console.ReadLine();

            Console.Write("Enter Blog Author: ");
            string author = Console.ReadLine();

            Console.Write("Enter Blog Content: ");
            string content = Console.ReadLine();


            SqlConnection sqlConnection = new SqlConnection(_connectionString);
            Console.WriteLine("Database Connecting");
            sqlConnection.Open();

            string query = $@"INSERT INTO [dbo].[tblBlog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent]
           ,[IsDelete])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent
           ,0)";

            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);

            //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //adapter.Fill(dt);

            int result = cmd.ExecuteNonQuery();

            sqlConnection.Close();

            Console.WriteLine(result == 1 ? "Create Successful" : " Create Failed");
        }

        public void Edit()
        {

            Console.Write(" Enter Blof Id : ");
            string id = Console.ReadLine();
            SqlConnection sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();

            string query = @"SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
      ,[IsDelete]
  FROM [dbo].[tblBlog] where BlogId = @BlogId
";

            SqlCommand cmd = new SqlCommand(query,sqlConnection);
            cmd.Parameters.AddWithValue("@BlogId", id);
                       
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            sqlConnection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine(dr["BlogId"]);
                Console.WriteLine(dr["BlogTitle"]);
                Console.WriteLine(dr["BlogAuthor"]);
                Console.WriteLine(dr["BlogContent"]);
            }
        }
    }
}
