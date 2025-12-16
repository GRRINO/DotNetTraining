using System.Data;
using System.Data.SqlClient;


namespace ConsoleApp_CRUD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            AdoDotNet ado = new AdoDotNet();
            ado.Create();
            ado.Read();
            ado.Edit();
        }
    }
}
