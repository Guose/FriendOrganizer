using FriendOrganizer.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace FriendOrganizer.DataAccess
{
    public class FriendOrganizerDbContext : DbContext
    {
        //Pass in the connection string name in the base parameter
        public FriendOrganizerDbContext() : base("FriendOrganizerDb")
        {

        }

        public DbSet<Friend> Friends { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public DbSet<FriendPhoneNumber> FriendPhoneNumbers { get; set; }
        public DbSet<Meeting> Meetings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // map and split entity into two tables
            //modelBuilder.Entity<Friend>().Map(pl =>
            //{
            //    pl.Properties(l => new {l.Id, l.FirstName, l.LastName, l.Email, l.PhoneNumbers, l.FavoriteLanguageId });
            //    pl.ToTable("Friends");
            //}).Map(pi =>
            //{
            //    pi.Properties(p => new {p.Id, p.FavoriteLanguage, p.Meetings });
            //    pi.ToTable("FriendMeetings");
            //});

            // map entity to table
            //modelBuilder.Entity<Friend>().ToTable("Friends");
            //modelBuilder.Entity<ProgrammingLanguage>().ToTable("ProgrammingLanguages");
            //modelBuilder.Entity<FriendPhoneNumber>().ToTable("FriendPhoneNumbers");
            //modelBuilder.Entity<Meeting>().ToTable("Meetings");

            //Keep DbContext CodeFirst from making the tables "Plural" in the DB (Friend rather then "Friends")
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
