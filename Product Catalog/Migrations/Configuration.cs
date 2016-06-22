namespace Product_Catalog.Migrations
{
    using FizzWare.NBuilder;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Product_Catalog.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Product_Catalog.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            if (!context.Roles.Any(r => r.Name == "AppAdmin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "AppAdmin" };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "admin@localhost.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "admin@localhost.com" };

                manager.Create(user, "Admin.123");
                manager.AddToRole(user.Id, "AppAdmin");
            }

            var categories = Builder<Category>.CreateListOfSize(10).All()
                .With(c => c.Name = Faker.Internet.DomainWord())
                .Build();

            context.Categories.AddOrUpdate(c => c.CategoryId, categories.ToArray());

            var rand = new Random();

            var products = Builder<Product>.CreateListOfSize(100).All()
                .With(p => p.Name = Faker.Name.Last())
                .With(p => p.Price = Faker.RandomNumber.Next(1, 10))
                .With(p => p.Description = Faker.Lorem.Sentence())
                .With(p => p.Category = categories.ElementAt(rand.Next(0, categories.Count())))
                .Build();

            context.Products.AddOrUpdate(p => p.ProductId, products.ToArray());
        }
    }
}
