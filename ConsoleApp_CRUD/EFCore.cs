using ConsoleApp_CRUD.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_CRUD
{
    public class EFCore
    {
        //AppDbContext context = new AppDbContext();

        public void Read()
        {
            AppDbContext context = new AppDbContext();
            var lst = context.blogs.Where(x=>x.IsDelete == false).ToList();
            foreach (var item in lst)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            }
        }

        public void Create(string title, string author,string content)
        {
            tblBlog blog = new tblBlog
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content,
            };

            AppDbContext context = new AppDbContext();
            context.blogs.Add(blog);
            var result = context.SaveChanges();

            Console.WriteLine(result == 1 ?"Saving Successful" :"Saving Failed");


        }

        public void Edit(int id)
        {
            AppDbContext context = new AppDbContext();
            var item = context.blogs.Where(x=>x.IsDelete == false).FirstOrDefault(x => x.BlogId == id);
            if(item is null)
            {
                Console.WriteLine("No Data is found");
                return;
            }
            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);

            //context.blogs.Where(x=>x.BlogId == id).FirstOrDefault();
        }

        public void Update(int id , string title, string author, string content)
        {
            AppDbContext context = new AppDbContext();
            var item = context.blogs.AsNoTracking().Where(x => x.IsDelete == false).FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                Console.WriteLine("No Data is found");
                return;
            }

            if (!string.IsNullOrEmpty(title))
            {
             item.BlogTitle = title;

            }

            if (!string.IsNullOrEmpty(author))
            {
                item.BlogAuthor = author;

            }

            if (!string.IsNullOrEmpty(content))
            {
                item.BlogContent = content;

            }
            context.Entry(item).State = EntityState.Modified;
            var result = context.SaveChanges();
            Console.WriteLine(result == 1 ? "Updating Successful" : "Updating Failed");
        }

        public void Delete(int id)
        {
            AppDbContext context = new AppDbContext();
            var item = context.blogs.AsNoTracking().Where(x => x.IsDelete == false).FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                Console.WriteLine("No Data is found");
                return;
            }

            context.Entry(item).State = EntityState.Modified;
            var result = context.SaveChanges();
            Console.WriteLine(result == 1 ? "Deleting Successful" : "Deleting Failed");
        }
    }
}
