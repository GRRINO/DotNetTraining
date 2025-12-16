using System.Data;
using System.Data.SqlClient;


namespace ConsoleApp_CRUD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            // ADO.NET CRUD Operations

            //AdoDotNet ado = new AdoDotNet();
            //ado.Create();
            //ado.Read();
            //ado.Edit();


            // Dapper CRUD Operations

            //Dapper dapper = new Dapper();
            //dapper.Read();
            //dapper.Create("Dapper Title 1", "Dapper Author 1", "Dapper Content 1");

            //EF Core CRUD Operations

            EFCore eFCore = new EFCore();

            eFCore.Read();
            //eFCore.Create("EF Core Title 1", "EF Core Author 1", "EF Core Content 1");
            //eFCore.Edit(2);
            //eFCore.Update(2, "EF Core Title Updated", "EF Core Author Updated", "EF Core Content Updated");
        }
    }
}
