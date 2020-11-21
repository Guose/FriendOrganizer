namespace FriendOrganizer.DataAccess.Migrations
{
    using FriendOrganizer.Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FriendOrganizer.DataAccess.FriendOrganizerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FriendOrganizerDbContext context)
        {
            context.Friends.AddOrUpdate(
                f => f.FirstName,
                new Friend { FirstName = "Justin", LastName = "Elder" },
                new Friend { FirstName = "Kathleen", LastName = "Lordan" },
                new Friend { FirstName = "Cylena", LastName = "Kiger" },
                new Friend { FirstName = "John", LastName = "Elder" }
                );

            context.ProgrammingLanguages.AddOrUpdate(
                p => p.Name,
                new ProgrammingLanguage { Name = "C#" },
                new ProgrammingLanguage { Name = "TypeScript" },
                new ProgrammingLanguage { Name = "F#" },
                new ProgrammingLanguage { Name = "VB" },
                new ProgrammingLanguage { Name = "SQL" },
                new ProgrammingLanguage { Name = "Java" });

            context.SaveChanges();

            context.FriendPhoneNumbers.AddOrUpdate(
                pn => pn.Number,
                new FriendPhoneNumber { Number = "4259234362", FriendId = context.Friends.First().Id });

            context.Meetings.AddOrUpdate(
                m => m.Title,
                new Meeting
                {
                    Title = "Watching Football",
                    DateFrom = new DateTime(2020, 11, 22),
                    DateTo = new DateTime(2020, 11, 19),
                    Friends = new List<Friend>
                    {
                        context.Friends.Single(f => f.FirstName == "Justin" && f.LastName == "Elder"),
                        context.Friends.Single(f => f.FirstName == "John" && f.LastName == "Elder")
                    }
                });
        }
    }
}
