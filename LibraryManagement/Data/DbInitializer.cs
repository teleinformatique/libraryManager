using LibraryManagement.Data.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Data
{
    public class DbInitializer
    {
        public static void Seed(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<LibraryDbContext>();

                var cu1 = new Customer { Name = "Omar" };
                var cu2 = new Customer { Name = "Fatou" };
                var cu3 = new Customer { Name = "Khady" };

                context.Customers.Add(cu1);
                context.Customers.Add(cu2);
                context.Customers.Add(cu3);

                var a1 = new Author
                {
                    Name = "Dale Carnegie",
                    Books = new List<Book> {
                    new Book{Title="Comment de faire des amis"},
                    new Book{Title="Comment parler en public"}
                }
                };

                var a2 = new Author
                {
                    Name = "Sun Tzu",
                    Books = new List<Book> {
                    new Book{Title="L'art de la guerre"}
                }
                };

                context.Authors.Add(a1);
                context.Authors.Add(a2);

                context.SaveChanges();
            }

        }
    }
}
