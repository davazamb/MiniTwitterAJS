namespace API.Migrations
{
    using Model.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<UserTweetContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(UserTweetContext context)
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
            var users = new List<User>
            {
                new User(){Username="admin2",Password="12345", FirstName="SuperUser", LastName="Admin2" },
                new User(){Username="davazamb10",Password="123456.", FirstName="Ali", LastName="Burgos" },
            };
            users.ForEach(u => context.Users.Add(u));
            context.SaveChanges();

            var posts = new List<Tweet>
            {
                new Tweet(){Content="Bienvenido!",Type="Social", ParentId=null, CreateDate=new DateTime(2017,08,10), UpdateDate=new DateTime(2017,10,10), UserId=1 },
                new Tweet(){Content="Bienvenido!",Type="Social", ParentId=null, CreateDate=new DateTime(2017,08,10), UpdateDate=new DateTime(2017,10,10), UserId=2 },

            };
            posts.ForEach(t => context.Tweets.Add(t));
            context.SaveChanges();
        }
    }
}
