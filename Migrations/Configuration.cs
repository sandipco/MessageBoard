namespace MessageBoard.Migrations
{
    using MessageBoard.Data;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MessageBoard.Data.MessageBoardContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MessageBoard.Data.MessageBoardContext context)
        {
            var tpcs = new List<Topic>
           {
              new Topic
              {
                  Title="Entity Framework 6", Body="enable-migrations, add-migration initialCreate, update-database", Created=DateTime.Now,
                   Replies=new List<Reply>
                  {
                      new Reply{Body="I love Entity Framework, it makes life lot easier", Created=DateTime.Now.AddDays(5)},
                      new Reply{Body="I don't like the LINQ format though", Created=DateTime.Now.AddDays(4)}
                  }
              },
              new Topic
              {
                  Title="BootStrap 3", Body="What is Twitter BootStrap 3", Created=DateTime.Now.AddDays(10),
                  Replies=new List<Reply>
                  {
                      new Reply{Body="Its only css and nothing else", Created=DateTime.Now.AddMonths(3)}
                  }

              },
              new Topic
              {
                  Title="Angular JS", Body="The new Javascript Framework", Created=DateTime.Now.AddDays(80),
                  Replies=new List<Reply>
                  {
                      new Reply{Body="Its just awesome", Created=DateTime.Now.AddMonths(2)},
                      new Reply{Body="Wasn't it developed by Google", Created=DateTime.Now.AddMonths(2)},
                      new Reply{Body="Available at angularjs.org", Created=DateTime.Now.AddMonths(2)}
                  }

                },
              new Topic
              {
                  Title="SQL Server 2008", Body="Microsoft database technology", Created=DateTime.Now.AddDays(20),
                  Replies=new List<Reply>
                  {
                      new Reply{Body="Its good", Created=DateTime.Now.AddMonths(8)},
                      new Reply{Body="I am weak in PL/SQL", Created=DateTime.Now.AddMonths(2)}
                  }

                }

           };
            tpcs.ForEach(s => context.Topics.AddOrUpdate(p => p.Title, s));
            context.SaveChanges();
        }
    }
}