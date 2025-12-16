using ConsoleApp_CRUD.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_CRUD
{
    public class Dapper
    {
        private readonly string _connectionString = "Data Source=.;Initial Catalog=DotNetTraining;User ID=sa;Password=sasa@123;";
        public void Read()
        {
            
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = @"select * from tblBlog where IsDelete=0";
                var lst = db.Query<tblDapperBlog>(query).ToList();
                foreach (var item in lst)
                {
                    Console.WriteLine(item.BlogId);
                    Console.WriteLine(item.BlogTitle);
                    Console.WriteLine(item.BlogAuthor);
                    Console.WriteLine(item.BlogContent);
                }
            }
        }

        public void Create(string title,string author,string content)
        {
            string query = $@"INSERT INTO [dbo].[tblBlog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent]
           ,[IsDelete])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent
           ,0)  ";

            using(IDbConnection db = new SqlConnection(_connectionString))
            {
                int result = db.Execute(query,new tblDapperBlog
                {
                    BlogTitle = title,
                    BlogAuthor = author,
                    BlogContent = content
                });
                Console.WriteLine(result == 1 ? "Saving Successful" : "Saving Failed");
            }
        }
    }
}
